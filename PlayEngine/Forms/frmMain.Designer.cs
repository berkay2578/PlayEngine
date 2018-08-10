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
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
         this.lblProcessInfo = new System.Windows.Forms.ToolStripLabel();
         this.splitContainerMain = new System.Windows.Forms.SplitContainer();
         this.splitContainerScanner = new System.Windows.Forms.SplitContainer();
         this.listViewResults = new BrightIdeasSoftware.ObjectListView();
         this.columnHeaderAddress = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.columnHeaderValue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.columnHeaderPreviousValue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
         this.btnScanUndo = new System.Windows.Forms.Button();
         this.panelScanControls = new System.Windows.Forms.Panel();
         this.panelSectionSearchOptions = new System.Windows.Forms.Panel();
         this.numUpDownSectionMaxLength = new System.Windows.Forms.NumericUpDown();
         this.label7 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.cmbBoxSectionsFilterProtection = new System.Windows.Forms.ComboBox();
         this.label3 = new System.Windows.Forms.Label();
         this.txtBoxSectionsFilterExclude = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.txtBoxSectionsFilterInclude = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.txtBoxScanSecondValue = new System.Windows.Forms.TextBox();
         this.lblSecondValue = new System.Windows.Forms.Label();
         this.cmbBoxScanCompareType = new System.Windows.Forms.ComboBox();
         this.cmbBoxScanValueType = new System.Windows.Forms.ComboBox();
         this.txtBoxScanValue = new System.Windows.Forms.TextBox();
         this.chkBoxIsHexValue = new System.Windows.Forms.CheckBox();
         this.btnScanNext = new System.Windows.Forms.Button();
         this.btnScan = new System.Windows.Forms.Button();
         this.dataGridSavedResults = new System.Windows.Forms.DataGridView();
         this.dataGridSavedResults_chkBoxFreezeValue = new System.Windows.Forms.DataGridViewCheckBoxColumn();
         this.dataGridSavedResults_txtBoxDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.dataGridSavedResults_txtBoxAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.dataGridSavedResults_txtBoxValueType = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.dataGridSavedResults_txtBoxValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.uiStatusStrip = new System.Windows.Forms.StatusStrip();
         this.uiStatusStrip_progressBarScanPercent = new System.Windows.Forms.ToolStripProgressBar();
         this.uiStatusStrip_linkSavedResults = new System.Windows.Forms.ToolStripDropDownButton();
         this.uiStatusStrip_SavedResults_btnAddAddress = new System.Windows.Forms.ToolStripMenuItem();
         this.uiStatusStrip_SavedResults_btnAddPointer = new System.Windows.Forms.ToolStripMenuItem();
         this.uiStatusStrip_lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
         this.bgWorkerScanner = new System.ComponentModel.BackgroundWorker();
         this.bgWorkerResultsUpdater = new System.ComponentModel.BackgroundWorker();
         this.bgWorkerValueFreezer = new System.ComponentModel.BackgroundWorker();
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
         this.panelScanControls.SuspendLayout();
         this.panelSectionSearchOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numUpDownSectionMaxLength)).BeginInit();
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
         // lblProcessInfo
         // 
         this.lblProcessInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.lblProcessInfo.Name = "lblProcessInfo";
         this.lblProcessInfo.Size = new System.Drawing.Size(0, 22);
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
         this.splitContainerMain.Panel1MinSize = 280;
         // 
         // splitContainerMain.Panel2
         // 
         this.splitContainerMain.Panel2.Controls.Add(this.dataGridSavedResults);
         this.splitContainerMain.Panel2MinSize = 50;
         this.splitContainerMain.Size = new System.Drawing.Size(484, 404);
         this.splitContainerMain.SplitterDistance = 280;
         this.splitContainerMain.SplitterWidth = 3;
         this.splitContainerMain.TabIndex = 1;
         // 
         // splitContainerScanner
         // 
         this.splitContainerScanner.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainerScanner.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
         this.splitContainerScanner.IsSplitterFixed = true;
         this.splitContainerScanner.Location = new System.Drawing.Point(0, 0);
         this.splitContainerScanner.Name = "splitContainerScanner";
         // 
         // splitContainerScanner.Panel1
         // 
         this.splitContainerScanner.Panel1.Controls.Add(this.listViewResults);
         this.splitContainerScanner.Panel1MinSize = 250;
         // 
         // splitContainerScanner.Panel2
         // 
         this.splitContainerScanner.Panel2.Controls.Add(this.btnScanUndo);
         this.splitContainerScanner.Panel2.Controls.Add(this.panelScanControls);
         this.splitContainerScanner.Panel2.Controls.Add(this.btnScanNext);
         this.splitContainerScanner.Panel2.Controls.Add(this.btnScan);
         this.splitContainerScanner.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
         this.splitContainerScanner.Panel2MinSize = 160;
         this.splitContainerScanner.Size = new System.Drawing.Size(484, 280);
         this.splitContainerScanner.SplitterDistance = 262;
         this.splitContainerScanner.SplitterWidth = 1;
         this.splitContainerScanner.TabIndex = 15;
         // 
         // listViewResults
         // 
         this.listViewResults.AllColumns.Add(this.columnHeaderAddress);
         this.listViewResults.AllColumns.Add(this.columnHeaderValue);
         this.listViewResults.AllColumns.Add(this.columnHeaderPreviousValue);
         this.listViewResults.AutoArrange = false;
         this.listViewResults.BackColor = System.Drawing.SystemColors.Control;
         this.listViewResults.CellEditUseWholeCell = false;
         this.listViewResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderAddress,
            this.columnHeaderValue,
            this.columnHeaderPreviousValue});
         this.listViewResults.Cursor = System.Windows.Forms.Cursors.Default;
         this.listViewResults.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listViewResults.FullRowSelect = true;
         this.listViewResults.HideSelection = false;
         this.listViewResults.Location = new System.Drawing.Point(0, 0);
         this.listViewResults.Name = "listViewResults";
         this.listViewResults.ShowGroups = false;
         this.listViewResults.ShowItemToolTips = true;
         this.listViewResults.Size = new System.Drawing.Size(262, 280);
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
         this.columnHeaderAddress.UseFiltering = false;
         this.columnHeaderAddress.Width = 95;
         // 
         // columnHeaderValue
         // 
         this.columnHeaderValue.AspectName = "memoryValue";
         this.columnHeaderValue.IsEditable = false;
         this.columnHeaderValue.Searchable = false;
         this.columnHeaderValue.Text = "Value";
         this.columnHeaderValue.UseFiltering = false;
         this.columnHeaderValue.Width = 65;
         // 
         // columnHeaderPreviousValue
         // 
         this.columnHeaderPreviousValue.AspectName = "previousMemoryValue";
         this.columnHeaderPreviousValue.IsEditable = false;
         this.columnHeaderPreviousValue.Searchable = false;
         this.columnHeaderPreviousValue.Text = "Previous";
         this.columnHeaderPreviousValue.UseFiltering = false;
         this.columnHeaderPreviousValue.Width = 70;
         // 
         // btnScanUndo
         // 
         this.btnScanUndo.Enabled = false;
         this.btnScanUndo.Location = new System.Drawing.Point(145, 3);
         this.btnScanUndo.Name = "btnScanUndo";
         this.btnScanUndo.Size = new System.Drawing.Size(76, 23);
         this.btnScanUndo.TabIndex = 40;
         this.btnScanUndo.Text = "Undo Scan";
         this.btnScanUndo.UseVisualStyleBackColor = true;
         this.btnScanUndo.Click += new System.EventHandler(this.uiButtonHandler_Click);
         // 
         // panelScanControls
         // 
         this.panelScanControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.panelScanControls.Controls.Add(this.panelSectionSearchOptions);
         this.panelScanControls.Controls.Add(this.label5);
         this.panelScanControls.Controls.Add(this.label4);
         this.panelScanControls.Controls.Add(this.txtBoxScanSecondValue);
         this.panelScanControls.Controls.Add(this.lblSecondValue);
         this.panelScanControls.Controls.Add(this.cmbBoxScanCompareType);
         this.panelScanControls.Controls.Add(this.cmbBoxScanValueType);
         this.panelScanControls.Controls.Add(this.txtBoxScanValue);
         this.panelScanControls.Controls.Add(this.chkBoxIsHexValue);
         this.panelScanControls.Location = new System.Drawing.Point(0, 32);
         this.panelScanControls.Name = "panelScanControls";
         this.panelScanControls.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
         this.panelScanControls.Size = new System.Drawing.Size(220, 248);
         this.panelScanControls.TabIndex = 39;
         // 
         // panelSectionSearchOptions
         // 
         this.panelSectionSearchOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.panelSectionSearchOptions.Controls.Add(this.numUpDownSectionMaxLength);
         this.panelSectionSearchOptions.Controls.Add(this.label7);
         this.panelSectionSearchOptions.Controls.Add(this.label6);
         this.panelSectionSearchOptions.Controls.Add(this.cmbBoxSectionsFilterProtection);
         this.panelSectionSearchOptions.Controls.Add(this.label3);
         this.panelSectionSearchOptions.Controls.Add(this.txtBoxSectionsFilterExclude);
         this.panelSectionSearchOptions.Controls.Add(this.label1);
         this.panelSectionSearchOptions.Controls.Add(this.txtBoxSectionsFilterInclude);
         this.panelSectionSearchOptions.Controls.Add(this.label2);
         this.panelSectionSearchOptions.Location = new System.Drawing.Point(0, 103);
         this.panelSectionSearchOptions.Name = "panelSectionSearchOptions";
         this.panelSectionSearchOptions.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
         this.panelSectionSearchOptions.Size = new System.Drawing.Size(220, 130);
         this.panelSectionSearchOptions.TabIndex = 58;
         // 
         // numUpDownSectionMaxLength
         // 
         this.numUpDownSectionMaxLength.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.numUpDownSectionMaxLength.Increment = new decimal(new int[] {
            1024,
            0,
            0,
            0});
         this.numUpDownSectionMaxLength.Location = new System.Drawing.Point(148, 100);
         this.numUpDownSectionMaxLength.Maximum = new decimal(new int[] {
            1073741824,
            0,
            0,
            0});
         this.numUpDownSectionMaxLength.Name = "numUpDownSectionMaxLength";
         this.numUpDownSectionMaxLength.Size = new System.Drawing.Size(65, 23);
         this.numUpDownSectionMaxLength.TabIndex = 64;
         this.numUpDownSectionMaxLength.Value = new decimal(new int[] {
            51200,
            0,
            0,
            0});
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(0, 102);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(149, 15);
         this.label7.TabIndex = 63;
         this.label7.Text = "Size must be under (bytes):";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label6.Location = new System.Drawing.Point(2, 6);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(131, 15);
         this.label6.TabIndex = 62;
         this.label6.Text = "Section Search Options";
         // 
         // cmbBoxSectionsFilterProtection
         // 
         this.cmbBoxSectionsFilterProtection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cmbBoxSectionsFilterProtection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbBoxSectionsFilterProtection.DropDownWidth = 100;
         this.cmbBoxSectionsFilterProtection.FormattingEnabled = true;
         this.cmbBoxSectionsFilterProtection.Location = new System.Drawing.Point(148, 74);
         this.cmbBoxSectionsFilterProtection.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
         this.cmbBoxSectionsFilterProtection.Name = "cmbBoxSectionsFilterProtection";
         this.cmbBoxSectionsFilterProtection.Size = new System.Drawing.Size(65, 23);
         this.cmbBoxSectionsFilterProtection.TabIndex = 61;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(2, 77);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(143, 15);
         this.label3.TabIndex = 60;
         this.label3.Text = "Page protection must be: ";
         // 
         // txtBoxSectionsFilterExclude
         // 
         this.txtBoxSectionsFilterExclude.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtBoxSectionsFilterExclude.Location = new System.Drawing.Point(148, 49);
         this.txtBoxSectionsFilterExclude.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
         this.txtBoxSectionsFilterExclude.Name = "txtBoxSectionsFilterExclude";
         this.txtBoxSectionsFilterExclude.Size = new System.Drawing.Size(65, 23);
         this.txtBoxSectionsFilterExclude.TabIndex = 57;
         this.txtBoxSectionsFilterExclude.Text = "Sce";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(2, 52);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(144, 15);
         this.label1.TabIndex = 59;
         this.label1.Text = "Name must NOT include: ";
         // 
         // txtBoxSectionsFilterInclude
         // 
         this.txtBoxSectionsFilterInclude.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtBoxSectionsFilterInclude.Location = new System.Drawing.Point(118, 24);
         this.txtBoxSectionsFilterInclude.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
         this.txtBoxSectionsFilterInclude.Name = "txtBoxSectionsFilterInclude";
         this.txtBoxSectionsFilterInclude.Size = new System.Drawing.Size(95, 23);
         this.txtBoxSectionsFilterInclude.TabIndex = 56;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(2, 27);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(117, 15);
         this.label2.TabIndex = 58;
         this.label2.Text = "Name must include: ";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(-1, 78);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(67, 15);
         this.label5.TabIndex = 57;
         this.label5.Text = "Value type: ";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(2, 53);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(64, 15);
         this.label4.TabIndex = 56;
         this.label4.Text = "Scan type: ";
         // 
         // txtBoxScanSecondValue
         // 
         this.txtBoxScanSecondValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtBoxScanSecondValue.Enabled = false;
         this.txtBoxScanSecondValue.Location = new System.Drawing.Point(72, 25);
         this.txtBoxScanSecondValue.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
         this.txtBoxScanSecondValue.Name = "txtBoxScanSecondValue";
         this.txtBoxScanSecondValue.Size = new System.Drawing.Size(141, 23);
         this.txtBoxScanSecondValue.TabIndex = 46;
         this.txtBoxScanSecondValue.Text = "0";
         this.txtBoxScanSecondValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiKeyDownHandler);
         // 
         // lblSecondValue
         // 
         this.lblSecondValue.AutoSize = true;
         this.lblSecondValue.Enabled = false;
         this.lblSecondValue.Location = new System.Drawing.Point(5, 28);
         this.lblSecondValue.Name = "lblSecondValue";
         this.lblSecondValue.Size = new System.Drawing.Size(61, 15);
         this.lblSecondValue.TabIndex = 51;
         this.lblSecondValue.Text = "2nd value:";
         // 
         // cmbBoxScanCompareType
         // 
         this.cmbBoxScanCompareType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cmbBoxScanCompareType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbBoxScanCompareType.FormattingEnabled = true;
         this.cmbBoxScanCompareType.Location = new System.Drawing.Point(72, 50);
         this.cmbBoxScanCompareType.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
         this.cmbBoxScanCompareType.Name = "cmbBoxScanCompareType";
         this.cmbBoxScanCompareType.Size = new System.Drawing.Size(141, 23);
         this.cmbBoxScanCompareType.TabIndex = 47;
         this.cmbBoxScanCompareType.SelectedIndexChanged += new System.EventHandler(this.cmbBoxScanCompareType_SelectedIndexChanged);
         // 
         // cmbBoxScanValueType
         // 
         this.cmbBoxScanValueType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cmbBoxScanValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbBoxScanValueType.DropDownWidth = 200;
         this.cmbBoxScanValueType.FormattingEnabled = true;
         this.cmbBoxScanValueType.Location = new System.Drawing.Point(72, 75);
         this.cmbBoxScanValueType.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
         this.cmbBoxScanValueType.Name = "cmbBoxScanValueType";
         this.cmbBoxScanValueType.Size = new System.Drawing.Size(141, 23);
         this.cmbBoxScanValueType.TabIndex = 48;
         this.cmbBoxScanValueType.SelectedIndexChanged += new System.EventHandler(this.cmbBoxScanValueType_SelectedIndexChanged);
         // 
         // txtBoxScanValue
         // 
         this.txtBoxScanValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtBoxScanValue.Location = new System.Drawing.Point(72, 0);
         this.txtBoxScanValue.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
         this.txtBoxScanValue.Name = "txtBoxScanValue";
         this.txtBoxScanValue.Size = new System.Drawing.Size(141, 23);
         this.txtBoxScanValue.TabIndex = 45;
         this.txtBoxScanValue.Text = "0";
         this.txtBoxScanValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiKeyDownHandler);
         // 
         // chkBoxIsHexValue
         // 
         this.chkBoxIsHexValue.AutoSize = true;
         this.chkBoxIsHexValue.Location = new System.Drawing.Point(20, 2);
         this.chkBoxIsHexValue.Name = "chkBoxIsHexValue";
         this.chkBoxIsHexValue.Size = new System.Drawing.Size(46, 19);
         this.chkBoxIsHexValue.TabIndex = 44;
         this.chkBoxIsHexValue.Text = "Hex";
         this.chkBoxIsHexValue.UseVisualStyleBackColor = true;
         // 
         // btnScanNext
         // 
         this.btnScanNext.Location = new System.Drawing.Point(73, 3);
         this.btnScanNext.Name = "btnScanNext";
         this.btnScanNext.Size = new System.Drawing.Size(70, 23);
         this.btnScanNext.TabIndex = 27;
         this.btnScanNext.Text = "Next Scan";
         this.btnScanNext.UseVisualStyleBackColor = true;
         this.btnScanNext.Click += new System.EventHandler(this.uiButtonHandler_Click);
         // 
         // btnScan
         // 
         this.btnScan.Location = new System.Drawing.Point(5, 3);
         this.btnScan.Name = "btnScan";
         this.btnScan.Size = new System.Drawing.Size(68, 23);
         this.btnScan.TabIndex = 26;
         this.btnScan.Text = "First Scan";
         this.btnScan.UseVisualStyleBackColor = true;
         this.btnScan.Click += new System.EventHandler(this.uiButtonHandler_Click);
         // 
         // dataGridSavedResults
         // 
         this.dataGridSavedResults.AllowUserToAddRows = false;
         this.dataGridSavedResults.AllowUserToResizeRows = false;
         this.dataGridSavedResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
         this.dataGridSavedResults.BackgroundColor = System.Drawing.SystemColors.Window;
         this.dataGridSavedResults.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
         this.dataGridSavedResults.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
         dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
         dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
         dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
         dataGridViewCellStyle1.NullValue = "null";
         dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
         dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
         dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
         this.dataGridSavedResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
         this.dataGridSavedResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridSavedResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridSavedResults_chkBoxFreezeValue,
            this.dataGridSavedResults_txtBoxDescription,
            this.dataGridSavedResults_txtBoxAddress,
            this.dataGridSavedResults_txtBoxValueType,
            this.dataGridSavedResults_txtBoxValue});
         this.dataGridSavedResults.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridSavedResults.Location = new System.Drawing.Point(0, 0);
         this.dataGridSavedResults.Name = "dataGridSavedResults";
         this.dataGridSavedResults.RowHeadersVisible = false;
         this.dataGridSavedResults.RowTemplate.Height = 23;
         this.dataGridSavedResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this.dataGridSavedResults.Size = new System.Drawing.Size(484, 121);
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
         dataGridViewCellStyle2.Format = "X0";
         dataGridViewCellStyle2.NullValue = null;
         this.dataGridSavedResults_txtBoxAddress.DefaultCellStyle = dataGridViewCellStyle2;
         this.dataGridSavedResults_txtBoxAddress.HeaderText = "Address";
         this.dataGridSavedResults_txtBoxAddress.Name = "dataGridSavedResults_txtBoxAddress";
         this.dataGridSavedResults_txtBoxAddress.ReadOnly = true;
         // 
         // dataGridSavedResults_txtBoxValueType
         // 
         this.dataGridSavedResults_txtBoxValueType.HeaderText = "Type";
         this.dataGridSavedResults_txtBoxValueType.Name = "dataGridSavedResults_txtBoxValueType";
         this.dataGridSavedResults_txtBoxValueType.ReadOnly = true;
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
            this.uiStatusStrip_progressBarScanPercent,
            this.uiStatusStrip_linkSavedResults,
            this.uiStatusStrip_lblStatus});
         this.uiStatusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
         this.uiStatusStrip.Location = new System.Drawing.Point(0, 429);
         this.uiStatusStrip.Name = "uiStatusStrip";
         this.uiStatusStrip.Size = new System.Drawing.Size(484, 22);
         this.uiStatusStrip.TabIndex = 52;
         // 
         // uiStatusStrip_progressBarScanPercent
         // 
         this.uiStatusStrip_progressBarScanPercent.Name = "uiStatusStrip_progressBarScanPercent";
         this.uiStatusStrip_progressBarScanPercent.Size = new System.Drawing.Size(100, 16);
         this.uiStatusStrip_progressBarScanPercent.Step = 1;
         this.uiStatusStrip_progressBarScanPercent.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
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
         // bgWorkerValueFreezer
         // 
         this.bgWorkerValueFreezer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerValueFreezer_DoWork);
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
         this.panelScanControls.ResumeLayout(false);
         this.panelScanControls.PerformLayout();
         this.panelSectionSearchOptions.ResumeLayout(false);
         this.panelSectionSearchOptions.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numUpDownSectionMaxLength)).EndInit();
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
      private BrightIdeasSoftware.OLVColumn columnHeaderValue;
      private System.Windows.Forms.DataGridView dataGridSavedResults;
      private System.Windows.Forms.ToolStripDropDownButton uiToolStrip_linkFile;
      private System.Windows.Forms.ToolStripDropDownButton uiToolStrip_linkPayloadAndProcess;
      private System.Windows.Forms.ToolStripDropDownButton uiToolStrip_linkTools;
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
      private System.Windows.Forms.ToolStripLabel lblProcessInfo;
      private System.Windows.Forms.Button btnScanNext;
      private System.Windows.Forms.Button btnScan;
      private BrightIdeasSoftware.OLVColumn columnHeaderPreviousValue;
      private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridSavedResults_chkBoxFreezeValue;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridSavedResults_txtBoxDescription;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridSavedResults_txtBoxAddress;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridSavedResults_txtBoxValueType;
      private System.Windows.Forms.DataGridViewTextBoxColumn dataGridSavedResults_txtBoxValue;
      private System.Windows.Forms.Panel panelScanControls;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.TextBox txtBoxScanSecondValue;
      private System.Windows.Forms.Label lblSecondValue;
      private System.Windows.Forms.ComboBox cmbBoxScanCompareType;
      private System.Windows.Forms.ComboBox cmbBoxScanValueType;
      private System.Windows.Forms.TextBox txtBoxScanValue;
      private System.Windows.Forms.CheckBox chkBoxIsHexValue;
      private System.Windows.Forms.Panel panelSectionSearchOptions;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.ComboBox cmbBoxSectionsFilterProtection;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox txtBoxSectionsFilterExclude;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox txtBoxSectionsFilterInclude;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Button btnScanUndo;
      private System.Windows.Forms.ToolStripProgressBar uiStatusStrip_progressBarScanPercent;
      private System.Windows.Forms.NumericUpDown numUpDownSectionMaxLength;
      private System.Windows.Forms.Label label7;
      private System.ComponentModel.BackgroundWorker bgWorkerValueFreezer;
   }
}