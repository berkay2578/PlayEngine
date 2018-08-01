namespace PlayEngine.Forms.ChildForms {
   partial class childFrmEditCheat {
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
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.txtBoxDescription = new System.Windows.Forms.TextBox();
         this.txtBoxSectionAddressOffset = new System.Windows.Forms.TextBox();
         this.txtBoxValue = new System.Windows.Forms.TextBox();
         this.cmbBoxSection = new System.Windows.Forms.ComboBox();
         this.cmbBoxValueType = new System.Windows.Forms.ComboBox();
         this.btnApply = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 9);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(66, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Description: ";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(12, 35);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(46, 13);
         this.label2.TabIndex = 1;
         this.label2.Text = "Section:";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(12, 61);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(75, 13);
         this.label3.TabIndex = 2;
         this.label3.Text = "Section offset:";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(12, 113);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(37, 13);
         this.label4.TabIndex = 3;
         this.label4.Text = "Value:";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(12, 87);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(63, 13);
         this.label5.TabIndex = 4;
         this.label5.Text = "Value type: ";
         // 
         // txtBoxDescription
         // 
         this.txtBoxDescription.Location = new System.Drawing.Point(84, 7);
         this.txtBoxDescription.Name = "txtBoxDescription";
         this.txtBoxDescription.Size = new System.Drawing.Size(145, 20);
         this.txtBoxDescription.TabIndex = 5;
         this.txtBoxDescription.Text = "No description";
         // 
         // txtBoxSectionAddressOffset
         // 
         this.txtBoxSectionAddressOffset.Location = new System.Drawing.Point(93, 59);
         this.txtBoxSectionAddressOffset.Name = "txtBoxSectionAddressOffset";
         this.txtBoxSectionAddressOffset.Size = new System.Drawing.Size(136, 20);
         this.txtBoxSectionAddressOffset.TabIndex = 7;
         // 
         // txtBoxValue
         // 
         this.txtBoxValue.Location = new System.Drawing.Point(84, 111);
         this.txtBoxValue.Name = "txtBoxValue";
         this.txtBoxValue.Size = new System.Drawing.Size(145, 20);
         this.txtBoxValue.TabIndex = 9;
         // 
         // cmbBoxSection
         // 
         this.cmbBoxSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbBoxSection.FormattingEnabled = true;
         this.cmbBoxSection.Location = new System.Drawing.Point(84, 33);
         this.cmbBoxSection.Name = "cmbBoxSection";
         this.cmbBoxSection.Size = new System.Drawing.Size(145, 21);
         this.cmbBoxSection.TabIndex = 10;
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
         this.cmbBoxValueType.Location = new System.Drawing.Point(84, 85);
         this.cmbBoxValueType.Name = "cmbBoxValueType";
         this.cmbBoxValueType.Size = new System.Drawing.Size(145, 21);
         this.cmbBoxValueType.TabIndex = 11;
         // 
         // btnApply
         // 
         this.btnApply.Location = new System.Drawing.Point(73, 137);
         this.btnApply.Name = "btnApply";
         this.btnApply.Size = new System.Drawing.Size(75, 23);
         this.btnApply.TabIndex = 12;
         this.btnApply.Text = "OK";
         this.btnApply.UseVisualStyleBackColor = true;
         this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(154, 137);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 13;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // childFrmEditCheat
         // 
         this.AcceptButton = this.btnApply;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(241, 170);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnApply);
         this.Controls.Add(this.cmbBoxValueType);
         this.Controls.Add(this.cmbBoxSection);
         this.Controls.Add(this.txtBoxValue);
         this.Controls.Add(this.txtBoxSectionAddressOffset);
         this.Controls.Add(this.txtBoxDescription);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "childFrmEditCheat";
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Edit Cheat";
         this.TopMost = true;
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TextBox txtBoxDescription;
      private System.Windows.Forms.TextBox txtBoxSectionAddressOffset;
      private System.Windows.Forms.TextBox txtBoxValue;
      private System.Windows.Forms.ComboBox cmbBoxSection;
      private System.Windows.Forms.ComboBox cmbBoxValueType;
      private System.Windows.Forms.Button btnApply;
      private System.Windows.Forms.Button btnCancel;
   }
}