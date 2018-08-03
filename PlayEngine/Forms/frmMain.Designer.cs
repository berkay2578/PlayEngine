namespace PlayEngine.Forms {
   partial class MainForm {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing) {
         if (disposing && (components != null)) {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent() {
         this.components = new System.ComponentModel.Container();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
         this.uiToolStrip = new System.Windows.Forms.ToolStrip();
         this.uiToolStrip_linkFile = new System.Windows.Forms.ToolStripDropDownButton();
         this.uiToolStrip_btnLoadCheatTable = new System.Windows.Forms.ToolStripMenuItem();
         this.uiToolStrip_btnSaveCheatTable = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.uiToolStrip_btnExit = new System.Windows.Forms.ToolStripMenuItem();
         this.uiToolStrip_linkPayloadAndProcess = new System.Windows.Forms.ToolStripDropDownButton();
         this.uiToolStrip_linkPayloadManager = new System.Windows.Forms.ToolStripMenuItem();
         this.uiToolStrip_PayloadManager_chkPayloadActive = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.uiToolStrip_PayloadManager_btnSendPayload = new System.Windows.Forms.ToolStripMenuItem();
         this.uiToolStrip_linkProcessManager = new System.Windows.Forms.ToolStripMenuItem();
         this.uiToolStrip_ProcessManager_btnRefreshProcessList = new System.Windows.Forms.ToolStripMenuItem();
         this.uiToolStrip_ProcessManager_cmbBoxActiveProcess = new System.Windows.Forms.ToolStripComboBox();
         this.uiToolStrip_linkTools = new System.Windows.Forms.ToolStripDropDownButton();
         this.uiToolStrip_btnOpenPointerScanner = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this.uiToolStrip_lblActiveProcess = new System.Windows.Forms.ToolStripLabel();
         this.splitContainerMain = new System.Windows.Forms.SplitContainer();
         this.splitContainerScanner = new System.Windows.Forms.SplitContainer();
         this.listViewResults = new BrightIdeasSoftware.ObjectListView();
         this.columnHeaderAddress = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.columnHeaderSection = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.columnHeaderValue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.splitContainerScanDetails = new System.Windows.Forms.SplitContainer();
         this.txtBoxSectionsExclusionFilter = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.progressBarScanPercent = new System.Windows.Forms.ProgressBar();
         this.txtBoxSectionsInclusionFilter = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.txtBoxScanValueSecond = new System.Windows.Forms.TextBox();
         this.lblSecondValue = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.cmbBoxValueType = new System.Windows.Forms.ComboBox();
         this.cmbBoxScanType = new System.Windows.Forms.ComboBox();
         this.txtBoxScanValue = new System.Windows.Forms.TextBox();
         this.chkBoxIsHexValue = new System.Windows.Forms.CheckBox();
         this.btnScanNext = new System.Windows.Forms.Button();
         this.btnScan = new System.Windows.Forms.Button();
         this.chkListViewSearchSections = new BrightIdeasSoftware.ObjectListView();
         this.columnHeaderSectionName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.columnHeaderSectionOffset = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.columnHeaderSectionLength = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.columnHeaderSectionProtection = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.contextMenuChkListBox = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.contextMenuChkListBox_btnSelectAll = new System.Windows.Forms.ToolStripMenuItem();
         this.dataGridSavedResults = new System.Windows.Forms.DataGridView();
         this.dataGridSavedResults_chkBoxFreezeValue = new System.Windows.Forms.DataGridViewCheckBoxColumn();
         this.dataGridSavedResults_txtBoxDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.dataGridSavedResults_txtBoxAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.dataGridSavedResults_txtBoxSection = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.dataGridSavedResults_txtBoxValueType = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.dataGridSavedResults_txtBoxValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.uiStatusStrip = new System.Windows.Forms.StatusStrip();
         this.uiStatusStrip_linkSavedResults = new System.Windows.Forms.ToolStripDropDownButton();
         this.uiStatusStrip_SavedResults_btnAddAddress = new System.Windows.Forms.ToolStripMenuItem();
         this.uiStatusStrip_SavedResults_btnAddPointer = new System.Windows.Forms.ToolStripMenuItem();
         this.uiStatusStrip_lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
         this.bgWorkerScanner = new System.ComponentModel.BackgroundWorker();
         this.bgWorkerResultsUpdater = new System.ComponentModel.BackgroundWorker();
         this.lblProcessInfo = new System.Windows.Forms.ToolStripLabel();
         this.uiToolStrip.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
         this.splitContainerMain.Panel1.SuspendLayout();
         this.splitContainerMain.Panel2.SuspendLayout();
         this.splitContainerMain.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainerScanner)).BeginInit();
         this.splitContainerScanner.Panel1.SuspendLayout();
         this.splitContainerScanner.Panel2.SuspendLayout();
         this.splitContainerScanner.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.listViewResults)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainerScanDetails)).BeginInit();
         this.splitContainerScanDetails.Panel1.SuspendLayout();
         this.splitContainerScanDetails.Panel2.SuspendLayout();
         this.splitContainerScanDetails.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.chkListViewSearchSections)).BeginInit();
         this.contextMenuChkListBox.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridSavedResults)).BeginInit();
         this.uiStatusStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // uiToolStrip
         // 
         this.uiToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.uiToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiToolStrip_linkFile,
            this.uiToolStrip_linkPayloadAndProcess,
            this.uiToolStrip_linkTools,
            this.toolStripSeparator3,
            this.uiToolStrip_lblActiveProcess,
            this.lblProcessInfo});
         this.uiToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
         this.uiToolStrip.Location = new System.Drawing.Point(0, 0);
         this.uiToolStrip.Name = "uiToolStrip";
         this.uiToolStrip.Size = new System.Drawing.Size(484, 25);
         this.uiToolStrip.TabIndex = 0;
         // 
         // uiToolStrip_linkFile
         // 
         this.uiToolStrip_linkFile.AutoToolTip = false;
         this.uiToolStrip_linkFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.uiToolStrip_linkFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiToolStrip_btnLoadCheatTable,
            this.uiToolStrip_btnSaveCheatTable,
            this.toolStripSeparator1,
            this.uiToolStrip_btnExit});
         this.uiToolStrip_linkFile.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.uiToolStrip_linkFile.Name = "uiToolStrip_linkFile";
         this.uiToolStrip_linkFile.Size = new System.Drawing.Size(38, 22);
         this.uiToolStrip_linkFile.Text = "File";
         // 
         // uiToolStrip_btnLoadCheatTable
         // 
         this.uiToolStrip_btnLoadCheatTable.Name = "uiToolStrip_btnLoadCheatTable";
         this.uiToolStrip_btnLoadCheatTable.Size = new System.Drawing.Size(170, 22);
         this.uiToolStrip_btnLoadCheatTable.Text = "Load cheat table...";
         this.uiToolStrip_btnLoadCheatTable.Click += new System.EventHandler(this.uiButtonHandler_Click);
         // 
         // uiToolStrip_btnSaveCheatTable
         // 
         this.uiToolStrip_btnSaveCheatTable.Name = "uiToolStrip_btnSaveCheatTable";
         this.uiToolStrip_btnSaveCheatTable.Size = new System.Drawing.Size(170, 22);
         this.uiToolStrip_btnSaveCheatTable.Text = "Save cheat table...";
         this.uiToolStrip_btnSaveCheatTable.Click += new System.EventHandler(this.uiButtonHandler_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
         // 
         // uiToolStrip_btnExit
         // 
         this.uiToolStrip_btnExit.Name = "uiToolStrip_btnExit";
         this.uiToolStrip_btnExit.Size = new System.Drawing.Size(170, 22);
         this.uiToolStrip_btnExit.Text = "Exit";
         this.uiToolStrip_btnExit.Click += new System.EventHandler(this.uiButtonHandler_Click);
         // 
         // uiToolStrip_linkPayloadAndProcess
         // 
         this.uiToolStrip_linkPayloadAndProcess.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.uiToolStrip_linkPayloadAndProcess.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiToolStrip_linkPayloadManager,
            this.uiToolStrip_linkProcessManager});
         this.uiToolStrip_linkPayloadAndProcess.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.uiToolStrip_linkPayloadAndProcess.Name = "uiToolStrip_linkPayloadAndProcess";
         this.uiToolStrip_linkPayloadAndProcess.Size = new System.Drawing.Size(113, 22);
         this.uiToolStrip_linkPayloadAndProcess.Text = "Payload / Process";
         // 
         // uiToolStrip_linkPayloadManager
         // 
         this.uiToolStrip_linkPayloadManager.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiToolStrip_PayloadManager_chkPayloadActive,
            this.toolStripSeparator2,
            this.uiToolStrip_PayloadManager_btnSendPayload});
         this.uiToolStrip_linkPayloadManager.Name = "uiToolStrip_linkPayloadManager";
         this.uiToolStrip_linkPayloadManager.Size = new System.Drawing.Size(116, 22);
         this.uiToolStrip_linkPayloadManager.Text = "Payload";
         // 
         // uiToolStrip_PayloadManager_chkPayloadActive
         // 
         this.uiToolStrip_PayloadManager_chkPayloadActive.Enabled = false;
         this.uiToolStrip_PayloadManager_chkPayloadActive.Name = "uiToolStrip_PayloadManager_chkPayloadActive";
         this.uiToolStrip_PayloadManager_chkPayloadActive.Size = new System.Drawing.Size(155, 22);
         this.uiToolStrip_PayloadManager_chkPayloadActive.Text = "Payload active?";
         this.uiToolStrip_PayloadManager_chkPayloadActive.CheckedChanged += new System.EventHandler(this.uiToolStrip_PayloadManager_chkPayloadActive_CheckedChanged);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(152, 6);
         // 
         // uiToolStrip_PayloadManager_btnSendPayload
         // 
         this.uiToolStrip_PayloadManager_btnSendPayload.Name = "uiToolStrip_PayloadManager_btnSendPayload";
         this.uiToolStrip_PayloadManager_btnSendPayload.Size = new System.Drawing.Size(155, 22);
         this.uiToolStrip_PayloadManager_btnSendPayload.Text = "Send payload";
         this.uiToolStrip_PayloadManager_btnSendPayload.Click += new System.EventHandler(this.uiButtonHandler_Click);
         // 
         // uiToolStrip_linkProcessManager
         // 
         this.uiToolStrip_linkProcessManager.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiToolStrip_ProcessManager_btnRefreshProcessList,
            this.uiToolStrip_ProcessManager_cmbBoxActiveProcess});
         this.uiToolStrip_linkProcessManager.Enabled = false;
         this.uiToolStrip_linkProcessManager.Name = "uiToolStrip_linkProcessManager";
         this.uiToolStrip_linkProcessManager.Size = new System.Drawing.Size(116, 22);
         this.uiToolStrip_linkProcessManager.Text = "Process";
         // 
         // uiToolStrip_ProcessManager_btnRefreshProcessList
         // 
         this.uiToolStrip_ProcessManager_btnRefreshProcessList.Name = "uiToolStrip_ProcessManager_btnRefreshProcessList";
         this.uiToolStrip_ProcessManager_btnRefreshProcessList.Size = new System.Drawing.Size(181, 22);
         this.uiToolStrip_ProcessManager_btnRefreshProcessList.Text = "Refresh process list";
         this.uiToolStrip_ProcessManager_btnRefreshProcessList.Click += new System.EventHandler(this.uiButtonHandler_Click);
         // 
         // uiToolStrip_ProcessManager_cmbBoxActiveProcess
         // 
         this.uiToolStrip_ProcessManager_cmbBoxActiveProcess.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
         this.uiToolStrip_ProcessManager_cmbBoxActiveProcess.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
         this.uiToolStrip_ProcessManager_cmbBoxActiveProcess.DropDownWidth = 230;
         this.uiToolStrip_ProcessManager_cmbBoxActiveProcess.MaxDropDownItems = 12;
         this.uiToolStrip_ProcessManager_cmbBoxActiveProcess.Name = "uiToolStrip_ProcessManager_cmbBoxActiveProcess";
         this.uiToolStrip_ProcessManager_cmbBoxActiveProcess.Size = new System.Drawing.Size(121, 23);
         this.uiToolStrip_ProcessManager_cmbBoxActiveProcess.Text = "Active process";
         this.uiToolStrip_ProcessManager_cmbBoxActiveProcess.SelectedIndexChanged += new System.EventHandler(this.uiToolStrip_ProcessManager_cmbBoxActiveProcess_SelectedIndexChanged);
         // 
         // uiToolStrip_linkTools
         // 
         this.uiToolStrip_linkTools.AutoToolTip = false;
         this.uiToolStrip_linkTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.uiToolStrip_linkTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiToolStrip_btnOpenPointerScanner});
         this.uiToolStrip_linkTools.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.uiToolStrip_linkTools.Name = "uiToolStrip_linkTools";
         this.uiToolStrip_linkTools.Size = new System.Drawing.Size(48, 22);
         this.uiToolStrip_linkTools.Text = "Tools";
         // 
         // uiToolStrip_btnOpenPointerScanner
         // 
         this.uiToolStrip_btnOpenPointerScanner.Enabled = false;
         this.uiToolStrip_btnOpenPointerScanner.Name = "uiToolStrip_btnOpenPointerScanner";
         this.uiToolStrip_btnOpenPointerScanner.Size = new System.Drawing.Size(189, 22);
         this.uiToolStrip_btnOpenPointerScanner.Text = "Open Pointer Scanner";
         this.uiToolStrip_btnOpenPointerScanner.Click += new System.EventHandler(this.uiButtonHandler_Click);
         // 
         // toolStripSeparator3
         // 
         this.toolStripSeparator3.Name = "toolStripSeparator3";
         this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
         // 
         // uiToolStrip_lblActiveProcess
         // 
         this.uiToolStrip_lblActiveProcess.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.uiToolStrip_lblActiveProcess.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.uiToolStrip_lblActiveProcess.Name = "uiToolStrip_lblActiveProcess";
         this.uiToolStrip_lblActiveProcess.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
         this.uiToolStrip_lblActiveProcess.Size = new System.Drawing.Size(86, 22);
         this.uiToolStrip_lblActiveProcess.Text = "Process: NONE";
         this.uiToolStrip_lblActiveProcess.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // splitContainerMain
         // 
         this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainerMain.Enabled = false;
         this.splitContainerMain.Location = new System.Drawing.Point(0, 25);
         this.splitContainerMain.Name = "splitContainerMain";
         this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // splitContainerMain.Panel1
         // 
         this.splitContainerMain.Panel1.Controls.Add(this.splitContainerScanner);
         this.splitContainerMain.Panel1MinSize = 315;
         // 
         // splitContainerMain.Panel2
         // 
         this.splitContainerMain.Panel2.Controls.Add(this.dataGridSavedResults);
         this.splitContainerMain.Panel2MinSize = 50;
         this.splitContainerMain.Size = new System.Drawing.Size(484, 404);
         this.splitContainerMain.SplitterDistance = 315;
         this.splitContainerMain.SplitterWidth = 3;
         this.splitContainerMain.TabIndex = 1;
         // 
         // splitContainerScanner
         // 
         this.splitContainerScanner.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainerScanner.IsSplitterFixed = true;
         this.splitContainerScanner.Location = new System.Drawing.Point(0, 0);
         this.splitContainerScanner.Name = "splitContainerScanner";
         // 
         // splitContainerScanner.Panel1
         // 
         this.splitContainerScanner.Panel1.Controls.Add(this.listViewResults);
         this.splitContainerScanner.Panel1MinSize = 150;
         // 
         // splitContainerScanner.Panel2
         // 
         this.splitContainerScanner.Panel2.Controls.Add(this.splitContainerScanDetails);
         this.splitContainerScanner.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
         this.splitContainerScanner.Panel2MinSize = 160;
         this.splitContainerScanner.Size = new System.Drawing.Size(484, 315);
         this.splitContainerScanner.SplitterDistance = 211;
         this.splitContainerScanner.SplitterWidth = 1;
         this.splitContainerScanner.TabIndex = 0;
         // 
         // listViewResults
         // 
         this.listViewResults.AllColumns.Add(this.columnHeaderAddress);
         this.listViewResults.AllColumns.Add(this.columnHeaderSection);
         this.listViewResults.AllColumns.Add(this.columnHeaderValue);
         this.listViewResults.AutoArrange = false;
         this.listViewResults.CellEditUseWholeCell = false;
         this.listViewResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderAddress,
            this.columnHeaderSection,
            this.columnHeaderValue});
         this.listViewResults.Cursor = System.Windows.Forms.Cursors.Default;
         this.listViewResults.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listViewResults.FullRowSelect = true;
         this.listViewResults.HideSelection = false;
         this.listViewResults.Location = new System.Drawing.Point(0, 0);
         this.listViewResults.Name = "listViewResults";
         this.listViewResults.ShowGroups = false;
         this.listViewResults.ShowItemToolTips = true;
         this.listViewResults.Size = new System.Drawing.Size(211, 315);
         this.listViewResults.TabIndex = 0;
         this.listViewResults.TabStop = false;
         this.listViewResults.UseCellFormatEvents = true;
         this.listViewResults.UseCompatibleStateImageBehavior = false;
         this.listViewResults.UseNotifyPropertyChanged = true;
         this.listViewResults.View = System.Windows.Forms.View.Details;
         this.listViewResults.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.listViewResults_FormatCell);
         this.listViewResults.DoubleClick += new System.EventHandler(this.listViewResults_DoubleClick);
         this.listViewResults.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiKeyDownHandler);
         // 
         // columnHeaderAddress
         // 
         this.columnHeaderAddress.AspectName = "address";
         this.columnHeaderAddress.AspectToStringFormat = "{0:X}";
         this.columnHeaderAddress.IsEditable = false;
         this.columnHeaderAddress.Searchable = false;
         this.columnHeaderAddress.Text = "Address";
         this.columnHeaderAddress.Width = 85;
         // 
         // columnHeaderSection
         // 
         this.columnHeaderSection.AspectName = "memorySection";
         this.columnHeaderSection.IsEditable = false;
         this.columnHeaderSection.Searchable = false;
         this.columnHeaderSection.Text = "Section";
         this.columnHeaderSection.Width = 74;
         // 
         // columnHeaderValue
         // 
         this.columnHeaderValue.AspectName = "memoryValue";
         this.columnHeaderValue.IsEditable = false;
         this.columnHeaderValue.Searchable = false;
         this.columnHeaderValue.Text = "Value";
         this.columnHeaderValue.Width = 50;
         // 
         // splitContainerScanDetails
         // 
         this.splitContainerScanDetails.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainerScanDetails.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
         this.splitContainerScanDetails.IsSplitterFixed = true;
         this.splitContainerScanDetails.Location = new System.Drawing.Point(0, 0);
         this.splitContainerScanDetails.Name = "splitContainerScanDetails";
         this.splitContainerScanDetails.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // splitContainerScanDetails.Panel1
         // 
         this.splitContainerScanDetails.Panel1.Controls.Add(this.txtBoxSectionsExclusionFilter);
         this.splitContainerScanDetails.Panel1.Controls.Add(this.label1);
         this.splitContainerScanDetails.Panel1.Controls.Add(this.progressBarScanPercent);
         this.splitContainerScanDetails.Panel1.Controls.Add(this.txtBoxSectionsInclusionFilter);
         this.splitContainerScanDetails.Panel1.Controls.Add(this.label2);
         this.splitContainerScanDetails.Panel1.Controls.Add(this.txtBoxScanValueSecond);
         this.splitContainerScanDetails.Panel1.Controls.Add(this.lblSecondValue);
         this.splitContainerScanDetails.Panel1.Controls.Add(this.label3);
         this.splitContainerScanDetails.Panel1.Controls.Add(this.cmbBoxValueType);
         this.splitContainerScanDetails.Panel1.Controls.Add(this.cmbBoxScanType);
         this.splitContainerScanDetails.Panel1.Controls.Add(this.txtBoxScanValue);
         this.splitContainerScanDetails.Panel1.Controls.Add(this.chkBoxIsHexValue);
         this.splitContainerScanDetails.Panel1.Controls.Add(this.btnScanNext);
         this.splitContainerScanDetails.Panel1.Controls.Add(this.btnScan);
         this.splitContainerScanDetails.Panel1MinSize = 163;
         // 
         // splitContainerScanDetails.Panel2
         // 
         this.splitContainerScanDetails.Panel2.Controls.Add(this.chkListViewSearchSections);
         this.splitContainerScanDetails.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
         this.splitContainerScanDetails.Size = new System.Drawing.Size(271, 315);
         this.splitContainerScanDetails.SplitterDistance = 190;
         this.splitContainerScanDetails.SplitterWidth = 1;
         this.splitContainerScanDetails.TabIndex = 0;
         // 
         // txtBoxSectionsExclusionFilter
         // 
         this.txtBoxSectionsExclusionFilter.Location = new System.Drawing.Point(101, 162);
         this.txtBoxSectionsExclusionFilter.Name = "txtBoxSectionsExclusionFilter";
         this.txtBoxSectionsExclusionFilter.Size = new System.Drawing.Size(159, 23);
         this.txtBoxSectionsExclusionFilter.TabIndex = 18;
         this.txtBoxSectionsExclusionFilter.TextChanged += new System.EventHandler(this.txtBoxSectionsExclusionFilter_TextChanged);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(0, 166);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(89, 15);
         this.label1.TabIndex = 25;
         this.label1.Text = "Exclusion filter: ";
         // 
         // progressBarScanPercent
         // 
         this.progressBarScanPercent.Location = new System.Drawing.Point(160, 7);
         this.progressBarScanPercent.Name = "progressBarScanPercent";
         this.progressBarScanPercent.Size = new System.Drawing.Size(100, 23);
         this.progressBarScanPercent.Step = 1;
         this.progressBarScanPercent.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
         this.progressBarScanPercent.TabIndex = 24;
         // 
         // txtBoxSectionsInclusionFilter
         // 
         this.txtBoxSectionsInclusionFilter.Location = new System.Drawing.Point(101, 138);
         this.txtBoxSectionsInclusionFilter.Name = "txtBoxSectionsInclusionFilter";
         this.txtBoxSectionsInclusionFilter.Size = new System.Drawing.Size(159, 23);
         this.txtBoxSectionsInclusionFilter.TabIndex = 17;
         this.txtBoxSectionsInclusionFilter.TextChanged += new System.EventHandler(this.txtBoxSectionsInclusionFilter_TextChanged);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(0, 142);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(88, 15);
         this.label2.TabIndex = 22;
         this.label2.Text = "Inclusion filter: ";
         // 
         // txtBoxScanValueSecond
         // 
         this.txtBoxScanValueSecond.Enabled = false;
         this.txtBoxScanValueSecond.Location = new System.Drawing.Point(67, 64);
         this.txtBoxScanValueSecond.Name = "txtBoxScanValueSecond";
         this.txtBoxScanValueSecond.Size = new System.Drawing.Size(193, 23);
         this.txtBoxScanValueSecond.TabIndex = 14;
         this.txtBoxScanValueSecond.Text = "0";
         this.txtBoxScanValueSecond.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiKeyDownHandler);
         // 
         // lblSecondValue
         // 
         this.lblSecondValue.AutoSize = true;
         this.lblSecondValue.Enabled = false;
         this.lblSecondValue.Location = new System.Drawing.Point(0, 67);
         this.lblSecondValue.Name = "lblSecondValue";
         this.lblSecondValue.Size = new System.Drawing.Size(61, 15);
         this.lblSecondValue.TabIndex = 20;
         this.lblSecondValue.Text = "2nd value:";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label3.Location = new System.Drawing.Point(0, 120);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(124, 15);
         this.label3.TabIndex = 18;
         this.label3.Text = "Sections to search in:";
         // 
         // cmbBoxValueType
         // 
         this.cmbBoxValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbBoxValueType.FormattingEnabled = true;
         this.cmbBoxValueType.Items.AddRange(new object[] {
            "Byte",
            "2 Bytes",
            "4 Bytes",
            "8 Bytes",
            "Float",
            "Double",
            "String",
            "Array of bytes"});
         this.cmbBoxValueType.Location = new System.Drawing.Point(3, 93);
         this.cmbBoxValueType.Name = "cmbBoxValueType";
         this.cmbBoxValueType.Size = new System.Drawing.Size(118, 23);
         this.cmbBoxValueType.TabIndex = 15;
         this.cmbBoxValueType.SelectedIndexChanged += new System.EventHandler(this.cmbBoxValueType_SelectedIndexChanged);
         // 
         // cmbBoxScanType
         // 
         this.cmbBoxScanType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbBoxScanType.FormattingEnabled = true;
         this.cmbBoxScanType.Location = new System.Drawing.Point(127, 93);
         this.cmbBoxScanType.Name = "cmbBoxScanType";
         this.cmbBoxScanType.Size = new System.Drawing.Size(133, 23);
         this.cmbBoxScanType.TabIndex = 16;
         this.cmbBoxScanType.SelectedIndexChanged += new System.EventHandler(this.cmbBoxScanType_SelectedIndexChanged);
         // 
         // txtBoxScanValue
         // 
         this.txtBoxScanValue.Location = new System.Drawing.Point(67, 35);
         this.txtBoxScanValue.Name = "txtBoxScanValue";
         this.txtBoxScanValue.Size = new System.Drawing.Size(193, 23);
         this.txtBoxScanValue.TabIndex = 13;
         this.txtBoxScanValue.Text = "0";
         this.txtBoxScanValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiKeyDownHandler);
         // 
         // chkBoxIsHexValue
         // 
         this.chkBoxIsHexValue.AutoSize = true;
         this.chkBoxIsHexValue.Enabled = false;
         this.chkBoxIsHexValue.Location = new System.Drawing.Point(3, 37);
         this.chkBoxIsHexValue.Name = "chkBoxIsHexValue";
         this.chkBoxIsHexValue.Size = new System.Drawing.Size(46, 19);
         this.chkBoxIsHexValue.TabIndex = 12;
         this.chkBoxIsHexValue.Text = "Hex";
         this.chkBoxIsHexValue.UseVisualStyleBackColor = true;
         // 
         // btnScanNext
         // 
         this.btnScanNext.Location = new System.Drawing.Point(82, 7);
         this.btnScanNext.Name = "btnScanNext";
         this.btnScanNext.Size = new System.Drawing.Size(75, 23);
         this.btnScanNext.TabIndex = 11;
         this.btnScanNext.Text = "Next Scan";
         this.btnScanNext.UseVisualStyleBackColor = true;
         this.btnScanNext.Click += new System.EventHandler(this.uiButtonHandler_Click);
         // 
         // btnScan
         // 
         this.btnScan.Location = new System.Drawing.Point(3, 7);
         this.btnScan.Name = "btnScan";
         this.btnScan.Size = new System.Drawing.Size(75, 23);
         this.btnScan.TabIndex = 10;
         this.btnScan.Text = "First Scan";
         this.btnScan.UseVisualStyleBackColor = true;
         this.btnScan.Click += new System.EventHandler(this.uiButtonHandler_Click);
         // 
         // chkListViewSearchSections
         // 
         this.chkListViewSearchSections.AllColumns.Add(this.columnHeaderSectionName);
         this.chkListViewSearchSections.AllColumns.Add(this.columnHeaderSectionOffset);
         this.chkListViewSearchSections.AllColumns.Add(this.columnHeaderSectionLength);
         this.chkListViewSearchSections.AllColumns.Add(this.columnHeaderSectionProtection);
         this.chkListViewSearchSections.AllowColumnReorder = true;
         this.chkListViewSearchSections.AutoArrange = false;
         this.chkListViewSearchSections.CellEditUseWholeCell = false;
         this.chkListViewSearchSections.CheckBoxes = true;
         this.chkListViewSearchSections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSectionName,
            this.columnHeaderSectionOffset,
            this.columnHeaderSectionLength,
            this.columnHeaderSectionProtection});
         this.chkListViewSearchSections.ContextMenuStrip = this.contextMenuChkListBox;
         this.chkListViewSearchSections.Cursor = System.Windows.Forms.Cursors.Default;
         this.chkListViewSearchSections.Dock = System.Windows.Forms.DockStyle.Fill;
         this.chkListViewSearchSections.EmptyListMsg = "Select a process to see sections.";
         this.chkListViewSearchSections.FullRowSelect = true;
         this.chkListViewSearchSections.Location = new System.Drawing.Point(0, 0);
         this.chkListViewSearchSections.Name = "chkListViewSearchSections";
         this.chkListViewSearchSections.PersistentCheckBoxes = false;
         this.chkListViewSearchSections.ShowGroups = false;
         this.chkListViewSearchSections.ShowImagesOnSubItems = true;
         this.chkListViewSearchSections.ShowItemToolTips = true;
         this.chkListViewSearchSections.Size = new System.Drawing.Size(267, 124);
         this.chkListViewSearchSections.TabIndex = 0;
         this.chkListViewSearchSections.TabStop = false;
         this.chkListViewSearchSections.TintSortColumn = true;
         this.chkListViewSearchSections.UseCompatibleStateImageBehavior = false;
         this.chkListViewSearchSections.View = System.Windows.Forms.View.Details;
         // 
         // columnHeaderSectionName
         // 
         this.columnHeaderSectionName.AspectName = "name";
         this.columnHeaderSectionName.IsEditable = false;
         this.columnHeaderSectionName.Text = "Name";
         this.columnHeaderSectionName.UseFiltering = false;
         this.columnHeaderSectionName.Width = 97;
         // 
         // columnHeaderSectionOffset
         // 
         this.columnHeaderSectionOffset.AspectName = "offset";
         this.columnHeaderSectionOffset.AspectToStringFormat = "0x{0:X}";
         this.columnHeaderSectionOffset.IsEditable = false;
         this.columnHeaderSectionOffset.Text = "Offset";
         this.columnHeaderSectionOffset.UseFiltering = false;
         this.columnHeaderSectionOffset.Width = 44;
         // 
         // columnHeaderSectionLength
         // 
         this.columnHeaderSectionLength.AspectName = "length";
         this.columnHeaderSectionLength.AspectToStringFormat = "{0:#,}KB";
         this.columnHeaderSectionLength.IsEditable = false;
         this.columnHeaderSectionLength.Text = "Size";
         this.columnHeaderSectionLength.UseFiltering = false;
         this.columnHeaderSectionLength.Width = 50;
         // 
         // columnHeaderSectionProtection
         // 
         this.columnHeaderSectionProtection.AspectName = "protection";
         this.columnHeaderSectionProtection.IsEditable = false;
         this.columnHeaderSectionProtection.Text = "Protection";
         this.columnHeaderSectionProtection.UseFiltering = false;
         this.columnHeaderSectionProtection.Width = 69;
         // 
         // contextMenuChkListBox
         // 
         this.contextMenuChkListBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuChkListBox_btnSelectAll});
         this.contextMenuChkListBox.Name = "contextMenuChkListBox";
         this.contextMenuChkListBox.Size = new System.Drawing.Size(121, 26);
         // 
         // contextMenuChkListBox_btnSelectAll
         // 
         this.contextMenuChkListBox_btnSelectAll.CheckOnClick = true;
         this.contextMenuChkListBox_btnSelectAll.Name = "contextMenuChkListBox_btnSelectAll";
         this.contextMenuChkListBox_btnSelectAll.Size = new System.Drawing.Size(120, 22);
         this.contextMenuChkListBox_btnSelectAll.Text = "Select all";
         this.contextMenuChkListBox_btnSelectAll.Click += new System.EventHandler(this.uiButtonHandler_Click);
         // 
         // dataGridSavedResults
         // 
         this.dataGridSavedResults.AllowUserToAddRows = false;
         this.dataGridSavedResults.AllowUserToResizeRows = false;
         this.dataGridSavedResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridSavedResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridSavedResults_chkBoxFreezeValue,
            this.dataGridSavedResults_txtBoxDescription,
            this.dataGridSavedResults_txtBoxAddress,
            this.dataGridSavedResults_txtBoxSection,
            this.dataGridSavedResults_txtBoxValueType,
            this.dataGridSavedResults_txtBoxValue});
         this.dataGridSavedResults.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridSavedResults.Location = new System.Drawing.Point(0, 0);
         this.dataGridSavedResults.Name = "dataGridSavedResults";
         this.dataGridSavedResults.RowHeadersVisible = false;
         this.dataGridSavedResults.RowTemplate.Height = 23;
         this.dataGridSavedResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this.dataGridSavedResults.Size = new System.Drawing.Size(484, 86);
         this.dataGridSavedResults.TabIndex = 51;
         this.dataGridSavedResults.TabStop = false;
         this.dataGridSavedResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridSavedResults_CellContentClick);
         this.dataGridSavedResults.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridSavedResults_CellDoubleClick);
         // 
         // dataGridSavedResults_chkBoxFreezeValue
         // 
         this.dataGridSavedResults_chkBoxFreezeValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
         this.dataGridSavedResults_chkBoxFreezeValue.HeaderText = "Freeze";
         this.dataGridSavedResults_chkBoxFreezeValue.Name = "dataGridSavedResults_chkBoxFreezeValue";
         this.dataGridSavedResults_chkBoxFreezeValue.Width = 46;
         // 
         // dataGridSavedResults_txtBoxDescription
         // 
         this.dataGridSavedResults_txtBoxDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
         this.dataGridSavedResults_txtBoxDescription.FillWeight = 50F;
         this.dataGridSavedResults_txtBoxDescription.HeaderText = "Description";
         this.dataGridSavedResults_txtBoxDescription.MinimumWidth = 20;
         this.dataGridSavedResults_txtBoxDescription.Name = "dataGridSavedResults_txtBoxDescription";
         this.dataGridSavedResults_txtBoxDescription.ReadOnly = true;
         this.dataGridSavedResults_txtBoxDescription.Width = 73;
         // 
         // dataGridSavedResults_txtBoxAddress
         // 
         dataGridViewCellStyle1.Format = "X0";
         dataGridViewCellStyle1.NullValue = null;
         this.dataGridSavedResults_txtBoxAddress.DefaultCellStyle = dataGridViewCellStyle1;
         this.dataGridSavedResults_txtBoxAddress.HeaderText = "Address";
         this.dataGridSavedResults_txtBoxAddress.Name = "dataGridSavedResults_txtBoxAddress";
         this.dataGridSavedResults_txtBoxAddress.ReadOnly = true;
         this.dataGridSavedResults_txtBoxAddress.Width = 91;
         // 
         // dataGridSavedResults_txtBoxSection
         // 
         this.dataGridSavedResults_txtBoxSection.HeaderText = "Section";
         this.dataGridSavedResults_txtBoxSection.Name = "dataGridSavedResults_txtBoxSection";
         this.dataGridSavedResults_txtBoxSection.ReadOnly = true;
         this.dataGridSavedResults_txtBoxSection.Width = 90;
         // 
         // dataGridSavedResults_txtBoxValueType
         // 
         this.dataGridSavedResults_txtBoxValueType.HeaderText = "Type";
         this.dataGridSavedResults_txtBoxValueType.Name = "dataGridSavedResults_txtBoxValueType";
         this.dataGridSavedResults_txtBoxValueType.ReadOnly = true;
         this.dataGridSavedResults_txtBoxValueType.Width = 91;
         // 
         // dataGridSavedResults_txtBoxValue
         // 
         this.dataGridSavedResults_txtBoxValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
         this.dataGridSavedResults_txtBoxValue.HeaderText = "Value";
         this.dataGridSavedResults_txtBoxValue.Name = "dataGridSavedResults_txtBoxValue";
         this.dataGridSavedResults_txtBoxValue.ReadOnly = true;
         // 
         // uiStatusStrip
         // 
         this.uiStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiStatusStrip_linkSavedResults,
            this.uiStatusStrip_lblStatus});
         this.uiStatusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
         this.uiStatusStrip.Location = new System.Drawing.Point(0, 429);
         this.uiStatusStrip.Name = "uiStatusStrip";
         this.uiStatusStrip.Size = new System.Drawing.Size(484, 22);
         this.uiStatusStrip.TabIndex = 52;
         // 
         // uiStatusStrip_linkSavedResults
         // 
         this.uiStatusStrip_linkSavedResults.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.uiStatusStrip_linkSavedResults.AutoToolTip = false;
         this.uiStatusStrip_linkSavedResults.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.uiStatusStrip_linkSavedResults.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiStatusStrip_SavedResults_btnAddAddress,
            this.uiStatusStrip_SavedResults_btnAddPointer});
         this.uiStatusStrip_linkSavedResults.Enabled = false;
         this.uiStatusStrip_linkSavedResults.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.uiStatusStrip_linkSavedResults.Name = "uiStatusStrip_linkSavedResults";
         this.uiStatusStrip_linkSavedResults.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
         this.uiStatusStrip_linkSavedResults.Size = new System.Drawing.Size(81, 20);
         this.uiStatusStrip_linkSavedResults.Text = "Add entry...";
         this.uiStatusStrip_linkSavedResults.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // uiStatusStrip_SavedResults_btnAddAddress
         // 
         this.uiStatusStrip_SavedResults_btnAddAddress.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.uiStatusStrip_SavedResults_btnAddAddress.Name = "uiStatusStrip_SavedResults_btnAddAddress";
         this.uiStatusStrip_SavedResults_btnAddAddress.Size = new System.Drawing.Size(116, 22);
         this.uiStatusStrip_SavedResults_btnAddAddress.Text = "Address";
         this.uiStatusStrip_SavedResults_btnAddAddress.Click += new System.EventHandler(this.uiButtonHandler_Click);
         // 
         // uiStatusStrip_SavedResults_btnAddPointer
         // 
         this.uiStatusStrip_SavedResults_btnAddPointer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.uiStatusStrip_SavedResults_btnAddPointer.Name = "uiStatusStrip_SavedResults_btnAddPointer";
         this.uiStatusStrip_SavedResults_btnAddPointer.Size = new System.Drawing.Size(116, 22);
         this.uiStatusStrip_SavedResults_btnAddPointer.Text = "Pointer";
         this.uiStatusStrip_SavedResults_btnAddPointer.Click += new System.EventHandler(this.uiButtonHandler_Click);
         // 
         // uiStatusStrip_lblStatus
         // 
         this.uiStatusStrip_lblStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.uiStatusStrip_lblStatus.Name = "uiStatusStrip_lblStatus";
         this.uiStatusStrip_lblStatus.Size = new System.Drawing.Size(59, 17);
         this.uiStatusStrip_lblStatus.Text = "Standby...";
         // 
         // bgWorkerScanner
         // 
         this.bgWorkerScanner.WorkerReportsProgress = true;
         this.bgWorkerScanner.WorkerSupportsCancellation = true;
         this.bgWorkerScanner.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerScanner_DoWork);
         this.bgWorkerScanner.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerScanner_ProgressChanged);
         this.bgWorkerScanner.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerScanner_RunWorkerCompleted);
         // 
         // bgWorkerResultsUpdater
         // 
         this.bgWorkerResultsUpdater.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerResultsUpdater_DoWork);
         // 
         // lblProcessInfo
         // 
         this.lblProcessInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.lblProcessInfo.Name = "lblProcessInfo";
         this.lblProcessInfo.Size = new System.Drawing.Size(0, 22);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
         this.AutoSize = true;
         this.BackColor = System.Drawing.SystemColors.Control;
         this.ClientSize = new System.Drawing.Size(484, 451);
         this.Controls.Add(this.splitContainerMain);
         this.Controls.Add(this.uiToolStrip);
         this.Controls.Add(this.uiStatusStrip);
         this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.ForeColor = System.Drawing.Color.Black;
         this.MinimumSize = new System.Drawing.Size(500, 490);
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "PlayEngine";
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.uiToolStrip.ResumeLayout(false);
         this.uiToolStrip.PerformLayout();
         this.splitContainerMain.Panel1.ResumeLayout(false);
         this.splitContainerMain.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
         this.splitContainerMain.ResumeLayout(false);
         this.splitContainerScanner.Panel1.ResumeLayout(false);
         this.splitContainerScanner.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainerScanner)).EndInit();
         this.splitContainerScanner.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.listViewResults)).EndInit();
         this.splitContainerScanDetails.Panel1.ResumeLayout(false);
         this.splitContainerScanDetails.Panel1.PerformLayout();
         this.splitContainerScanDetails.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainerScanDetails)).EndInit();
         this.splitContainerScanDetails.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.chkListViewSearchSections)).EndInit();
         this.contextMenuChkListBox.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.dataGridSavedResults)).EndInit();
         this.uiStatusStrip.ResumeLayout(false);
         this.uiStatusStrip.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ToolStrip uiToolStrip;
      private System.Windows.Forms.SplitContainer splitContainerMain;
      private System.Windows.Forms.SplitContainer splitContainerScanner;
      private BrightIdeasSoftware.ObjectListView listViewResults;
      private BrightIdeasSoftware.OLVColumn columnHeaderAddress;
      private BrightIdeasSoftware.OLVColumn columnHeaderSection;
      private BrightIdeasSoftware.OLVColumn columnHeaderValue;
      private System.Windows.Forms.DataGridView dataGridSavedResults;
      private System.Windows.Forms.ToolStripDropDownButton uiToolStrip_linkFile;
      private System.Windows.Forms.ToolStripDropDownButton uiToolStrip_linkPayloadAndProcess;
      private System.Windows.Forms.ToolStripDropDownButton uiToolStrip_linkTools;
      private System.Windows.Forms.SplitContainer splitContainerScanDetails;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ComboBox cmbBoxValueType;
      private System.Windows.Forms.ComboBox cmbBoxScanType;
      private System.Windows.Forms.TextBox txtBoxScanValue;
      private System.Windows.Forms.CheckBox chkBoxIsHexValue;
      private System.Windows.Forms.Button btnScanNext;
      private System.Windows.Forms.Button btnScan;
      private BrightIdeasSoftware.ObjectListView chkListViewSearchSections;
      private BrightIdeasSoftware.OLVColumn columnHeaderSectionName;
      private BrightIdeasSoftware.OLVColumn columnHeaderSectionOffset;
      private BrightIdeasSoftware.OLVColumn columnHeaderSectionLength;
      private BrightIdeasSoftware.OLVColumn columnHeaderSectionProtection;
      private System.Windows.Forms.ContextMenuStrip contextMenuChkListBox;
      private System.Windows.Forms.ToolStripMenuItem contextMenuChkListBox_btnSelectAll;
      private System.Windows.Forms.ToolStripMenuItem uiToolStrip_btnLoadCheatTable;
      private System.Windows.Forms.ToolStripMenuItem uiToolStrip_btnSaveCheatTable;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem uiToolStrip_btnExit;
      private System.Windows.Forms.ToolStripMenuItem uiToolStrip_linkPayloadManager;
      private System.Windows.Forms.ToolStripMenuItem uiToolStrip_PayloadManager_chkPayloadActive;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripMenuItem uiToolStrip_PayloadManager_btnSendPayload;
      private System.Windows.Forms.ToolStripMenuItem uiToolStrip_linkProcessManager;
      private System.Windows.Forms.ToolStripMenuItem uiToolStrip_ProcessManager_btnRefreshProcessList;
      private System.Windows.Forms.ToolStripComboBox uiToolStrip_ProcessManager_cmbBoxActiveProcess;
      private System.Windows.Forms.ToolStripMenuItem uiToolStrip_btnOpenPointerScanner;
      private System.Windows.Forms.StatusStrip uiStatusStrip;
      private System.Windows.Forms.ToolStripLabel uiToolStrip_lblActiveProcess;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripDropDownButton uiStatusStrip_linkSavedResults;
      private System.Windows.Forms.ToolStripMenuItem uiStatusStrip_SavedResults_btnAddAddress;
      private System.Windows.Forms.ToolStripMenuItem uiStatusStrip_SavedResults_btnAddPointer;
      private System.Windows.Forms.ToolStripStatusLabel uiStatusStrip_lblStatus;
      private System.ComponentModel.BackgroundWorker bgWorkerScanner;
      private System.ComponentModel.BackgroundWorker bgWorkerResultsUpdater;
      private System.Windows.Forms.TextBox txtBoxScanValueSecond;
      private System.Windows.Forms.Label lblSecondValue;
      private System.Windows.Forms.TextBox txtBoxSectionsInclusionFilter;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.ProgressBar progressBarScanPercent;
      private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridSavedResults_chkBoxFreezeValue;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridSavedResults_txtBoxDescription;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridSavedResults_txtBoxAddress;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridSavedResults_txtBoxSection;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridSavedResults_txtBoxValueType;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridSavedResults_txtBoxValue;
      private System.Windows.Forms.TextBox txtBoxSectionsExclusionFilter;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ToolStripLabel lblProcessInfo;
   }
}