using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace PlayEngine.Forms {
   public partial class PointerScanner : Form {
      private enum ScanStatus {
         FirstScan,
         DidScan,
         Scanning
      }
      private struct ScannerThreadArgs {
         public UInt64 address;
         public List<Int32> range;

         public ScannerThreadArgs(UInt64 address, List<Int32> range) {
            this.address = address;
            this.range = new List<Int32>(range);
         }
      }
      private struct ScannerThreadUIUpdateInfo {
         public List<Int64> pathOffset;
         public List<Pointer> pathAddress;
         public Int32 sectionID;

         public ScannerThreadUIUpdateInfo(List<Int64> pathOffset, List<Pointer> pathAddress, Int32 sectionID) {
            this.pathOffset = new List<Int64>(pathOffset);
            this.pathAddress = new List<Pointer>(pathAddress);
            this.sectionID = sectionID;
         }
      }

      [Serializable]
      [XmlRoot("PointerListSave")]
      public class PointerListSaveFile {
         [XmlElement("PointerLevel")]
         public Int32 level;
         [XmlArray("Pointers")]
         [XmlArrayItem("PointerResult")]
         public List<PointerResult> pointers = new List<PointerResult>();

         [XmlIgnore]
         public static XmlSerializer serializer = null;

         public static PointerListSaveFile loadSaveFile(String saveFilePath) {
            if (serializer == null)
               serializer = new XmlSerializer(typeof(PointerListSaveFile));

            PointerListSaveFile saveFile = null;
            using (StreamReader reader = new StreamReader(saveFilePath))
               saveFile = (PointerListSaveFile)serializer.Deserialize(reader);
            return saveFile;
         }
         public Boolean saveToFile(String saveFilePath) {
            if (serializer == null)
               serializer = new XmlSerializer(typeof(PointerListSaveFile));

            try {
               using (StreamWriter writer = new StreamWriter(saveFilePath))
                  serializer.Serialize(writer, this);
               return true;
            } catch (Exception) {
               return false;
            }
         }
      }

      private MainForm mainForm;
      private PointerList pointerList = new PointerList();
      private ProcessManager processManager = null;
      private List<PointerResult> pointerResults  = new List<PointerResult>();
      private Boolean fastScan = true;
      private ScanStatus _curScanStatus = ScanStatus.FirstScan;
      private ScanStatus curScanStatus
      {
         get {
            return _curScanStatus;
         }
         set {
            _curScanStatus = value;
            switch (value) {
               case ScanStatus.FirstScan:
                  btnScan.Invoke(new Action(() => btnScan.Text = "First Scan"));
                  btnScan.Invoke(new Action(() => btnScan.Enabled = true));
                  btnScanNext.Invoke(new Action(() => btnScanNext.Enabled = false));
                  this.Invoke(new Action(() => uiStatusStrip_lblStatus.Text = "Standby..."));
                  break;
               case ScanStatus.DidScan:
                  btnScan.Invoke(new Action(() => btnScan.Text = "New Scan"));
                  btnScan.Invoke(new Action(() => btnScan.Enabled = true));
                  btnScanNext.Invoke(new Action(() => btnScanNext.Enabled = true));
                  this.Invoke(new Action(() => uiStatusStrip_lblStatus.Text = String.Format("{0} results", pointerResults.Count)));
                  break;
               case ScanStatus.Scanning:
                  btnScan.Invoke(new Action(() => btnScan.Text = "Stop"));
                  btnScan.Invoke(new Action(() => btnScan.Enabled = true));
                  btnScanNext.Invoke(new Action(() => btnScanNext.Enabled = false));
                  this.Invoke(new Action(() => uiStatusStrip_lblStatus.Text = "Scanning..."));
                  break;
            }
         }
      }

      private void chkBoxFastScan_CheckedChanged(Object sender, EventArgs e) {
         fastScan = chkBoxFastScan.Checked;
      }
      private void PointerList_OnNewPathGenerated(PointerList pointerList, List<Int64> path_offset, List<Pointer> path_address) {
         if (path_address.Count > 0) {
            Int32 baseSectionID = ProcessManager.mInstance.MappedSectionList.GetMappedSectionID(path_address[path_offset.Count - 1].Address);
            if (fastScan && !ProcessManager.mInstance.MappedSectionList[baseSectionID].Name.StartsWith("executable"))
               return;

            ScannerThreadUIUpdateInfo view_info = new ScannerThreadUIUpdateInfo(path_offset, path_address, baseSectionID);
            bgWorkerScanner.ReportProgress(95, view_info);
         }
      }
      public PointerScanner(MainForm mainForm, UInt64 address, ProcessManager processManager) {
         this.mainForm = mainForm;
         this.processManager = processManager;

         InitializeComponent();
         txtBoxScanAddress.Text = address.ToString("X");
         pointerList.NewPathGeneratedEvent += PointerList_OnNewPathGenerated;
      }

      private void btnScan_OnClick() {
         if (curScanStatus != ScanStatus.FirstScan) {
            pointerList.Stop = true;
            bgWorkerScanner.CancelAsync();
            dataGridPointerList.Rows.Clear();
            dataGridPointerList.Columns.Clear();
            curScanStatus = ScanStatus.FirstScan;
            return;
         }
         curScanStatus = ScanStatus.FirstScan;

         Int32 level = Convert.ToInt32(numericPointerLevel.Value);
         if (level <= 0)
            return;

         UInt64 address = UInt64.Parse(txtBoxScanAddress.Text, System.Globalization.NumberStyles.HexNumber);
         pointerResults.Clear();
         dataGridPointerList.Rows.Clear();
         dataGridPointerList.Columns.Clear();

         pointerList.Clear();
         pointerList.Stop = false;
         List<Int32> range = new List<Int32>();

         for (Int32 i = 0; i < level; i++) {
            range.Add(8 * 1024);
            dataGridPointerList.Columns.Add("Offset " + (i + 1), "Offset " + (i + 1));
            dataGridPointerList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
         }

         dataGridPointerList.Columns.Add("Base Address", "Base Address");
         dataGridPointerList.Columns.Add("Base Section", "Base Section");
         dataGridPointerList.Columns[level + 0].SortMode = DataGridViewColumnSortMode.NotSortable;
         dataGridPointerList.Columns[level + 1].SortMode = DataGridViewColumnSortMode.NotSortable;

         curScanStatus = ScanStatus.Scanning;
         bgWorkerScanner.RunWorkerAsync(new ScannerThreadArgs(address, range));
      }
      private void btnScanNext_OnClick() {
         UInt64 address = UInt64.Parse(txtBoxScanAddress.Text, System.Globalization.NumberStyles.HexNumber);
         pointerList.Stop = false;
         curScanStatus = ScanStatus.Scanning;
         next_pointer_finder_worker.RunWorkerAsync(new ScannerThreadArgs(address, null));
      }
      private void btnLoadPointerList_OnClick() {
         OpenFileDialog ofdialog = new OpenFileDialog();
         if (ofdialog.ShowDialog() == DialogResult.OK) {
            var saveFile = PointerListSaveFile.loadSaveFile(ofdialog.FileName);
            if (saveFile != null) {
               curScanStatus = ScanStatus.FirstScan;
               pointerResults.Clear();
               dataGridPointerList.Rows.Clear();
               dataGridPointerList.Columns.Clear();
               pointerList.Clear();

               for (Int32 i = 0; i < saveFile.level; i++) {
                  dataGridPointerList.Columns.Add(String.Format("Offset {0}", i + 1), String.Format("Offset {0}", i + 1));
                  dataGridPointerList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
               }
               dataGridPointerList.Columns.Add("Base Address", "Base Address");
               dataGridPointerList.Columns.Add("Base Section", "Base Section");
               dataGridPointerList.Columns[saveFile.level + 0].SortMode = DataGridViewColumnSortMode.NotSortable;
               dataGridPointerList.Columns[saveFile.level + 1].SortMode = DataGridViewColumnSortMode.NotSortable;

               pointerList.Init();
               foreach (var ptrResult in saveFile.pointers) {
                  Int32 row_index = dataGridPointerList.Rows.Add();
                  DataGridViewCellCollection row = dataGridPointerList.Rows[row_index].Cells;

                  for (Int32 i = 0; i < ptrResult.offsets.Length; i++) {
                     row[i].Value = (ptrResult.offsets[i].ToString("X"));                           //offset
                  }

                  if (ptrResult.offsets.Length > 0) {
                     row[row.Count - 2].Value = (ptrResult.GetBaseAddress(ProcessManager.mInstance.MappedSectionList).ToString("X"));   //address
                     row[row.Count - 1].Value = (ProcessManager.mInstance.MappedSectionList.GetSectionName(ptrResult.baseSectionID));   //section
                  }
               }
               pointerResults = new List<PointerResult>(saveFile.pointers);
            }
         }
      }
      private void btnSavePointerList_OnClick() {
         SaveFileDialog sfdialog = new SaveFileDialog();
         if (sfdialog.ShowDialog() == DialogResult.OK) {
            var saveFile = new PointerListSaveFile();
            saveFile.level = Convert.ToInt32(numericPointerLevel.Value);
            foreach (var ptrResult in pointerResults)
               saveFile.pointers.Add(ptrResult);

            saveFile.saveToFile(sfdialog.FileName);
         }
      }
      private void uiButtonHandler_Click(Object sender, EventArgs e) {
         String btnName = sender.GetType() == typeof(Button) ? (sender as Button).Name : (sender as ToolStripMenuItem).Name;
         switch (btnName) {
            case "btnScan":
               btnScan_OnClick();
               break;
            case "btnScanNext":
               btnScanNext_OnClick();
               break;
            case "uiToolStrip_btnLoadPointerList":
               btnLoadPointerList_OnClick();
               break;
            case "uiToolStrip_btnSavePointerList":
               btnSavePointerList_OnClick();
               break;
            default:
               break;
         }
      }

      private void bgWorkerScanner_DoWork(Object sender, DoWorkEventArgs e) {
         bgWorkerScanner.ReportProgress(0);
         for (Int32 section_idx = 0; section_idx < ProcessManager.mInstance.MappedSectionList.Count; ++section_idx) {
            if (bgWorkerScanner.CancellationPending)
               break;

            MappedSection mappedSection = ProcessManager.mInstance.MappedSectionList[section_idx];
            if (mappedSection.Name.StartsWith("libSce"))
               continue;

            //mappedSection.PointerSearchInit(processManager, pointerList);
            bgWorkerScanner.ReportProgress((Int32)(((Single)section_idx / ProcessManager.mInstance.MappedSectionList.Count) * 80));
         }

         if (bgWorkerScanner.CancellationPending) {
            e.Cancel = true;
            return;
         }

         bgWorkerScanner.ReportProgress(80);
         pointerList.Init();
         bgWorkerScanner.ReportProgress(90);

         var pointerFinderWorkerArgs = (ScannerThreadArgs)e.Argument;
         pointerList.FindPointerList(pointerFinderWorkerArgs.address, pointerFinderWorkerArgs.range);
         bgWorkerScanner.ReportProgress(100);
      }
      private void bgWorkerScanner_ProgressChanged(Object sender, ProgressChangedEventArgs e) {
         uiStatusStrip_ProgressBarScannerThread.Value = e.ProgressPercentage;

         if (e.UserState != null) {
            ScannerThreadUIUpdateInfo pointerFinderWorkerListViewUpdate = (ScannerThreadUIUpdateInfo)e.UserState;

            List<Int64> path_offset = pointerFinderWorkerListViewUpdate.pathOffset;
            List<Pointer> path_address = pointerFinderWorkerListViewUpdate.pathAddress;
            Int32 baseSectionID = pointerFinderWorkerListViewUpdate.sectionID;
            try {
               UInt64 baseOffset = path_address[path_offset.Count - 1].Address - ProcessManager.mInstance.MappedSectionList[baseSectionID].Start;

               PointerResult pointerResult = new PointerResult(baseSectionID, baseOffset, path_offset);
               pointerResults.Add(pointerResult);

               Int32 row_index = dataGridPointerList.Rows.Add();
               DataGridViewCellCollection row = dataGridPointerList.Rows[row_index].Cells;

               for (Int32 i = 0; i < path_offset.Count; ++i) {
                  row[i].Value = (path_offset[i].ToString("X"));                           //offset
                  Int32 sectionID = ProcessManager.mInstance.MappedSectionList.GetMappedSectionID(path_address[i].Address);
               }

               if (path_offset.Count > 0) {
                  row[row.Count - 2].Value = (path_address[path_address.Count - 1].Address.ToString("X"));                  //address
                  Int32 sectionID = ProcessManager.mInstance.MappedSectionList.GetMappedSectionID(path_address[path_address.Count - 1].Address);
                  row[row.Count - 1].Value = (ProcessManager.mInstance.MappedSectionList.GetSectionName(sectionID));               //section
               }
               uiStatusStrip_lblStatus.Text = String.Format("{0} results", pointerResults.Count);
            } catch (Exception ex) {
               MessageBox.Show(ex.ToString());
            }
         }
      }
      private void bgWorkerScanner_RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs e) {
         curScanStatus = ScanStatus.DidScan;
      }

      private void next_pointer_finder_worker_DoWork(Object sender, DoWorkEventArgs e) {
         var pointerFinderWorkerArgs = (ScannerThreadArgs)e.Argument;
         pointerList.Clear();
         next_pointer_finder_worker.ReportProgress(0);
         for (Int32 section_idx = 0; section_idx < ProcessManager.mInstance.MappedSectionList.Count; ++section_idx) {
            if (next_pointer_finder_worker.CancellationPending) break;
            MappedSection mappedSection = ProcessManager.mInstance.MappedSectionList[section_idx];
            if (mappedSection.Name.StartsWith("libSce")) continue;
            //mappedSection.PointerSearchInit(processManager, pointerList);
            next_pointer_finder_worker.ReportProgress((Int32)(((Single)section_idx / ProcessManager.mInstance.MappedSectionList.Count) * 30));
         }

         if (next_pointer_finder_worker.CancellationPending) return;

         next_pointer_finder_worker.ReportProgress(30);
         pointerList.Init();
         next_pointer_finder_worker.ReportProgress(50);

         List<PointerResult> newPointerResultList = new List<PointerResult>();
         dataGridPointerList.Rows.Clear();

         for (Int32 i = 0; i < pointerResults.Count; ++i) {
            if (i % 100 == 0) {
               next_pointer_finder_worker.ReportProgress((Int32)(50 * (Single)(i) / pointerResults.Count) + 50);
            }

            PointerResult pointerResult = pointerResults[i];

            if (pointerList.GetTailAddress(pointerResult, ProcessManager.mInstance.MappedSectionList) == pointerFinderWorkerArgs.address) {
               newPointerResultList.Add(pointerResult);
               Int32 row_index = dataGridPointerList.Rows.Add();
               DataGridViewCellCollection row = dataGridPointerList.Rows[row_index].Cells;

               for (Int32 j = 0; j < pointerResult.offsets.Length; ++j) {
                  row[j].Value = (pointerResult.offsets[j].ToString("X"));                           //offset
               }

               if (pointerResult.offsets.Length > 0) {
                  row[row.Count - 2].Value = (pointerResult.GetBaseAddress(ProcessManager.mInstance.MappedSectionList).ToString("X"));   //address
                  row[row.Count - 1].Value = (ProcessManager.mInstance.MappedSectionList.GetSectionName(pointerResult.baseSectionID));   //section
               }
            }
         }

         pointerResults = new List<PointerResult>(newPointerResultList);
         next_pointer_finder_worker.ReportProgress(100);
      }
      private void next_pointer_finder_worker_ProgressChanged(Object sender, ProgressChangedEventArgs e) {
         uiStatusStrip_ProgressBarScannerThread.Value = e.ProgressPercentage;
      }
      private void next_pointer_finder_worker_RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs e) {
         curScanStatus = ScanStatus.DidScan;
      }

      private void pointer_list_view_CellDoubleClick(Object sender, DataGridViewCellEventArgs e) {
         if (e.RowIndex < 0)
            return;

         PointerResult pointerResult = pointerResults[e.RowIndex];

         UInt64 baseAddress = pointerResult.GetBaseAddress(ProcessManager.mInstance.MappedSectionList);
         UInt64 tailAddress = pointerList.GetTailAddress(pointerResult, ProcessManager.mInstance.MappedSectionList);
         //String data = memoryHelper.BytesToString(memoryHelper.GetBytesFromAddress(tailAddress));
         //String valueType = memoryHelper.valueType.ToString();
         //mainForm.new_pointer_cheat(baseAddress, pointerResult.offsets.ToList(), valueType, data, false, "");
      }
   }
}
