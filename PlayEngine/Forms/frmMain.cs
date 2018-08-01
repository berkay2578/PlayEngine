using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Sockets;
using System.Threading;
using System.Linq;
using System.Windows.Forms;

using PlayEngine.Helpers;
using PlayEngine.Helpers.CheatManager;
using System.Runtime.InteropServices;

namespace PlayEngine.Forms {
   public partial class MainForm : Form {
      private enum ScanStatus {
         FirstScan,
         DidScan,
         Scanning
      }
      public static class SectionsColumnIndex {
         public static readonly Int32 iName = 0;
         public static readonly Int32 iOffset = 1;
         public static readonly Int32 iSize = 2;
         public static readonly Int32 iProtection = 3;
      }
      public static class ResultsColumnIndex {
         public static readonly Int32 iAddress = 0;
         public static readonly Int32 iSection = 1;
         public static readonly Int32 iValue = 2;
      }
      public static class SavedResultsColumnIndex {
         public static readonly Int32 iFreeze = 0;
         public static readonly Int32 iDescription = 1;
         public static readonly Int32 iAddress = 2;
         public static readonly Int32 iSection = 3;
         public static readonly Int32 iValueType = 4;
         public static readonly Int32 iValue = 5;
      }
      public static class ScanTypeOptions {
         public static readonly List<String> listSearch_FirstScan = new List<String>()
         {
            "Exact value",
            "Fuzzy value (float or double only)",
            "Bigger than...",
            "Smaller than...",
            "Value between...",
            "Unknown initial value"
         };
         public static readonly List<String> listSearch_NextScan = new List<String>()
         {
            "Exact value",
            "Fuzzy value (float or double only)",
            "Increased value",
            "Increased value by...",
            "Decreased value",
            "Decreased value by...",
            "Bigger than...",
            "Smaller than...",
            "Value between...",
            "Changed value",
            "Unchanged value"
         };
         public static readonly List<String> listSearchExactOnly = new List<String>()
         {
            "Exact value"
         };

         public static Memory.CompareType getCompareTypeFromString(String str) {
            switch (str) {
               case "Exact value":
                  return Memory.CompareType.ExactValue;
               case "Fuzzy value (float or double only)":
                  return Memory.CompareType.FuzzyValue;
               case "Increased value":
                  return Memory.CompareType.IncreasedValue;
               case "Increased value by...":
                  return Memory.CompareType.IncreasedValueBy;
               case "Decreased value":
                  return Memory.CompareType.DecreasedValue;
               case "Decreased value by...":
                  return Memory.CompareType.DecreasedValueBy;
               case "Bigger than...":
                  return Memory.CompareType.BiggerThan;
               case "Smaller than...":
                  return Memory.CompareType.SmallerThan;
               case "Value between...":
                  return Memory.CompareType.BetweenValues;
               case "Changed value":
                  return Memory.CompareType.ChangedValue;
               case "Unchanged value":
                  return Memory.CompareType.UnchangedValue;
               case "Unknown initial value":
                  return Memory.CompareType.UnknownInitialValue;
               default:
                  return Memory.CompareType.None;
            }
         }
         public static Type getValueTypeFromString(String str) {
            switch (str) {
               case "Byte":
                  return typeof(Byte);
               case "2 Bytes":
                  return typeof(UInt16);
               case "4 Bytes":
                  return typeof(UInt32);
               case "8 Bytes":
                  return typeof(UInt64);
               case "Float":
                  return typeof(Single);
               case "Double":
                  return typeof(Double);
               case "String":
                  return typeof(String);
               case "Array of bytes":
                  return typeof(Byte[]);
            }
            return null;
         }
      }
      private void setControlEnabled(Control[] arrControls, Boolean isEnabled) {
         foreach (Control cntrl in arrControls) {
            cntrl.Invoke(new Action(() => cntrl.Enabled = isEnabled));
         }
      }

