namespace PlayEngine.Forms.ChildForms {
   partial class childFrmEditCheatEntry {
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
         this.label1 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.txtBoxDescription = new System.Windows.Forms.TextBox();
         this.txtBoxAddress = new System.Windows.Forms.TextBox();
         this.txtBoxValue = new System.Windows.Forms.TextBox();
         this.cmbBoxValueType = new System.Windows.Forms.ComboBox();
         this.btnApply = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
         this.chkBoxAdvanced = new System.Windows.Forms.CheckBox();
         this.chkBoxPointer = new System.Windows.Forms.CheckBox();
         this.txtBoxSectionIndex = new System.Windows.Forms.TextBox();
         this.panel1 = new System.Windows.Forms.Panel();
         this.lblSectionIndex = new System.Windows.Forms.Label();
         this.lblSectionOffset = new System.Windows.Forms.Label();
         this.txtBoxSectionOffset = new System.Windows.Forms.TextBox();
         this.flowLayoutPanel1.SuspendLayout();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(6, 3);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(63, 13);
         this.label1.TabIndex = 10;
         this.label1.Text = "Description:";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(6, 42);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(48, 13);
         this.label3.TabIndex = 12;
         this.label3.Text = "Address:";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(6, 199);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(37, 13);
         this.label4.TabIndex = 13;
         this.label4.Text = "Value:";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(6, 159);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(60, 13);
         this.label5.TabIndex = 14;
         this.label5.Text = "Value type:";
         // 
         // txtBoxDescription
         // 
         this.txtBoxDescription.Location = new System.Drawing.Point(6, 19);
         this.txtBoxDescription.Name = "txtBoxDescription";
         this.txtBoxDescription.Size = new System.Drawing.Size(145, 20);
         this.txtBoxDescription.TabIndex = 1;
         this.txtBoxDescription.Text = "No description";
         this.txtBoxDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiKeyDownHandler);
         // 
         // txtBoxAddress
         // 
         this.txtBoxAddress.Location = new System.Drawing.Point(6, 58);
         this.txtBoxAddress.Name = "txtBoxAddress";
         this.txtBoxAddress.Size = new System.Drawing.Size(145, 20);
         this.txtBoxAddress.TabIndex = 2;
         this.txtBoxAddress.Text = "0xDEADBEEF";
         this.txtBoxAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiKeyDownHandler);
         // 
         // txtBoxValue
         // 
         this.txtBoxValue.Location = new System.Drawing.Point(6, 215);
         this.txtBoxValue.Name = "txtBoxValue";
         this.txtBoxValue.Size = new System.Drawing.Size(145, 20);
         this.txtBoxValue.TabIndex = 4;
         this.txtBoxValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiKeyDownHandler);
         // 
         // cmbBoxValueType
         // 
         this.cmbBoxValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbBoxValueType.FormattingEnabled = true;
         this.cmbBoxValueType.Location = new System.Drawing.Point(6, 175);
         this.cmbBoxValueType.Name = "cmbBoxValueType";
         this.cmbBoxValueType.Size = new System.Drawing.Size(145, 21);
         this.cmbBoxValueType.TabIndex = 3;
         // 
         // btnApply
         // 
         this.btnApply.Dock = System.Windows.Forms.DockStyle.Right;
         this.btnApply.Location = new System.Drawing.Point(14, 0);
         this.btnApply.Name = "btnApply";
         this.btnApply.Size = new System.Drawing.Size(75, 24);
         this.btnApply.TabIndex = 5;
         this.btnApply.Text = "OK";
         this.btnApply.UseVisualStyleBackColor = true;
         this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
         this.btnCancel.Location = new System.Drawing.Point(89, 0);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 24);
         this.btnCancel.TabIndex = 6;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // flowLayoutPanel1
         // 
         this.flowLayoutPanel1.Controls.Add(this.label1);
         this.flowLayoutPanel1.Controls.Add(this.txtBoxDescription);
         this.flowLayoutPanel1.Controls.Add(this.label3);
         this.flowLayoutPanel1.Controls.Add(this.txtBoxAddress);
         this.flowLayoutPanel1.Controls.Add(this.lblSectionIndex);
         this.flowLayoutPanel1.Controls.Add(this.txtBoxSectionIndex);
         this.flowLayoutPanel1.Controls.Add(this.lblSectionOffset);
         this.flowLayoutPanel1.Controls.Add(this.txtBoxSectionOffset);
         this.flowLayoutPanel1.Controls.Add(this.label5);
         this.flowLayoutPanel1.Controls.Add(this.cmbBoxValueType);
         this.flowLayoutPanel1.Controls.Add(this.label4);
         this.flowLayoutPanel1.Controls.Add(this.txtBoxValue);
         this.flowLayoutPanel1.Controls.Add(this.chkBoxAdvanced);
         this.flowLayoutPanel1.Controls.Add(this.chkBoxPointer);
         this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
         this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
         this.flowLayoutPanel1.Name = "flowLayoutPanel1";
         this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
         this.flowLayoutPanel1.Size = new System.Drawing.Size(164, 314);
         this.flowLayoutPanel1.TabIndex = 15;
         // 
         // chkBoxAdvanced
         // 
         this.chkBoxAdvanced.AutoSize = true;
         this.chkBoxAdvanced.Location = new System.Drawing.Point(6, 241);
         this.chkBoxAdvanced.Name = "chkBoxAdvanced";
         this.chkBoxAdvanced.Size = new System.Drawing.Size(75, 17);
         this.chkBoxAdvanced.TabIndex = 16;
         this.chkBoxAdvanced.Text = "Advanced";
         this.chkBoxAdvanced.UseVisualStyleBackColor = true;
         this.chkBoxAdvanced.CheckedChanged += new System.EventHandler(this.chkBoxAdvanced_CheckedChanged);
         // 
         // chkBoxPointer
         // 
         this.chkBoxPointer.AutoSize = true;
         this.chkBoxPointer.Enabled = false;
         this.chkBoxPointer.Location = new System.Drawing.Point(6, 264);
         this.chkBoxPointer.Name = "chkBoxPointer";
         this.chkBoxPointer.Size = new System.Drawing.Size(59, 17);
         this.chkBoxPointer.TabIndex = 17;
         this.chkBoxPointer.Text = "Pointer";
         this.chkBoxPointer.UseVisualStyleBackColor = true;
         // 
         // txtBoxSectionIndex
         // 
         this.txtBoxSectionIndex.Location = new System.Drawing.Point(6, 97);
         this.txtBoxSectionIndex.Name = "txtBoxSectionIndex";
         this.txtBoxSectionIndex.Size = new System.Drawing.Size(145, 20);
         this.txtBoxSectionIndex.TabIndex = 18;
         this.txtBoxSectionIndex.Text = "0";
         this.txtBoxSectionIndex.Visible = false;
         this.txtBoxSectionIndex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiKeyDownHandler);
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.btnApply);
         this.panel1.Controls.Add(this.btnCancel);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel1.Location = new System.Drawing.Point(0, 290);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(164, 24);
         this.panel1.TabIndex = 16;
         // 
         // lblSectionIndex
         // 
         this.lblSectionIndex.AutoSize = true;
         this.lblSectionIndex.Location = new System.Drawing.Point(6, 81);
         this.lblSectionIndex.Name = "lblSectionIndex";
         this.lblSectionIndex.Size = new System.Drawing.Size(74, 13);
         this.lblSectionIndex.TabIndex = 19;
         this.lblSectionIndex.Text = "Section index:";
         this.lblSectionIndex.Visible = false;
         // 
         // lblSectionOffset
         // 
         this.lblSectionOffset.AutoSize = true;
         this.lblSectionOffset.Location = new System.Drawing.Point(6, 120);
         this.lblSectionOffset.Name = "lblSectionOffset";
         this.lblSectionOffset.Size = new System.Drawing.Size(75, 13);
         this.lblSectionOffset.TabIndex = 20;
         this.lblSectionOffset.Text = "Section offset:";
         this.lblSectionOffset.Visible = false;
         // 
         // txtBoxSectionOffset
         // 
         this.txtBoxSectionOffset.Location = new System.Drawing.Point(6, 136);
         this.txtBoxSectionOffset.Name = "txtBoxSectionOffset";
         this.txtBoxSectionOffset.Size = new System.Drawing.Size(145, 20);
         this.txtBoxSectionOffset.TabIndex = 21;
         this.txtBoxSectionOffset.Text = "0xABCDEF00";
         this.txtBoxSectionOffset.Visible = false;
         this.txtBoxSectionOffset.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiKeyDownHandler);
         // 
         // childFrmEditCheatEntry
         // 
         this.AcceptButton = this.btnApply;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.AutoSize = true;
         this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(164, 314);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this.flowLayoutPanel1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "childFrmEditCheatEntry";
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Edit cheat entry";
         this.TopMost = true;
         this.flowLayoutPanel1.ResumeLayout(false);
         this.flowLayoutPanel1.PerformLayout();
         this.panel1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TextBox txtBoxDescription;
      private System.Windows.Forms.TextBox txtBoxAddress;
      private System.Windows.Forms.TextBox txtBoxValue;
      private System.Windows.Forms.ComboBox cmbBoxValueType;
      private System.Windows.Forms.Button btnApply;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
      private System.Windows.Forms.Label lblSectionIndex;
      private System.Windows.Forms.TextBox txtBoxSectionIndex;
      private System.Windows.Forms.Label lblSectionOffset;
      private System.Windows.Forms.TextBox txtBoxSectionOffset;
      private System.Windows.Forms.CheckBox chkBoxAdvanced;
      private System.Windows.Forms.CheckBox chkBoxPointer;
      private System.Windows.Forms.Panel panel1;
   }
}