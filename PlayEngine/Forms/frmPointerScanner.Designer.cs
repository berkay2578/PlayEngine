namespace PlayEngine.Forms
{
    partial class PointerScanner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
         this.uiStatusStrip = new System.Windows.Forms.StatusStrip();
         this.uiStatusStrip_lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
         this.uiStatusStrip_ProgressBarScannerThread = new System.Windows.Forms.ToolStripProgressBar();
         this.txtBoxScanAddress = new System.Windows.Forms.TextBox();
         this.btnScan = new System.Windows.Forms.Button();
         this.dataGridPointerList = new System.Windows.Forms.DataGridView();
         this.btnScanNext = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.chkBoxFastScan = new System.Windows.Forms.CheckBox();
         this.uiToolStrip = new System.Windows.Forms.ToolStrip();
         this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
         this.uiToolStrip_btnLoadPointerList = new System.Windows.Forms.ToolStripMenuItem();
         this.uiToolStrip_btnSavePointerList = new System.Windows.Forms.ToolStripMenuItem();
         this.numericPointerLevel = new System.Windows.Forms.NumericUpDown();
         this.label2 = new System.Windows.Forms.Label();
         this.next_pointer_finder_worker = new System.ComponentModel.BackgroundWorker();
         this.bgWorkerScanner = new System.ComponentModel.BackgroundWorker();
         this.uiStatusStrip.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridPointerList)).BeginInit();
         this.uiToolStrip.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericPointerLevel)).BeginInit();
         this.SuspendLayout();
         // 
         // uiStatusStrip
         // 
         this.uiStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiStatusStrip_lblStatus,
            this.uiStatusStrip_ProgressBarScannerThread});
         this.uiStatusStrip.Location = new System.Drawing.Point(0, 433);
         this.uiStatusStrip.Name = "uiStatusStrip";
         this.uiStatusStrip.Size = new System.Drawing.Size(851, 23);
         this.uiStatusStrip.SizingGrip = false;
         this.uiStatusStrip.TabIndex = 2;
         // 
         // uiStatusStrip_lblStatus
         // 
         this.uiStatusStrip_lblStatus.AutoSize = false;
         this.uiStatusStrip_lblStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.uiStatusStrip_lblStatus.Name = "uiStatusStrip_lblStatus";
         this.uiStatusStrip_lblStatus.Size = new System.Drawing.Size(200, 18);
         this.uiStatusStrip_lblStatus.Text = "Standby...";
         this.uiStatusStrip_lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // uiStatusStrip_ProgressBarScannerThread
         // 
         this.uiStatusStrip_ProgressBarScannerThread.AutoSize = false;
         this.uiStatusStrip_ProgressBarScannerThread.Name = "uiStatusStrip_ProgressBarScannerThread";
         this.uiStatusStrip_ProgressBarScannerThread.Size = new System.Drawing.Size(620, 17);
         // 
         // txtBoxScanAddress
         // 
         this.txtBoxScanAddress.Location = new System.Drawing.Point(95, 25);
         this.txtBoxScanAddress.Name = "txtBoxScanAddress";
         this.txtBoxScanAddress.Size = new System.Drawing.Size(133, 20);
         this.txtBoxScanAddress.TabIndex = 3;
         // 
         // btnScan
         // 
         this.btnScan.Location = new System.Drawing.Point(567, 23);
         this.btnScan.Name = "btnScan";
         this.btnScan.Size = new System.Drawing.Size(96, 25);
         this.btnScan.TabIndex = 4;
         this.btnScan.Text = "First Scan";
         this.btnScan.UseVisualStyleBackColor = true;
         this.btnScan.Click += new System.EventHandler(this.uiButtonHandler_Click);
         // 
         // dataGridPointerList
         // 
         this.dataGridPointerList.AllowUserToAddRows = false;
         this.dataGridPointerList.AllowUserToDeleteRows = false;
         this.dataGridPointerList.AllowUserToResizeRows = false;
         this.dataGridPointerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.dataGridPointerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridPointerList.Location = new System.Drawing.Point(0, 52);
         this.dataGridPointerList.Name = "dataGridPointerList";
         this.dataGridPointerList.ReadOnly = true;
         this.dataGridPointerList.RowTemplate.Height = 23;
         this.dataGridPointerList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this.dataGridPointerList.Size = new System.Drawing.Size(851, 380);
         this.dataGridPointerList.TabIndex = 7;
         this.dataGridPointerList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pointer_list_view_CellDoubleClick);
         // 
         // btnScanNext
         // 
         this.btnScanNext.Enabled = false;
         this.btnScanNext.Location = new System.Drawing.Point(669, 23);
         this.btnScanNext.Name = "btnScanNext";
         this.btnScanNext.Size = new System.Drawing.Size(96, 25);
         this.btnScanNext.TabIndex = 8;
         this.btnScanNext.Text = "Next Scan";
         this.btnScanNext.UseVisualStyleBackColor = true;
         this.btnScanNext.Click += new System.EventHandler(this.uiButtonHandler_Click);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 29);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(77, 13);
         this.label1.TabIndex = 9;
         this.label1.Text = "Address value:";
         // 
         // chkBoxFastScan
         // 
         this.chkBoxFastScan.AutoSize = true;
         this.chkBoxFastScan.Checked = true;
         this.chkBoxFastScan.CheckState = System.Windows.Forms.CheckState.Checked;
         this.chkBoxFastScan.Location = new System.Drawing.Point(771, 28);
         this.chkBoxFastScan.Name = "chkBoxFastScan";
         this.chkBoxFastScan.Size = new System.Drawing.Size(74, 17);
         this.chkBoxFastScan.TabIndex = 10;
         this.chkBoxFastScan.Text = "Fast Scan";
         this.chkBoxFastScan.UseVisualStyleBackColor = true;
         this.chkBoxFastScan.CheckedChanged += new System.EventHandler(this.chkBoxFastScan_CheckedChanged);
         // 
         // uiToolStrip
         // 
         this.uiToolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
         this.uiToolStrip.CanOverflow = false;
         this.uiToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.uiToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
         this.uiToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
         this.uiToolStrip.Location = new System.Drawing.Point(0, 0);
         this.uiToolStrip.Name = "uiToolStrip";
         this.uiToolStrip.Size = new System.Drawing.Size(851, 22);
         this.uiToolStrip.TabIndex = 11;
         // 
         // toolStripDropDownButton1
         // 
         this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiToolStrip_btnLoadPointerList,
            this.uiToolStrip_btnSavePointerList});
         this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
         this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 19);
         this.toolStripDropDownButton1.Text = "File";
         this.toolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
         // 
         // uiToolStrip_btnLoadPointerList
         // 
         this.uiToolStrip_btnLoadPointerList.Name = "uiToolStrip_btnLoadPointerList";
         this.uiToolStrip_btnLoadPointerList.Size = new System.Drawing.Size(168, 22);
         this.uiToolStrip_btnLoadPointerList.Text = "Load pointer list...";
         this.uiToolStrip_btnLoadPointerList.Click += new System.EventHandler(this.uiButtonHandler_Click);
         // 
         // uiToolStrip_btnSavePointerList
         // 
         this.uiToolStrip_btnSavePointerList.Name = "uiToolStrip_btnSavePointerList";
         this.uiToolStrip_btnSavePointerList.Size = new System.Drawing.Size(168, 22);
         this.uiToolStrip_btnSavePointerList.Text = "Save pointer list...";
         this.uiToolStrip_btnSavePointerList.Click += new System.EventHandler(this.uiButtonHandler_Click);
         // 
         // numericPointerLevel
         // 
         this.numericPointerLevel.Location = new System.Drawing.Point(311, 26);
         this.numericPointerLevel.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
         this.numericPointerLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.numericPointerLevel.Name = "numericPointerLevel";
         this.numericPointerLevel.Size = new System.Drawing.Size(49, 20);
         this.numericPointerLevel.TabIndex = 12;
         this.numericPointerLevel.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(234, 29);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(71, 13);
         this.label2.TabIndex = 13;
         this.label2.Text = "Pointer level: ";
         // 
         // next_pointer_finder_worker
         // 
         this.next_pointer_finder_worker.WorkerReportsProgress = true;
         this.next_pointer_finder_worker.WorkerSupportsCancellation = true;
         this.next_pointer_finder_worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.next_pointer_finder_worker_DoWork);
         this.next_pointer_finder_worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.next_pointer_finder_worker_ProgressChanged);
         this.next_pointer_finder_worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.next_pointer_finder_worker_RunWorkerCompleted);
         // 
         // bgWorkerScanner
         // 
         this.bgWorkerScanner.WorkerReportsProgress = true;
         this.bgWorkerScanner.WorkerSupportsCancellation = true;
         this.bgWorkerScanner.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerScanner_DoWork);
         this.bgWorkerScanner.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerScanner_ProgressChanged);
         this.bgWorkerScanner.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerScanner_RunWorkerCompleted);
         // 
         // PointerScanner
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(851, 456);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.numericPointerLevel);
         this.Controls.Add(this.uiToolStrip);
         this.Controls.Add(this.chkBoxFastScan);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.btnScanNext);
         this.Controls.Add(this.dataGridPointerList);
         this.Controls.Add(this.btnScan);
         this.Controls.Add(this.txtBoxScanAddress);
         this.Controls.Add(this.uiStatusStrip);
         this.Name = "PointerScanner";
         this.Text = "Pointer Scanner";
         this.uiStatusStrip.ResumeLayout(false);
         this.uiStatusStrip.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridPointerList)).EndInit();
         this.uiToolStrip.ResumeLayout(false);
         this.uiToolStrip.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericPointerLevel)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip uiStatusStrip;
        private System.Windows.Forms.TextBox txtBoxScanAddress;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.ToolStripProgressBar uiStatusStrip_ProgressBarScannerThread;
        private System.Windows.Forms.DataGridView dataGridPointerList;
        private System.Windows.Forms.Button btnScanNext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel uiStatusStrip_lblStatus;
        private System.Windows.Forms.CheckBox chkBoxFastScan;
        private System.Windows.Forms.ToolStrip uiToolStrip;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem uiToolStrip_btnLoadPointerList;
        private System.Windows.Forms.ToolStripMenuItem uiToolStrip_btnSavePointerList;
      private System.Windows.Forms.NumericUpDown numericPointerLevel;
      private System.Windows.Forms.Label label2;
      private System.ComponentModel.BackgroundWorker next_pointer_finder_worker;
      private System.ComponentModel.BackgroundWorker bgWorkerScanner;
   }
}