      private ScanStatus _curScanStatus = ScanStatus.FirstScan;
      private ScanStatus curScanStatus
      {
         get {
            return _curScanStatus;
         }
         set {
            _curScanStatus = value;
            switch (value) {
               case ScanStatus.FirstScan: {
                  setControlEnabled(new Control[] { btnScan, chkBoxIsHexValue, txtBoxScanValue, cmbBoxScanType, cmbBoxValueType, chkListViewSearchSections, listViewResults, txtBoxSectionsFilter }, true);
                  setControlEnabled(new Control[] { btnScanNext }, false);
                  txtBoxScanValueSecond.Enabled = lblSecondValue.Enabled;
                  this.Invoke(new Action(() => uiToolStrip_linkPayloadAndProcess.Enabled = true));

                  String strBackupSelectedItem = (String)cmbBoxScanType.SelectedItem;
                  cmbBoxScanType.Invoke(new Action(() => cmbBoxScanType.DataSource = ScanTypeOptions.listSearch_FirstScan));
                  cmbBoxScanType.Invoke(new Action(() => cmbBoxScanType.SelectedItem = strBackupSelectedItem));

                  btnScan.Invoke(new Action(() => btnScan.Text = "First Scan"));
                  this.Invoke(new Action(() => uiStatusStrip_lblStatus.Text = "Standby..."));
               }
               break;
               case ScanStatus.DidScan: {
                  setControlEnabled(new Control[] { btnScan, btnScanNext, chkBoxIsHexValue, txtBoxScanValue, cmbBoxScanType, listViewResults }, true);
                  setControlEnabled(new Control[] { cmbBoxValueType, chkListViewSearchSections, txtBoxSectionsFilter }, false);
                  txtBoxScanValueSecond.Enabled = lblSecondValue.Enabled;
                  this.Invoke(new Action(() => uiToolStrip_linkPayloadAndProcess.Enabled = true));

                  String strBackupSelectedItem = (String)cmbBoxScanType.SelectedItem;
                  cmbBoxScanType.Invoke(new Action(() => cmbBoxScanType.DataSource = ScanTypeOptions.listSearch_NextScan));
                  cmbBoxScanType.Invoke(new Action(() => cmbBoxScanType.SelectedItem = strBackupSelectedItem));

                  btnScan.Invoke(new Action(() => btnScan.Text = "New Scan"));
               }
               break;
               case ScanStatus.Scanning: {
                  setControlEnabled(new Control[] { btnScan }, true);
                  setControlEnabled(new Control[] { btnScanNext, chkBoxIsHexValue, txtBoxScanValue, txtBoxScanValueSecond, cmbBoxScanType, cmbBoxValueType, chkListViewSearchSections, listViewResults, txtBoxSectionsFilter }, false);
                  this.Invoke(new Action(() => uiToolStrip_linkPayloadAndProcess.Enabled = false));

                  btnScan.Invoke(new Action(() => btnScan.Text = "Stop"));
                  this.Invoke(new Action(() => uiStatusStrip_lblStatus.Text = "Scanning..."));
               }
               break;
            }
         }
      }

      private librpc.ProcessInfo processInfo = null;
      private List<librpc.MemorySection> listProcessMemorySections = new List<librpc.MemorySection>();

      private Memory.CompareType scanCompareType = Memory.CompareType.ExactValue;
      private Type scanValueType = typeof(UInt32);

      public MainForm() {
         InitializeComponent();
         this.Text = String.Format("PlayEngine v{0}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
         cmbBoxValueType.SelectedIndex = 2; // 4 Bytes
         listViewResults.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
            .SetValue(listViewResults, true, null); // DoubleBuffer listview

         using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)) {
            try {
               IAsyncResult result = socket.BeginConnect(Settings.mInstance.ps4.IPAddress, librpc.PS4RPC.RPC_PORT, null, null);
               result.AsyncWaitHandle.WaitOne(1000);
               if (socket.Connected)
                  uiToolStrip_PayloadManager_chkPayloadActive.Checked = Memory.initPS4RPC(Settings.mInstance.ps4.IPAddress);

               socket.Shutdown(SocketShutdown.Both);
               socket.Close();
            } catch (Exception) { }
         }
         bgWorkerResultsUpdater.RunWorkerAsync();
      }
      private void MainForm_Load(Object sender, EventArgs e) {
         if (uiToolStrip_PayloadManager_chkPayloadActive.Checked)
            btnRefreshProcessList_OnClick();
      }

