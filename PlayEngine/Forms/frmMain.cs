using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

using PlayEngine.Helpers;
using PlayEngine.Helpers.CheatManager;

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
      public class ScanResult : INotifyPropertyChanged {
         public event PropertyChangedEventHandler PropertyChanged;
         private void setField<T>(ref T field, T value, String propertyName) {
            if (EqualityComparer<T>.Default.Equals(field, value))
               return;
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
         }

         private UInt64 _address;
         private librpc.MemorySection _memorySection;
         private UInt32 _memorySectionOffset;
         private dynamic _oldMemoryValue;
         private dynamic _memoryValue;

         public UInt64 address
         {
            get { return _address; }
            set { setField(ref _address, value, "address"); }
         }
         public librpc.MemorySection memorySection
         {
            get { return _memorySection; }
            set { setField(ref _memorySection, value, "memorysection"); }
         }
         public UInt32 memorySectionOffset
         {
            get { return _memorySectionOffset; }
            set { setField(ref _memorySectionOffset, value, "memorySectionOffset"); }
         }
         public dynamic oldMemoryValue
         {
            get { return _oldMemoryValue; }
            set { setField(ref _oldMemoryValue, value, "oldMemoryValue"); }
         }
         public dynamic memoryValue
         {
            get { return _memoryValue; }
            set { setField(ref _memoryValue, value, "memoryValue"); }
         }
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
         public static Type getValueTypeFromString(String strValueType, Boolean returnSignedType = false) {
            switch (strValueType) {
               case "Byte":
                  return returnSignedType ? typeof(SByte) : typeof(Byte);
               case "2 Bytes":
                  return returnSignedType ? typeof(Int16) : typeof(UInt16);
               case "4 Bytes":
                  return returnSignedType ? typeof(Int32) : typeof(UInt32);
               case "8 Bytes":
                  return returnSignedType ? typeof(Int64) : typeof(UInt64);
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
                  setControlEnabled(new Control[] { btnScan, txtBoxScanValue, cmbBoxScanType, cmbBoxValueType, chkListViewSearchSections, listViewResults, txtBoxSectionsFilter }, true);
                  setControlEnabled(new Control[] { btnScanNext }, false);
                  chkBoxIsHexValue.Enabled = scanValueType != typeof(String) || scanValueType != typeof(Byte[]);
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
                  chkBoxIsHexValue.Enabled = scanValueType != typeof(String) || scanValueType != typeof(Byte[]);
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
         this.Text = $"PlayEngine v{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()}";
         cmbBoxValueType.SelectedIndex = 2; // 4 Bytes
         listViewResults.ListViewItemSorter = null;

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
      public void saveResult(String description, UInt64 runtimeAddress, librpc.MemorySection section, UInt32 sectionAddressOffset) {
         var runtimeValue = Memory.read(processInfo.pid, runtimeAddress, scanValueType);

         DataGridViewRow row = dataGridSavedResults.Rows[dataGridSavedResults.Rows.Add()];
         row.Cells[SavedResultsColumnIndex.iDescription].Value = description;
         row.Cells[SavedResultsColumnIndex.iAddress].Value = runtimeAddress;
         row.Cells[SavedResultsColumnIndex.iSection].Value = section;
         row.Cells[SavedResultsColumnIndex.iValueType].Value = scanValueType;
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
         chkListViewSearchSections.CheckObjects(chkListViewSearchSections.Objects);
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
         listViewResults.Items.Clear();
         var newIndex = cmbBoxValueType.SelectedIndex;
         switch (newIndex) {
            case 0: // Byte
            case 1: // 2 Bytes
            case 2: // 4 Bytes
            case 3: // 8 Bytes
            case 4: // Float
            case 5: // Double
               chkBoxIsHexValue.Enabled = true;
               if (curScanStatus == ScanStatus.FirstScan)
                  cmbBoxScanType.DataSource = ScanTypeOptions.listSearch_FirstScan;
               else
                  cmbBoxScanType.DataSource = ScanTypeOptions.listSearch_NextScan;
               break;
            case 6: // String
            case 7: // Array of bytes
               chkBoxIsHexValue.Checked = false;
               chkBoxIsHexValue.Enabled = false;
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
            listProcessMemorySections.AddRange(Memory.Sections.getMemorySections(processInfo));
            chkListViewSearchSections.AddObjects(listProcessMemorySections);
            uiToolStrip_lblActiveProcess.Text = $"Process: {selectedProcessName}";
            //uiToolStrip_btnOpenPointerScanner.Enabled = true;
         } catch (Exception exception) {
            MessageBox.Show(exception.ToString());
         }
      }

      private void txtBoxSectionsFilter_TextChanged(Object sender, EventArgs e) {
         contextMenuChkListBox_btnSelectAll.Checked = false;
         chkListViewSearchSections.Items.Clear();
         chkListViewSearchSections.AddObjects(listProcessMemorySections
            .Where(section => String.IsNullOrEmpty(txtBoxSectionsFilter.Text) || section.name.Contains(txtBoxSectionsFilter.Text, StringComparison.InvariantCultureIgnoreCase)).ToArray());
      }

      private void listViewResults_FormatCell(Object sender, BrightIdeasSoftware.FormatCellEventArgs e) {
         ScanResult scanResult = (ScanResult)e.Model;
         if (scanResult.oldMemoryValue != scanResult.memoryValue) {
            e.SubItem.ForeColor = Color.Red;
            e.Item.SelectedForeColor = Color.Black;
         }
      }
      private void listViewResults_SaveSelectedEntries() {
         foreach (ScanResult scanResult in listViewResults.SelectedObjects) {
            saveResult("No description", scanResult.address, scanResult.memorySection, scanResult.memorySectionOffset);
         }
      }
      private void listViewResults_DoubleClick(Object sender, EventArgs e) {
         listViewResults_SaveSelectedEntries();
      }

      private void dataGridSavedResults_CellDoubleClick(Object sender, DataGridViewCellEventArgs e) {
         if (e.RowIndex < 0)
            return;
         var cells = dataGridSavedResults.Rows[e.RowIndex].Cells;
         var cheatInformation = (CheatInformation)dataGridSavedResults.Rows[e.RowIndex].Tag;
         var frmEditInstance = new ChildForms.childFrmEditCheatEntry(
            listProcessMemorySections,
            (String)cells[SavedResultsColumnIndex.iDescription].Value,
            (librpc.MemorySection)cells[SavedResultsColumnIndex.iSection].Value,
            cheatInformation.sectionAddressOffset,
            (Type)cells[SavedResultsColumnIndex.iValueType].Value,
            cells[SavedResultsColumnIndex.iValue].Value.ToString(),
            e.ColumnIndex
         );
         if (frmEditInstance.ShowDialog() == DialogResult.OK) {
            var returnInformation = frmEditInstance.returnInformation;
            UInt64 runtimeAddress = returnInformation.section.start + returnInformation.sectionAddressOffset;
            cells[SavedResultsColumnIndex.iDescription].Value = returnInformation.description;
            cells[SavedResultsColumnIndex.iAddress].Value = runtimeAddress;
            cells[SavedResultsColumnIndex.iSection].Value = returnInformation.section;
            cheatInformation.sectionAddressOffset = returnInformation.sectionAddressOffset;
            cells[SavedResultsColumnIndex.iValueType].Value = returnInformation.valueType;
            cells[SavedResultsColumnIndex.iValue].Value = returnInformation.value;

            Memory.write(
               processInfo.pid,
               runtimeAddress,
               Convert.ChangeType(returnInformation.value, returnInformation.valueType),
               returnInformation.valueType
            );
         }
      }

      #region OnKeyDown
      private void uiKeyDownHandler(Object sender, KeyEventArgs e) {
         String controlName = (sender as Control).Name;
         switch (e.KeyCode) {
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
         listViewResults.Invoke(new Action(() => listViewResults.BeginUpdate()));
         var oldScanStatus = curScanStatus;
         curScanStatus = ScanStatus.Scanning;

         Boolean isHexValue = (Boolean)((Object[])e.Argument)[2];
         String[] strScanValues = new String[2] { (String)((Object[])e.Argument)[0], (String)((Object[])e.Argument)[1] };
         bgWorkerScanner.ReportProgress(0);
         if (String.IsNullOrWhiteSpace(strScanValues[0]) || (scanCompareType == Memory.CompareType.BetweenValues && String.IsNullOrWhiteSpace(strScanValues[1]))) {
            e.Cancel = true;
            return;
         }

         // Process checks
         List<librpc.MemorySection> searchSections = new List<librpc.MemorySection>();
         chkListViewSearchSections.Invoke(new Action(() =>
         {
            foreach (librpc.MemorySection section in chkListViewSearchSections.CheckedObjects)
               searchSections.Add(section);
         }));
         if (searchSections.Count == 0) {
            e.Cancel = true;
            return;
         }
         bgWorkerScanner.ReportProgress(5);

         Int32 processedMemoryRange = 0, totalMemoryRange = 1;
         foreach (var section in searchSections)
            totalMemoryRange += section.length;

         dynamic[] scanValues = new dynamic[2];
         if (scanValueType == typeof(Byte[])) {
            List<Byte> listBytes = new List<Byte>();
            foreach (String strByte in strScanValues[0].Split(' '))
               listBytes.Add(Convert.ToByte(strByte, 16));
            scanValues[0] = listBytes.ToArray();
         } else {
            try {
               if (isHexValue) {
                  var dicHexCast = new Dictionary<Type, Func<String, dynamic>>
                  {
                      { typeof(Byte),   val => Byte.Parse(val, NumberStyles.HexNumber) },
                      { typeof(SByte),  val => SByte.Parse(val, NumberStyles.HexNumber) },
                      { typeof(Int16),  val => Int16.Parse(val, NumberStyles.HexNumber) },
                      { typeof(UInt16), val => UInt16.Parse(val, NumberStyles.HexNumber) },
                      { typeof(Int32),  val => Int32.Parse(val, NumberStyles.HexNumber) },
                      { typeof(UInt32), val => UInt32.Parse(val, NumberStyles.HexNumber) },
                      { typeof(Int64),  val => Int64.Parse(val, NumberStyles.HexNumber) },
                      { typeof(UInt64), val => UInt64.Parse(val, NumberStyles.HexNumber) },
                      { typeof(Single), val => Single.Parse(val, NumberStyles.HexNumber) },
                      { typeof(Double), val => Double.Parse(val, NumberStyles.HexNumber) }
                  };
                  scanValues[0] = dicHexCast[scanValueType](strScanValues[0]);
                  scanValues[1] = dicHexCast[scanValueType](strScanValues[1]);
               } else {
                  scanValues[0] = Convert.ChangeType(strScanValues[0], scanValueType);
                  scanValues[1] = Convert.ChangeType(strScanValues[1], scanValueType);
               }
            } catch (OverflowException) {
               String strScanValueType = String.Empty;
               cmbBoxValueType.Invoke(new Action(() => strScanValueType = (String)cmbBoxValueType.SelectedItem));
               scanValueType = ScanTypeOptions.getValueTypeFromString(strScanValueType, true);
               scanValues[0] = Convert.ChangeType(strScanValues[0], scanValueType);
               scanValues[1] = Convert.ChangeType(strScanValues[1], scanValueType);
            }
         }

         foreach (var searchSection in searchSections) {
            if (bgWorkerScanner.CancellationPending) {
               e.Cancel = true;
               break;
            }
            // Per section scan limits
            UInt64 maxResultCount = 1000, curResultCount = 0;

            if (oldScanStatus == ScanStatus.FirstScan) {
               listViewResults.Invoke(new Action(() => uiStatusStrip_lblStatus.Text = $"Scanning {searchSection.name}"));
               List<Tuple<UInt32, dynamic>> results = Memory.scan(
                     Memory.readByteArray(processInfo.pid, searchSection.start, searchSection.length),
                     scanValues[0],
                     scanValueType,
                     scanCompareType,
                     new dynamic[2] { scanValues[0], scanValues[1] }
                  );
               listViewResults.Invoke(new Action(() => uiStatusStrip_lblStatus.Text = $"Scanned {searchSection.name}: {results.Count} results found"));

               List<ScanResult> scanResults = new List<ScanResult>();
               foreach (var tuple in results) {
                  if (curResultCount > maxResultCount)
                     break;
                  UInt64 runtimeAddress = searchSection.start + tuple.Item1;
                  ScanResult scanResult = new ScanResult()
                  {
                     address = runtimeAddress,
                     memorySection = searchSection,
                     memorySectionOffset = tuple.Item1,
                     memoryValue = tuple.Item2,
                     oldMemoryValue = tuple.Item2
                  };

                  curResultCount++;
                  scanResults.Add(scanResult);
                  if (bgWorkerScanner.CancellationPending)
                     break;
               }
               listViewResults.Invoke(new Action(() =>
               {
                  uiStatusStrip_lblStatus.Text = $"Adding {scanResults.Count} from {searchSection.name}";
                  listViewResults.AddObjects(scanResults);
               }));
            } else if (oldScanStatus == ScanStatus.DidScan) {
               List<ScanResult> results = new List<ScanResult>();
               foreach (ScanResult scanResult in listViewResults.Objects) {
                  dynamic memoryValue = Memory.read(processInfo.pid, scanResult.address, scanValueType);
                  if (Memory.CompareUtil.compare(scanValues[0], memoryValue, scanCompareType, new dynamic[2] { scanValues[0], scanValues[1] })) {
                     scanResult.oldMemoryValue = scanResult.memoryValue = memoryValue;
                     results.Add(scanResult);
                  }
               }
               listViewResults.Invoke(new Action(() => listViewResults.SetObjects(results)));
               break;
            }

            processedMemoryRange += searchSection.length;
            bgWorkerScanner.ReportProgress(Convert.ToInt32(
               ((Double)processedMemoryRange / (Double)totalMemoryRange) * 100));
         }
         bgWorkerScanner.ReportProgress(100);
      }
      private void bgWorkerScanner_ProgressChanged(Object sender, ProgressChangedEventArgs e) {
         progressBarScanPercent.Value = Math.Max(0, Math.Min(e.ProgressPercentage, 100));
      }
      private void bgWorkerScanner_RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs e) {
         listViewResults.EndUpdate();
         uiStatusStrip_lblStatus.Text = $"{listViewResults.Items.Count} results";
         curScanStatus = ScanStatus.DidScan;
         if (e.Error != null)
            uiStatusStrip_lblStatus.Text = e.Error.Message;
      }
      #endregion
      #region bgWorkerResultsUpdater
      private void bgWorkerResultsUpdater_DoWork(Object sender, DoWorkEventArgs e) {
         while (true) {
            Thread.Sleep(1000);
            // Scan results
            listViewResults.Invoke(new Action(() =>
            {
               for (Int32 i = listViewResults.TopItemIndex; i < listViewResults.TopItemIndex + 20; i++) {
                  ScanResult scanResult = (ScanResult)listViewResults.GetModelObject(i);
                  if (scanResult != null) {
                     dynamic runtimeValue = Memory.read(
                        processInfo.pid,
                        scanResult.address,
                        scanValueType
                     );
                     scanResult.memoryValue = runtimeValue;
                  }
               }
            }));

            // Saved results
            dataGridSavedResults.Invoke(new Action(() =>
            {
               foreach (DataGridViewRow row in dataGridSavedResults.Rows) {
                  var runtimeValue = Memory.read(
                     processInfo.pid,
                     (UInt64)row.Cells[SavedResultsColumnIndex.iAddress].Value,
                     (Type)row.Cells[SavedResultsColumnIndex.iValueType].Value
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
