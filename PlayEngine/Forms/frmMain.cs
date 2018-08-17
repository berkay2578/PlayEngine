/*
   PlayEngine - Cheat Engine for the PS4

   MIT License
   
   Copyright (c) 2018 Berkay Yigit
   
   Permission is hereby granted, free of charge, to any person obtaining a copy
   of this software and associated documentation files (the "Software"), to deal
   in the Software without restriction, including without limitation the rights
   to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
   copies of the Software, and to permit persons to whom the Software is
   furnished to do so, subject to the following conditions:
   
   The above copyright notice and this permission notice shall be included in all
   copies or substantial portions of the Software.
   
   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
   IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
   FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
   AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
   LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
   OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
   SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

using PlayEngine.Helpers;
using PlayEngine.Helpers.CheatManager;
using PlayEngine.Helpers.CheatManager.CheatTable;
using PlayEngine.Helpers.CheatManager.CheatTable.Objects;
using PlayEngine.Helpers.MemoryClasses.ScanCompareTypes;
using PlayEngine.Helpers.MemoryClasses.ScanValueTypes;

namespace PlayEngine.Forms {
   public partial class MainForm : Form {
      public class ScanResult : IEquatable<ScanResult>, INotifyPropertyChanged {
         public event PropertyChangedEventHandler PropertyChanged;
         private void setField<T>(ref T field, T value, String propertyName) {
            if (EqualityComparer<T>.Default.Equals(field, value))
               return;
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
         }

         public librpc.MemorySection memorySection;
         public UInt32 sectionOffset
         {
            get { return (UInt32)(_address - memorySection.start); }
         }

         private UInt64 _address;
         public UInt64 address
         {
            get { return _address; }
            set { setField(ref _address, value, "address"); }
         }

         private Type _valueType;
         public Type valueType
         {
            get { return _valueType; }
            set { setField(ref _valueType, value, "valueType"); }
         }
         private dynamic _memoryValue;
         public dynamic memoryValue
         {
            get { return _memoryValue; }
            set { setField(ref _memoryValue, value, "memoryValue"); }
         }
         private dynamic _previousMemoryValue;
         public dynamic previousMemoryValue
         {
            get { return _previousMemoryValue; }
            set { setField(ref _previousMemoryValue, value, "previousMemoryValue"); }
         }

         public Boolean Equals(ScanResult other) {
            if (other == null)
               return false;

            return this.address == other.address;
         }
         public override Int32 GetHashCode() {
            return address.GetHashCode();
         }
      }
      public class ScanOptions {
         public String strScanValue;
         public String strScanSecondValue;
         public Boolean isHexValue;
         public String strSectionNameInclusionFilter;
         public String strSectionNameExclusionFilter;
         public librpc.VM_PROT sectionPageProtectionFilter;
         public Int32 sectionMaxLengthFilter;
      }

      private void setControlEnabled(Control[] arrControls, Boolean isEnabled) {
         foreach (Control cntrl in arrControls) {
            cntrl.Invoke(new Action(() => cntrl.Enabled = isEnabled));
         }
      }
      private String getSizeStr(UInt64 sizeInBytes) {
         UInt64 KB = 1024, MB = KB * 1024, GB = MB * 1024, TB = GB * 1024;
         Double size = sizeInBytes;
         String suffix = "B";

         if (sizeInBytes >= TB) {
            size = Math.Round(size / TB, 2);
            suffix = "TB";
         } else if (sizeInBytes >= GB) {
            size = Math.Round(size / GB, 2);
            suffix = "GB";
         } else if (sizeInBytes >= MB) {
            size = Math.Round(size / MB, 2);
            suffix = "MB";
         } else if (sizeInBytes >= KB) {
            size = Math.Round(size / KB, 2);
            suffix = "KB";
         }

         return $"{size}{suffix}";
      }

      private IScanCompareType currentScanCompareType = CompareTypeExactValue.mSelf;
      private IScanValueType currentScanValueType = ValueType4Bytes.mSelf;
      private Memory.ScanStatus currentScanStatus
      {
         get {
            return Memory.currentScanStatus;
         }
         set {
            Memory.currentScanStatus = value;
            switch (value) {
               case Memory.ScanStatus.CantScan: {
                  setControlEnabled(new Control[] { splitContainerMain }, false);
                  uiToolStrip.Invoke(new Action(() => uiToolStrip_linkPayloadAndProcess.Enabled = true));
                  uiToolStrip.Invoke(new Action(() => uiToolStrip_linkTools.Enabled = true));
               }
               break;
               case Memory.ScanStatus.CanScan: {
                  setControlEnabled(new Control[] { btnScan, panelScanControls, cmbBoxScanValueType, panelSectionSearchOptions, listViewResults, splitContainerMain }, true);
                  setControlEnabled(new Control[] { btnScanNext, btnScanUndo }, false);
                  uiToolStrip.Invoke(new Action(() => uiToolStrip_linkPayloadAndProcess.Enabled = true));

                  cmbBoxScanValueType.Invoke(new Action(() => cmbBoxScanCompareType.DataSource = currentScanValueType.supportedFirstScanCompareTypes));
                  btnScan.Invoke(new Action(() => btnScan.Text = "First Scan"));
                  uiStatusStrip.Invoke(new Action(() => uiStatusStrip_lblStatus.Text = "Standby..."));
                  uiStatusStrip.Invoke(new Action(() => uiStatusStrip_progressBarScanPercent.Value = 0));
               }
               break;
               case Memory.ScanStatus.DidScan: {
                  setControlEnabled(new Control[] { btnScan, btnScanNext, panelScanControls, listViewResults }, true);
                  setControlEnabled(new Control[] { cmbBoxScanValueType, panelSectionSearchOptions }, false);
                  uiToolStrip.Invoke(new Action(() => uiToolStrip_linkPayloadAndProcess.Enabled = true));

                  cmbBoxScanValueType.Invoke(new Action(() => cmbBoxScanCompareType.DataSource = currentScanValueType.supportedNextScanCompareTypes));
                  btnScan.Invoke(new Action(() => btnScan.Text = "New Scan"));
               }
               break;
               case Memory.ScanStatus.Scanning: {
                  setControlEnabled(new Control[] { btnScan }, true);
                  setControlEnabled(new Control[] { btnScanNext, btnScanUndo, panelScanControls, panelSectionSearchOptions, listViewResults }, false);
                  uiToolStrip.Invoke(new Action(() => uiToolStrip_linkPayloadAndProcess.Enabled = false));

                  btnScan.Invoke(new Action(() => btnScan.Text = "Stop"));
                  uiStatusStrip.Invoke(new Action(() => uiStatusStrip_lblStatus.Text = "Scanning..."));
               }
               break;
            }
         }
      }

      private List<librpc.MemorySection> listFilteredProcessMemorySections = new List<librpc.MemorySection>();
      private List<ScanResult> listPreviousScanResults = new List<ScanResult>();
      private List<ScanResult> listScanResults = new List<ScanResult>();

      public MainForm() {
         InitializeComponent();
         // Title
         this.Text = $"PlayEngine v{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()}";
         // ComboBox items
         cmbBoxSectionsFilterProtection.Items.AddRange(Enum.GetNames(typeof(librpc.VM_PROT)));
         cmbBoxScanValueType.Items.AddRange(new dynamic[] {
            ValueType1Byte.mSelf,
            ValueType2Bytes.mSelf,
            ValueType4Bytes.mSelf,
            ValueType8Bytes.mSelf,
            ValueTypeFloat.mSelf,
            ValueTypeDouble.mSelf,
            ValueTypeString.mSelf,
            ValueTypeArrayOfBytes.mSelf
         });
         // ComboBox selection
         cmbBoxSectionsFilterProtection.SelectedItem = librpc.VM_PROT.RW.ToString();
         cmbBoxScanValueType.SelectedItem = ValueType4Bytes.mSelf;
         // Check for existing jkpatch
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
      }
      private void MainForm_Load(Object sender, EventArgs e) {
         if (uiToolStrip_PayloadManager_chkPayloadActive.Checked)
            btnRefreshProcessList_OnClick();
         txtBoxScanValue.Select();
         // Run threads
         bgWorkerResultsUpdater.RunWorkerAsync();
         bgWorkerValueFreezer.RunWorkerAsync();
      }

      #region Functions
      public void saveResult(String _description, librpc.MemorySection _memorySection, UInt32 sectionOffset, Type _valueType, dynamic _value, UInt64 _address = 0) {
         listViewSavedResults.AddObject(new CheatInformation()
         {
            address = _address,
            description = _description,
            memorySection = _memorySection,
            sectionOffset = sectionOffset,
            valueType = _valueType,
            value = _value
         });
      }
      #endregion

      #region Buttons
      private void btnScan_OnClick() {
         try {
            switch (currentScanStatus) {
               case Memory.ScanStatus.CanScan:
                  ScanOptions scanOptions = new ScanOptions()
                  {
                     strScanValue = txtBoxScanValue.Text,
                     strScanSecondValue = txtBoxScanSecondValue.Text,
                     isHexValue = chkBoxIsHexValue.Checked,
                     strSectionNameInclusionFilter = txtBoxSectionsFilterInclude.Text,
                     strSectionNameExclusionFilter = txtBoxSectionsFilterExclude.Text,
                     sectionPageProtectionFilter = (librpc.VM_PROT)Enum.Parse(typeof(librpc.VM_PROT), (String)cmbBoxSectionsFilterProtection.SelectedItem),
                     sectionMaxLengthFilter = Convert.ToInt32(numUpDownSectionMaxLength.Value)
                  };
                  bgWorkerScanner.RunWorkerAsync(scanOptions);
                  break;
               case Memory.ScanStatus.DidScan:
                  listViewResults.Items.Clear();
                  currentScanStatus = Memory.ScanStatus.CanScan;
                  break;
               case Memory.ScanStatus.Scanning:
                  bgWorkerScanner.CancelAsync();
                  break;
            }
         } catch (Exception ex) {
            MessageBox.Show(ex.ToString(), "btnScan");
         }
      }
      private void btnScanNext_OnClick() {
         try {
            ScanOptions scanOptions = new ScanOptions()
            {
               strScanValue = txtBoxScanValue.Text,
               strScanSecondValue = txtBoxScanSecondValue.Text,
               isHexValue = chkBoxIsHexValue.Checked,
               strSectionNameInclusionFilter = txtBoxSectionsFilterInclude.Text,
               strSectionNameExclusionFilter = txtBoxSectionsFilterExclude.Text,
               sectionPageProtectionFilter = (librpc.VM_PROT)Enum.Parse(typeof(librpc.VM_PROT), (String)cmbBoxSectionsFilterProtection.SelectedItem),
               sectionMaxLengthFilter = Convert.ToInt32(numUpDownSectionMaxLength.Value)
            };
            bgWorkerScanner.RunWorkerAsync(scanOptions);
         } catch (Exception ex) {
            MessageBox.Show(ex.ToString(), "btnScanNext");
         }
      }
      private void btnScanUndo_OnClick() {
         if (MessageBox.Show("Do you really want to undo the scan?", "PlayEngine", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
            listScanResults.Clear();
            listScanResults.AddRange(listPreviousScanResults);
            listViewResults.SetObjects(listScanResults.Take(1000));
            uiStatusStrip_lblStatus.Text = $"Undid scan, {listScanResults.Count} results";
            btnScanUndo.Enabled = false;
         }
      }
      #region uiToolStrip_linkFile
      private void btnLoadCheatTable_OnClick() {
         if (currentScanStatus != Memory.ScanStatus.CantScan) {
            MessageBox.Show("Cannot load a cheat table while the payload is not injected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }

         OpenFileDialog openFileDialog = new OpenFileDialog()
         {
            AddExtension = false,
            CheckFileExists = true,
            CheckPathExists = true,
            FileName = Memory.CUSAInfo.getVersionStr(),
            DefaultExt = "PECheatTable",
            Filter = "PlayEngine cheat tables|*.PECheatTable|PS4Cheater cheat tables|*.cht",
            FilterIndex = 0,
            Multiselect = false,
            ShowReadOnly = false,
            SupportMultiDottedExtensions = true,
            Title = "Select a cheat table to load",
            ValidateNames = true
         };
         if (openFileDialog.ShowDialog() == DialogResult.OK) {
            CheatTableFile cheatTable = null;
            try {
               if (openFileDialog.SafeFileName.EndsWith(".cht")) {
                  String newFileName = openFileDialog.FileName.Replace(".cht", ".PECheatTable");
                  cheatTable = CheatTableFile.updateOldFormat(openFileDialog.FileName);
                  cheatTable.saveToFile(newFileName);
               } else {
                  cheatTable = CheatTableFile.loadFromFile(openFileDialog.FileName);
                  if (cheatTable.playEngineVersion.Major > CheatTableFile.getAssemblyVersion().Major
                     || cheatTable.playEngineVersion.Minor > CheatTableFile.getAssemblyVersion().Minor) {
                     MessageBox.Show("Selected cheat table requires a higher version of PlayEngine!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;
                  }
               }

            } catch (Exception ex) {
               MessageBox.Show(ex.ToString(), "Exception occured while loading cheat table", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!uiToolStrip_ProcessManager_cmbBoxActiveProcess.Items.Contains(cheatTable.targetProcess)) {
               MessageBox.Show("Cheat table process is not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }
            uiToolStrip_ProcessManager_cmbBoxActiveProcess.SelectedItem = cheatTable.targetProcess;

            if (cheatTable.targetProcess == "eboot.bin") {
               String _Id =  Memory.CUSAInfo.getId();
               String _Ver = Memory.CUSAInfo.getVersionStr();
               if (_Id != cheatTable.cusaId)
                  MessageBox.Show("CUSA ids do not match, loading anyway...\r\n" +
                     $"Active CUSA id: {_Id}/Cheat table CUSA id: {cheatTable.cusaId}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               if (_Ver != cheatTable.cusaVersion)
                  MessageBox.Show("CUSA versions do not match, loading anyway...\r\n" +
                     $"Active CUSA version: v{_Ver}/Cheat table CUSA version: v{cheatTable.cusaVersion}.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            foreach (ICheatEntry cheatEntry in cheatTable.cheatEntries) {
               if (cheatEntry.isSimple()) {
                  var _cheatEntry = (SimpleCheatEntry)cheatEntry;
                  saveResult(_cheatEntry.description, null, 0, _cheatEntry.valueType, null, _cheatEntry.address);
               } else {
                  var _cheatEntry = (ComplexCheatEntry)cheatEntry;
                  var memorySection = Memory.ActiveProcess.info.listProcessMemorySections.First(s => s.index == _cheatEntry.sectionIndex);
                  saveResult(_cheatEntry.description, memorySection, _cheatEntry.sectionOffset, _cheatEntry.valueType, null);
               }
            }
         }
      }
      private void btnSaveCheatTable_OnClick() {
         SaveFileDialog saveFileDialog = new SaveFileDialog()
         {
            AddExtension = true,
            DefaultExt = "PECheatTable",
            Filter = "PlayEngine cheat tables|*.PECheatTable",
            FilterIndex = 0,
            SupportMultiDottedExtensions = true,
            Title = "Save cheat table",
            ValidateNames = true
         };
         if (saveFileDialog.ShowDialog() == DialogResult.OK) {
            var cheatTable = new CheatTableFile();
            foreach (CheatInformation cheatInformation in listViewSavedResults.Objects) {
               if (cheatInformation.memorySection == null) { // simple
                  SimpleCheatEntry simpleCheatEntry = new SimpleCheatEntry()
                  {
                     description = cheatInformation.description,
                     address = cheatInformation.address,
                     valueType = cheatInformation.valueType
                  };
                  cheatTable.cheatEntries.Add(simpleCheatEntry);
               } else {
                  ComplexCheatEntry complexCheatEntry = new ComplexCheatEntry()
                  {
                     description = cheatInformation.description,
                     sectionIndex = cheatInformation.memorySection.index,
                     sectionOffset = cheatInformation.sectionOffset,
                     valueType = cheatInformation.valueType
                  };
                  cheatTable.cheatEntries.Add(complexCheatEntry);
               }
            }
            cheatTable.playEngineVersion = CheatTableFile.getAssemblyVersion();
            cheatTable.targetProcess = (String)uiToolStrip_ProcessManager_cmbBoxActiveProcess.SelectedItem;
            cheatTable.cusaId = Memory.CUSAInfo.getId();
            cheatTable.cusaVersion = Memory.CUSAInfo.getVersionStr();
            cheatTable.saveToFile(saveFileDialog.FileName);
         }
      }
      #endregion
      #region uiToolStrip_linkPayloadAndProcess
      private void btnSendPayload_OnClick() {
         if (new Forms.ChildForms.childFrmSendPayload().ShowDialog() == DialogResult.OK) {
            if (Memory.initPS4RPC(Settings.mInstance.ps4.IPAddress)) {
               uiToolStrip_PayloadManager_chkPayloadActive.Checked = true;
               btnRefreshProcessList_OnClick();
            } else {
               MessageBox.Show("Could not connect to the payload!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }
      private void btnRefreshProcessList_OnClick() {
         try {
            uiToolStrip_ProcessManager_cmbBoxActiveProcess.Items.Clear();
            foreach (librpc.Process process in Memory.ps4RPC.GetProcessList()) {
               uiToolStrip_ProcessManager_cmbBoxActiveProcess.Items.Add(process.name);
               if (process.name == "eboot.bin")
                  uiToolStrip_ProcessManager_cmbBoxActiveProcess.SelectedItem = "eboot.bin";
            }

            if (uiToolStrip_ProcessManager_cmbBoxActiveProcess.SelectedIndex < 0)
               uiToolStrip_ProcessManager_cmbBoxActiveProcess.SelectedIndex = 1; // ignore rpcproc
         } catch (Exception ex) {
            MessageBox.Show(ex.ToString(), "Error during getting process list", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }
      #endregion
      #region uiStatusStrip_linkSavedResults
      private void btnAddEntry_OnClick() {
         var frmEditInstance = new ChildForms.childFrmEditCheatEntry("No description", 0, 0, 0, null, String.Empty, true);
         if (frmEditInstance.ShowDialog() == DialogResult.OK) {
            var returnInformation = frmEditInstance.returnInformation;
            if (returnInformation.isAdvanced) {
               var memorySection = Memory.ActiveProcess.info.listProcessMemorySections[returnInformation.sectionIndex];
               var runtimeAddress = memorySection.start + returnInformation.sectionOffset;
               var runtimeValue = Memory.ActiveProcess.read(runtimeAddress, returnInformation.valueType);
               saveResult(returnInformation.description, memorySection, returnInformation.sectionOffset, returnInformation.valueType, runtimeValue, returnInformation.address);
            } else {
               var runtimeValue = Memory.ActiveProcess.read(returnInformation.address, returnInformation.valueType);
               saveResult(returnInformation.description, null, 0, returnInformation.valueType, runtimeValue, returnInformation.address);
            }
         }
      }
      #endregion
      private void uiButtonHandler_Click(Object sender, EventArgs e) {
         String btnName = sender.GetType() == typeof(Button) ? (sender as Button).Name : (sender as ToolStripItem).Name;
         switch (btnName) {
            case "btnScan":
               btnScan_OnClick();
               break;
            case "btnScanNext":
               btnScanNext_OnClick();
               break;
            case "btnScanUndo":
               btnScanUndo_OnClick();
               break;
            #region uiToolStrip_linkFile
            case "uiToolStrip_btnLoadCheatTable":
               btnLoadCheatTable_OnClick();
               break;
            case "uiToolStrip_btnSaveCheatTable":
               btnSaveCheatTable_OnClick();
               break;
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
            case "uiStatusStrip_btnAddEntry":
               btnAddEntry_OnClick();
               break;
         }
      }
      #endregion

      private void cmbBoxScanValueType_SelectedIndexChanged(Object sender, EventArgs e) {
         listViewResults.Items.Clear();
         var newScanValueType = (IScanValueType)cmbBoxScanValueType.SelectedItem;
         currentScanValueType = newScanValueType;

         chkBoxIsHexValue.Visible = newScanValueType.supportsHexCompare;
         cmbBoxScanCompareType.DataSource = newScanValueType.supportedFirstScanCompareTypes;
         cmbBoxScanCompareType.SelectedIndex = 0;
      }
      private void cmbBoxScanCompareType_SelectedIndexChanged(Object sender, EventArgs e) {
         var newScanCompareType = (IScanCompareType)cmbBoxScanCompareType.SelectedItem;
         currentScanCompareType = newScanCompareType;

         txtBoxScanValue.Enabled = newScanCompareType.supportsScanValue;
         txtBoxScanSecondValue.Enabled = newScanCompareType.supportsScanSecondValue;
      }

      private void uiToolStrip_PayloadManager_chkPayloadActive_CheckedChanged(Object sender, EventArgs e) {
         Boolean isLoaded = uiToolStrip_PayloadManager_chkPayloadActive.Checked;
         splitContainerMain.Enabled = uiToolStrip_linkProcessManager.Enabled = uiStatusStrip_btnAddEntry.Enabled = isLoaded;
      }
      private void uiToolStrip_ProcessManager_cmbBoxActiveProcess_SelectedIndexChanged(Object sender, EventArgs e) {
         try {
            var comboBox = sender as ToolStripComboBox;
            if (comboBox.SelectedIndex < 0) {
               comboBox.SelectedIndex = 0;
               return;
            }

            String selectedProcessName = (String)uiToolStrip_ProcessManager_cmbBoxActiveProcess.SelectedItem;
            currentScanStatus = Memory.ScanStatus.CanScan;
            Memory.ActiveProcess.setActiveProcess(Memory.getProcessInfoFromName(selectedProcessName));

            if (selectedProcessName == "eboot.bin")
               lblProcessInfo.Text = $"{Memory.CUSAInfo.getId()} ({Memory.CUSAInfo.getVersionStr()})";
            uiToolStrip_lblActiveProcess.Text = $"Process: {selectedProcessName}";
            //uiToolStrip_btnOpenPointerScanner.Enabled = true;
         } catch (Exception exception) {
            MessageBox.Show(exception.ToString());
         }
      }

      private void listViewResults_FormatCell(Object sender, BrightIdeasSoftware.FormatCellEventArgs e) {
         ScanResult scanResult = (ScanResult)e.Model;
         if (scanResult.previousMemoryValue != scanResult.memoryValue) {
            e.SubItem.ForeColor = Color.Red;
            e.Item.SelectedForeColor = Color.Red;
         }
      }
      private void listViewResults_SaveSelectedEntries() {
         foreach (ScanResult scanResult in listViewResults.SelectedObjects) {
            saveResult("No description", scanResult.memorySection, scanResult.sectionOffset, scanResult.valueType, scanResult.memoryValue, scanResult.address);
         }
      }
      private void listViewResults_DoubleClick(Object sender, EventArgs e) {
         listViewResults_SaveSelectedEntries();
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
                     if (currentScanStatus == Memory.ScanStatus.CanScan)
                        btnScan_OnClick();
                     else if (currentScanStatus == Memory.ScanStatus.DidScan)
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
      private void bgWorkerScanner_DoWork(Object sender, DoWorkEventArgs e) {
         Int32 mainUpdateProgress = 0, subUpdateProgress = 0;
         Action<String, Int32> fnUpdateProgress = (String strUpdateText, Int32 updateProgress) =>
         {
            if (updateProgress >= 0)
               bgWorkerScanner.ReportProgress(updateProgress);
            listViewResults.Invoke(new Action(() => uiStatusStrip_lblStatus.Text = $"[{uiStatusStrip_progressBarScanPercent.Value}%] {strUpdateText}"));
         };

         listPreviousScanResults.Clear();
         listPreviousScanResults.AddRange(listScanResults);
         listScanResults.Clear();
         listViewResults.Invoke(new Action(() => listViewResults.BeginUpdate()));

         var oldScanStatus = currentScanStatus;
         var scanValueType = currentScanValueType.getType();
         currentScanStatus = Memory.ScanStatus.Scanning;

         #region Read values
         fnUpdateProgress("Reading values...", mainUpdateProgress);
         ScanOptions scanOptions = (ScanOptions)e.Argument;
         if (String.IsNullOrWhiteSpace(scanOptions.strScanValue)
            || (currentScanCompareType == CompareTypeValueBetween.mSelf & String.IsNullOrWhiteSpace(scanOptions.strScanSecondValue))) {
            fnUpdateProgress("Invalid values!", -1);
            throw new Exception("Invalid values!");
         }
         mainUpdateProgress += 2;
         #endregion
         #region Parse values
         fnUpdateProgress("Parsing values...", mainUpdateProgress);
         dynamic[] scanValues = new dynamic[2];
         if (currentScanValueType.getType() == typeof(Byte[])) {
            List<Byte> listBytes = new List<Byte>();
            foreach (String strByte in scanOptions.strScanValue.Split(new Char[] { ' ', '-', ':' }, StringSplitOptions.RemoveEmptyEntries))
               listBytes.Add(Convert.ToByte(strByte, 16));
            scanValues[0] = listBytes.ToArray();
         } else {
            if (scanOptions.isHexValue) {
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
               try {
                  scanValues[0] = dicHexCast[scanValueType](scanOptions.strScanValue);
                  scanValues[1] = dicHexCast[scanValueType](scanOptions.strScanSecondValue);
               } catch (OverflowException) {
                  scanValueType = currentScanValueType.getSignedType();
                  scanValues[0] = dicHexCast[scanValueType](scanOptions.strScanValue);
                  scanValues[1] = dicHexCast[scanValueType](scanOptions.strScanSecondValue);
               }
            } else {
               try {
                  scanValues[0] = Convert.ChangeType(scanOptions.strScanValue, currentScanValueType.getType());
                  scanValues[1] = Convert.ChangeType(scanOptions.strScanSecondValue, currentScanValueType.getType());
               } catch (OverflowException) {
                  scanValueType = currentScanValueType.getSignedType();
                  scanValues[0] = Convert.ChangeType(scanOptions.strScanValue, scanValueType);
                  scanValues[1] = Convert.ChangeType(scanOptions.strScanSecondValue, scanValueType);
               }
            }
         }
         mainUpdateProgress += 3;
         #endregion
         #region Scan values
         List<ScanResult> scanResults = new List<ScanResult>();
         #region Find sections
         listFilteredProcessMemorySections.Clear();
         listFilteredProcessMemorySections = Memory.Sections.getMemorySections(Memory.ActiveProcess.info, scanOptions.sectionPageProtectionFilter);
         if (!String.IsNullOrWhiteSpace(scanOptions.strSectionNameInclusionFilter))
            listFilteredProcessMemorySections.RemoveAll(section => !section.name.ContainsEx(scanOptions.strSectionNameInclusionFilter));
         if (!String.IsNullOrWhiteSpace(scanOptions.strSectionNameExclusionFilter))
            listFilteredProcessMemorySections.RemoveAll(section => section.name.ContainsEx(scanOptions.strSectionNameExclusionFilter));
         listFilteredProcessMemorySections.RemoveAll(section => section.length > scanOptions.sectionMaxLengthFilter);
         #endregion
         #region Find address range of the scan
         UInt64 processedMemoryRange = 0, totalMemoryRange = 0;
         String scanSizeStr = getSizeStr(0);

         var listScanAddressRange = new List<Tuple<librpc.MemorySection, Int32>>();
         Int32 lastAddedSectionIndex = -1;
         Action<librpc.MemorySection, Int32> fnAddSection = (librpc.MemorySection memorySection, Int32 length) =>
         {
            if (length > 0) {
               listScanAddressRange.Add(new Tuple<librpc.MemorySection, Int32>(memorySection, length));
               lastAddedSectionIndex++;
            }
         };

         Int32 dummyCounter = 0;
         foreach (var section in listFilteredProcessMemorySections) {
            var lastAddedSection = listScanAddressRange.LastOrDefault();
            if (lastAddedSection == null) {
               fnAddSection(section, section.length);
            } else {
               var lastAddedSectionEnd = lastAddedSection.Item1.start + (UInt64)lastAddedSection.Item2;
               if (lastAddedSectionEnd == section.start) {
                  if (lastAddedSection.Item2 < 100 * 1024)
                     listScanAddressRange[lastAddedSectionIndex] = new Tuple<librpc.MemorySection, Int32>(lastAddedSection.Item1, lastAddedSection.Item2 + section.length);
                  else
                     fnAddSection(section, section.length);
               } else {
                  fnAddSection(section, section.length);
               }
            }
            totalMemoryRange += (UInt64)section.length;
            scanSizeStr = getSizeStr(totalMemoryRange);

            subUpdateProgress = Convert.ToInt32((++dummyCounter / (Double)listFilteredProcessMemorySections.Count) * 100);
            mainUpdateProgress = Convert.ToInt32(subUpdateProgress * 0.45f);
            fnUpdateProgress($"Finding scan address range... %{subUpdateProgress}", mainUpdateProgress);
         }
         #endregion
         #region Scan
         dummyCounter = 0;
         Boolean shouldEscape = false;

         ObservableCollection<Tuple<librpc.MemorySection, Byte[]>> listReadBuffers = new ObservableCollection<Tuple<librpc.MemorySection, Byte[]>>();
         listReadBuffers.CollectionChanged += new NotifyCollectionChangedEventHandler((collection, eventArgs) =>
         {
            new Thread(() =>
            {
               if (eventArgs.Action == NotifyCollectionChangedAction.Add) {
                  foreach (Tuple<librpc.MemorySection, Byte[]> scanTuple in eventArgs.NewItems) {
                     mainUpdateProgress = 45 + Convert.ToInt32((processedMemoryRange / (Double)totalMemoryRange) * 45);
                     fnUpdateProgress($"Scanning... {getSizeStr(processedMemoryRange)}/{scanSizeStr} - part {++dummyCounter}/{listScanAddressRange.Count}", mainUpdateProgress);

                     var results = Memory.scan(scanTuple.Item1.start, scanTuple.Item2, scanValues[0], scanValueType, currentScanCompareType, new dynamic[2] { scanValues[0], scanValues[1] });
                     foreach (var resultTuple in results) {
                        ScanResult scanResult = new ScanResult()
                        {
                           address = resultTuple.Item1,
                           memorySection = scanTuple.Item1,
                           memoryValue = resultTuple.Item2,
                           previousMemoryValue = resultTuple.Item2,
                           valueType = scanValueType
                        };

                        scanResults.Add(scanResult);
                        if (bgWorkerScanner.CancellationPending)
                           break;
                     }
                     processedMemoryRange += (UInt64)scanTuple.Item2.Length;
                     shouldEscape = (dummyCounter == listScanAddressRange.Count) || bgWorkerScanner.CancellationPending;
                     if (bgWorkerScanner.CancellationPending)
                        break;
                  }
               }
            }).Start();
         });
         new Thread(() =>
         {
            foreach (var scanTuple in listScanAddressRange) {
               Byte[] scanSearchBuffer = Memory.ActiveProcess.readByteArray(scanTuple.Item1.start, scanTuple.Item2);
               if (scanSearchBuffer != null)
                  listReadBuffers.Add(new Tuple<librpc.MemorySection, Byte[]>(scanTuple.Item1, scanSearchBuffer));
               if (bgWorkerScanner.CancellationPending || shouldEscape)
                  break;
               Thread.Sleep(10);
            }
         }).Start();

         while (!shouldEscape)
            Thread.Sleep(100);
         #endregion
         #region Filter if next scan
         if (oldScanStatus == Memory.ScanStatus.DidScan) {
            fnUpdateProgress("Filtering values...", mainUpdateProgress);
            scanResults = scanResults.Intersect(listPreviousScanResults).ToList();
         }
         #endregion
         #endregion
         #region List results
         listScanResults.AddRange(scanResults);
         if (listScanResults.Count < 1000) {
            fnUpdateProgress($"Adding {listScanResults.Count} results to the list... (window may freeze)", 95);
            listViewResults.Invoke(new Action(() => listViewResults.SetObjects(listScanResults)));
         } else {
            fnUpdateProgress($"Adding 1000 of {listScanResults.Count} results to the list... (window may freeze)", 95);
            listViewResults.Invoke(new Action(() => listViewResults.SetObjects(listScanResults.Take(1000))));
         }
         #endregion
         bgWorkerScanner.ReportProgress(100);
      }
      private void bgWorkerScanner_ProgressChanged(Object sender, ProgressChangedEventArgs e) {
         uiStatusStrip_progressBarScanPercent.Value = Math.Max(0, Math.Min(e.ProgressPercentage, 100));
      }
      private void bgWorkerScanner_RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs e) {
         listViewResults.EndUpdate();
         currentScanStatus = Memory.ScanStatus.DidScan;
         if (e.Error != null)
            uiStatusStrip_lblStatus.Text = $"Error: {e.Error.Message}";
         else
            uiStatusStrip_lblStatus.Text = $"[100%] Finished scanning, {listScanResults.Count} results.";
         btnScanUndo.Enabled = listPreviousScanResults.Count > 0;
      }
      #endregion
      #region bgWorkerResultsUpdater
      private void bgWorkerResultsUpdater_DoWork(Object sender, DoWorkEventArgs e) {
         while (true) {
            if (bgWorkerResultsUpdater.CancellationPending) {
               e.Cancel = true;
               break;
            }
            try {
               // Scan results
               if (currentScanStatus != Memory.ScanStatus.Scanning) {
                  listViewResults.Invoke(new Action(() =>
                  {
                     for (Int32 i = listViewResults.TopItemIndex; i < listViewResults.TopItemIndex + 20; i++) {
                        ScanResult scanResult = (ScanResult)listViewResults.GetModelObject(i);
                        if (scanResult != null) {
                           dynamic runtimeValue = Memory.ActiveProcess.read(
                              scanResult.address,
                              scanResult.valueType
                           );
                           scanResult.memoryValue = runtimeValue;
                        }
                        Thread.Sleep(1);
                     }
                  }));
               }
               Thread.Sleep(1000);
            } catch (Exception ex) {
               Console.WriteLine("Fail silently, bgWorkerResultsUpdater:\r\n" + ex.ToString());
            }
         }
      }
      #endregion
      #region bgWorkerValueFreezer
      private void bgWorkerValueFreezer_DoWork(Object sender, DoWorkEventArgs e) {
         while (true) {
            if (bgWorkerValueFreezer.CancellationPending) {
               e.Cancel = true;
               break;
            }
            try {
               if (listViewSavedResults.Items.Count > 0) {
                  foreach (CheatInformation cheatInformation in listViewSavedResults.Objects) {
                     if (cheatInformation.isFrozen)
                        Memory.ActiveProcess.write(cheatInformation.address, cheatInformation.frozenValue, cheatInformation.valueType);
                     Thread.Sleep(1);
                  }
               }
               Thread.Sleep(250);
            } catch (Exception ex) {
               Console.WriteLine("Fail silently, bgWorkerValueFreezer:\r\n" + ex.ToString());
            }
         }
      }
      #endregion

      #endregion

      private void MainForm_FormClosing(Object sender, FormClosingEventArgs e) {
         bgWorkerResultsUpdater.CancelAsync();
         bgWorkerValueFreezer.CancelAsync();
      }
   }
}