      #region Functions
      public void saveResult(String description, String strRuntimeAddress, librpc.MemorySection section, UInt32 sectionAddressOffset) {
         UInt64 runtimeAddress = Convert.ToUInt64(strRuntimeAddress, 16);
         var runtimeValue = Memory.read(processInfo.pid, runtimeAddress, scanValueType);

         DataGridViewRow row = dataGridSavedResults.Rows[dataGridSavedResults.Rows.Add()];
         row.Cells[SavedResultsColumnIndex.iDescription].Value = description;
         row.Cells[SavedResultsColumnIndex.iAddress].Value = runtimeAddress;
         row.Cells[SavedResultsColumnIndex.iSection].Value = section;
         row.Cells[SavedResultsColumnIndex.iValueType].Value = (String)cmbBoxValueType.SelectedItem;
         row.Cells[SavedResultsColumnIndex.iValue].Value = runtimeValue;

         CheatInformation cheatInformation = new CheatInformation();
         cheatInformation.sectionAddressOffset = sectionAddressOffset;
         row.Tag = cheatInformation;
      }
      #endregion

      #region Buttons
      private void btnScan_OnClick() {
         try {
            switch (curScanStatus) {
               case ScanStatus.FirstScan:
                  bgWorkerScanner.RunWorkerAsync(new Object[3] { txtBoxScanValue.Text, txtBoxScanValueSecond.Text, chkBoxIsHexValue.Checked });
                  break;
               case ScanStatus.DidScan:
                  listViewResults.Items.Clear();
                  curScanStatus = ScanStatus.FirstScan;
                  break;
               case ScanStatus.Scanning:
                  bgWorkerScanner.CancelAsync();
                  break;
            }
         } catch (Exception ex) {
            MessageBox.Show(ex.ToString(), "btnScan");
         }
      }
      private void btnScanNext_OnClick() {
         try {
            bgWorkerScanner.RunWorkerAsync(new Object[3] { txtBoxScanValue.Text, txtBoxScanValueSecond.Text, chkBoxIsHexValue.Checked });
         } catch (Exception ex) {
            MessageBox.Show(ex.ToString(), "btnScanNext");
         }
      }
      #region uiToolStrip_linkPayloadAndProcess
      private void btnSendPayload_OnClick() {
         if (new Forms.ChildForms.childFrmSendPayload().ShowDialog() == DialogResult.OK) {
            if (Memory.initPS4RPC(Settings.mInstance.ps4.IPAddress)) {
               uiToolStrip_PayloadManager_chkPayloadActive.Checked = true;
               btnRefreshProcessList_OnClick();
            }
         }
      }
      private void btnRefreshProcessList_OnClick() {
         try {
            uiToolStrip_ProcessManager_cmbBoxActiveProcess.Items.Clear();
            foreach (librpc.Process process in Memory.ps4RPC.GetProcessList().processes)
               uiToolStrip_ProcessManager_cmbBoxActiveProcess.Items.Add(process.name);
            uiToolStrip_ProcessManager_cmbBoxActiveProcess.SelectedIndex = 0;
         } catch (Exception ex) {
            MessageBox.Show(ex.ToString(), "Error during getting process list", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }
      #endregion
      #region uiStatusStrip_linkSavedResults
      private void btnAddAddress_OnClick() {
         // TODO: UI to add entries manually
      }
      #endregion
      #region contextMenuChkListBox
      private void contextMenuChkListBox_btnSelectAll_OnClick() {
         foreach (ListViewItem item in chkListViewSearchSections.Items)
            item.Checked = contextMenuChkListBox_btnSelectAll.Checked;
      }
      #endregion
      private void uiButtonHandler_Click(Object sender, EventArgs e) {
         String btnName = sender.GetType() == typeof(Button) ? (sender as Button).Name : (sender as ToolStripMenuItem).Name;
         switch (btnName) {
            case "btnScan":
               btnScan_OnClick();
               break;
            case "btnScanNext":
               btnScanNext_OnClick();
               break;
            #region uiToolStrip_linkFile
            case "uiToolStrip_btnExit":
               Application.Exit();
               break;
            #endregion
            #region uiToolStrip_linkPayloadAndProcess
            case "uiToolStrip_PayloadManager_btnSendPayload":
               btnSendPayload_OnClick();
               break;
            case "uiToolStrip_ProcessManager_btnRefreshProcessList":
               btnRefreshProcessList_OnClick();
               break;
            #endregion
            #region uiStatusStrip_linkSavedResuls
            case "uiStatusStrip_SavedResults_btnAddAddress":
               btnAddAddress_OnClick();
               break;
            #endregion
            #region contextMenuChkListBox
            case "contextMenuChkListBox_btnSelectAll":
               contextMenuChkListBox_btnSelectAll_OnClick();
               break;
               #endregion
         }
      }
      #endregion

      private void cmbBoxValueType_SelectedIndexChanged(Object sender, EventArgs e) {
         var newIndex = cmbBoxValueType.SelectedIndex;
         switch (newIndex) {
            case 0: // Byte
            case 1: // 2 Bytes
            case 2: // 4 Bytes
            case 3: // 8 Bytes
            case 4: // Float
            case 5: // Double
               if (curScanStatus == ScanStatus.FirstScan)
                  cmbBoxScanType.DataSource = ScanTypeOptions.listSearch_FirstScan;
               else
                  cmbBoxScanType.DataSource = ScanTypeOptions.listSearch_NextScan;
               break;
            case 6: // String
            case 7: // Array of bytes
               cmbBoxScanType.DataSource = ScanTypeOptions.listSearchExactOnly;
               break;
         }
         scanValueType = ScanTypeOptions.getValueTypeFromString((String)cmbBoxValueType.SelectedItem);
      }
      private void cmbBoxScanType_SelectedIndexChanged(Object sender, EventArgs e) {
         var newCompareType = ScanTypeOptions.getCompareTypeFromString((String)((sender as ComboBox).SelectedItem));
         scanCompareType = newCompareType;

         switch (newCompareType) {
            case Memory.CompareType.BetweenValues:
               lblSecondValue.Enabled = txtBoxScanValueSecond.Enabled = true;
               break;
            case Memory.CompareType.IncreasedValue:
            case Memory.CompareType.DecreasedValue:
            case Memory.CompareType.ChangedValue:
            case Memory.CompareType.UnchangedValue:
            case Memory.CompareType.UnknownInitialValue:
               lblSecondValue.Enabled = txtBoxScanValue.Enabled = txtBoxScanValueSecond.Enabled = false;
               break;
            default:
               txtBoxScanValue.Enabled = true;
               break;
         }
      }

      private void uiToolStrip_PayloadManager_chkPayloadActive_CheckedChanged(Object sender, EventArgs e) {
         Boolean isLoaded = uiToolStrip_PayloadManager_chkPayloadActive.Checked;
         splitContainerMain.Enabled = uiToolStrip_linkProcessManager.Enabled = isLoaded;
      }
      private void uiToolStrip_ProcessManager_cmbBoxActiveProcess_SelectedIndexChanged(Object sender, EventArgs e) {
         try {
            var comboBox = sender as ToolStripComboBox;
            if (comboBox.SelectedIndex < 1) {
               comboBox.SelectedIndex = 1;
               return;
            }
            String selectedProcessName = (String)uiToolStrip_ProcessManager_cmbBoxActiveProcess.SelectedItem;
            curScanStatus = ScanStatus.FirstScan;
            chkListViewSearchSections.Items.Clear();

            processInfo = Memory.getProcessInfoFromName(selectedProcessName);

            contextMenuChkListBox_btnSelectAll.Checked = false; listProcessMemorySections.Clear();
            foreach (var memorySection in Memory.Sections.getMemorySections(processInfo)) {
               listProcessMemorySections.Add(memorySection);

               ListViewItem listViewItem = new ListViewItem();
               listViewItem.Tag = memorySection;
               listViewItem.Text = memorySection.name;
               listViewItem.SubItems.Add(memorySection.offset.ToString("X"));
               listViewItem.SubItems.Add((memorySection.length / 1024).ToString() + "KB");
               listViewItem.SubItems.Add(memorySection.protection.ToString());
               chkListViewSearchSections.Items.Add(listViewItem);
            }
            uiToolStrip_lblActiveProcess.Text = String.Format("Process: {0}", selectedProcessName);
            //uiToolStrip_btnOpenPointerScanner.Enabled = true;
         } catch (Exception exception) {
            MessageBox.Show(exception.ToString());
         }
      }

      private void txtBoxSectionsFilter_TextChanged(Object sender, EventArgs e) {
         contextMenuChkListBox_btnSelectAll.Checked = false;
         chkListViewSearchSections.Items.Clear();
         chkListViewSearchSections.Items.AddRange(listProcessMemorySections
            .Where(section => String.IsNullOrEmpty(txtBoxSectionsFilter.Text) || section.name.Contains(txtBoxSectionsFilter.Text, StringComparison.InvariantCultureIgnoreCase))
            .Select(section => {
               ListViewItem listViewItem = new ListViewItem();
               listViewItem.Tag = section;
               listViewItem.Text = section.name;
               listViewItem.SubItems.Add(section.offset.ToString("X"));
               listViewItem.SubItems.Add((section.length / 1024).ToString() + "KB");
               listViewItem.SubItems.Add(section.protection.ToString());
               return listViewItem;
            }).ToArray());
      }

      private void listViewResults_SaveSelectedEntries() {
         foreach (ListViewItem selectedEntry in listViewResults.SelectedItems) {
            String sectionName = selectedEntry.SubItems[1].Text;
            UInt32 sectionAddressOffset = (UInt32)selectedEntry.Tag;
            saveResult("No description", selectedEntry.Text, listProcessMemorySections.First(section => section.ToString() == sectionName), sectionAddressOffset);
         }
      }
      private void listViewResults_DoubleClick(Object sender, EventArgs e) {
         listViewResults_SaveSelectedEntries();
      }

      private void dataGridSavedResults_CellDoubleClick(Object sender, DataGridViewCellEventArgs e) {
         var cells = dataGridSavedResults.Rows[e.RowIndex].Cells;
         var cheatInformation = (CheatInformation)dataGridSavedResults.Rows[e.RowIndex].Tag;
         var frmEditInstance = new ChildForms.childFrmEditCheat(
            listProcessMemorySections,
            (String)cells[SavedResultsColumnIndex.iDescription].Value,
            (librpc.MemorySection)cells[SavedResultsColumnIndex.iSection].Value,
            cheatInformation.sectionAddressOffset,
            (String)cells[SavedResultsColumnIndex.iValueType].Value,
            cells[SavedResultsColumnIndex.iValue].Value.ToString()
         );
         if (frmEditInstance.ShowDialog() == DialogResult.OK) {
            var returnInformation = frmEditInstance.returnInformation;
            cells[SavedResultsColumnIndex.iDescription].Value = returnInformation.description;
            cells[SavedResultsColumnIndex.iSection].Value = returnInformation.section;
            cheatInformation.sectionAddressOffset = returnInformation.sectionAddressOffset;
            cells[SavedResultsColumnIndex.iValueType].Value = returnInformation.valueType;
            cells[SavedResultsColumnIndex.iValue].Value = returnInformation.value;

            UInt64 runtimeAddress = returnInformation.section.start + returnInformation.sectionAddressOffset;
            Type varType = ScanTypeOptions.getValueTypeFromString(returnInformation.valueType);
            Memory.write(
               processInfo.pid,
               runtimeAddress,
               Convert.ChangeType(returnInformation.value, varType),
               varType
            );
         }
      }

      #region OnKeyDown
      private void uiKeyDownHandler(Object sender, KeyEventArgs e) {
         String controlName = (sender as Control).Name;
         switch (e.KeyCode) {
            case Keys.A: {
               switch (controlName) {
                  case "listViewResults": {
                     if (e.Control) {
                        foreach (ListViewItem item in listViewResults.Items)
                           item.Selected = true;
                        e.SuppressKeyPress = true;
                     }
                  }
                  break;
               }
            }
            break;
            case Keys.Enter: {
               switch (controlName) {
                  case "listViewResults":
                     listViewResults_SaveSelectedEntries();
                     break;
                  case "txtBoxScanValue":
                  case "txtBoxScanValueSecond":
                     if (curScanStatus == ScanStatus.FirstScan)
                        btnScan_OnClick();
                     else if (curScanStatus == ScanStatus.DidScan)
                        btnScanNext_OnClick();
                     e.SuppressKeyPress = true;
                     break;
               }
            }
            break;
         }
      }
      #endregion

      #region Background Workers
      #region bgWorkerScanner
      private unsafe void bgWorkerScanner_DoWork(Object sender, DoWorkEventArgs e) {
         var oldScanStatus = curScanStatus;
         curScanStatus = ScanStatus.Scanning;

         String[] scanValues = new String[2] { (String)((Object[])e.Argument)[0], (String)((Object[])e.Argument)[1] };
         bgWorkerScanner.ReportProgress(0);

         // Process checks
         List<librpc.MemorySection> searchSections = new List<librpc.MemorySection>();
         chkListViewSearchSections.Invoke(new Action(() =>
         {
            foreach (ListViewItem item in chkListViewSearchSections.CheckedItems)
               searchSections.Add((librpc.MemorySection)item.Tag);
         }));
         bgWorkerScanner.ReportProgress(5);
         Int32 processedMemoryRange = 0, totalMemoryRange = 0;
         foreach (var section in searchSections)
            totalMemoryRange += section.length;

         foreach (var searchSection in searchSections) {
            if (bgWorkerScanner.CancellationPending) {
               e.Cancel = true;
               break;
            }
            // Per section scan limits
            UInt64 maxResultCount = 1000, curResultCount = 0;

            dynamic scanValue = null;
            Byte[] scanValueBuffer = null;
            if (scanValueType == typeof(Byte[])) {
               List<Byte> listBytes = new List<Byte>();
               foreach (String strByte in scanValues[0].Split(' '))
                  listBytes.Add(Convert.ToByte(strByte, 16));
               scanValueBuffer = listBytes.ToArray();
            } else {
               scanValue = Convert.ChangeType(scanValues[0], scanValueType);
               scanValueBuffer = ((Object)scanValue).getBytes(scanValueType);
            }

            if (oldScanStatus == ScanStatus.FirstScan) {
               listViewResults.Invoke(new Action(() => uiStatusStrip_lblStatus.Text = String.Format("Scanning {0}", searchSection.name)));
               List<UInt32> results = Memory.scan(
                     Memory.readByteArray(processInfo.pid, searchSection.start, searchSection.length),
                     scanValueBuffer,
                     scanValueType,
                     scanCompareType,
                     new dynamic[2] { Convert.ChangeType(scanValues[0], scanValueType), Convert.ChangeType(scanValues[1], scanValueType) }
                  );
               listViewResults.Invoke(new Action(() => uiStatusStrip_lblStatus.Text = String.Format("Scanned {0}: {1} results found", searchSection.name, results.Count)));
               foreach (UInt32 sectionAddressOffset in results) {
                  if (curResultCount > maxResultCount)
                     break;
                  UInt64 runtimeAddress = searchSection.start + sectionAddressOffset;

                  ListViewItem listViewItem = new ListViewItem();
                  // Section Offset
                  listViewItem.Tag = sectionAddressOffset;
                  // Address
                  listViewItem.Text = runtimeAddress.ToString("X");
                  // Section
                  listViewItem.SubItems.Add(searchSection.ToString());
                  // Value
                  listViewItem.SubItems.Add(Memory.read(processInfo.pid, runtimeAddress, scanValueType).ToString());

                  curResultCount++;
                  listViewResults.Invoke(new Action(() => listViewResults.Items.Add(listViewItem)));
                  if (bgWorkerScanner.CancellationPending)
                     break;
               }
            } else if (oldScanStatus == ScanStatus.DidScan) {
               listViewResults.Invoke(new Action(() =>
               {
                  List<ListViewItem> results = new List<ListViewItem>();
                  foreach (ListViewItem item in listViewResults.Items) {
                     UInt64 address = Convert.ToUInt64(item.Text, 16);
                     if (Memory.CompareUtil.compare(scanValue, Memory.read(processInfo.pid, address, scanValueType), scanCompareType,
                        new dynamic[2] { Convert.ChangeType(scanValues[0], scanValueType), Convert.ChangeType(scanValues[1], scanValueType) })) {
                        ListViewItem listViewItem = new ListViewItem();
                           // Section Offset
                           listViewItem.Tag = item.Tag;
                           // Address
                           listViewItem.Text = item.Text;
                           // Section
                           listViewItem.SubItems.Add(item.SubItems[0]);
                           // Value
                           listViewItem.SubItems.Add(Memory.read(processInfo.pid, address, scanValueType).ToString());
                        results.Add(listViewItem);
                     }
                  }
                  listViewResults.Items.Clear();
                  listViewResults.Items.AddRange(results.ToArray());
               }));
               break;
            }

            processedMemoryRange += searchSection.length;
            bgWorkerScanner.ReportProgress(Convert.ToInt32(
               (processedMemoryRange / (Double)totalMemoryRange) * 100));
         }
         bgWorkerScanner.ReportProgress(100);
      }
      private void bgWorkerScanner_ProgressChanged(Object sender, ProgressChangedEventArgs e) {
         progressBarScanPercent.Value = Math.Min(e.ProgressPercentage, 100);
      }
      private void bgWorkerScanner_RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs e) {
         uiStatusStrip_lblStatus.Text = String.Format("{0} results", listViewResults.Items.Count);
         curScanStatus = ScanStatus.DidScan;
         if (e.Error != null)
            uiStatusStrip_lblStatus.Text = e.Error.Message;
      }
      #endregion
      #region bgWorkerResultsUpdater
      private void bgWorkerResultsUpdater_DoWork(Object sender, DoWorkEventArgs e) {
         while (true) {
            Thread.Sleep(1000);
            dataGridSavedResults.Invoke(new Action(() =>
            {
               foreach (DataGridViewRow row in dataGridSavedResults.Rows) {
                  var runtimeValue = Memory.read(
                  processInfo.pid,
                  (UInt64)row.Cells[SavedResultsColumnIndex.iAddress].Value,
                  ScanTypeOptions.getValueTypeFromString((String)row.Cells[SavedResultsColumnIndex.iValueType].Value)
               );
                  dataGridSavedResults.Rows[row.Index].Cells[SavedResultsColumnIndex.iValue].Value = runtimeValue;
               }
            }));
         }
      }
      #endregion

      #endregion
   }
}
