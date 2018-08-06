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
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 9);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(66, 13);
         this.label1.TabIndex = 10;
         this.label1.Text = "Description: ";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(12, 36);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(51, 13);
         this.label3.TabIndex = 12;
         this.label3.Text = "Address: ";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(12, 87);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(37, 13);
         this.label4.TabIndex = 13;
         this.label4.Text = "Value:";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(12, 61);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(63, 13);
         this.label5.TabIndex = 14;
         this.label5.Text = "Value type: ";
         // 
         // txtBoxDescription
         // 
         this.txtBoxDescription.Location = new System.Drawing.Point(84, 7);
         this.txtBoxDescription.Name = "txtBoxDescription";
         this.txtBoxDescription.Size = new System.Drawing.Size(145, 20);
         this.txtBoxDescription.TabIndex = 1;
         this.txtBoxDescription.Text = "No description";
         this.txtBoxDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiKeyDownHandler);
         // 
         // txtBoxAddress
         // 
         this.txtBoxAddress.Location = new System.Drawing.Point(84, 33);
         this.txtBoxAddress.Name = "txtBoxAddress";
         this.txtBoxAddress.Size = new System.Drawing.Size(145, 20);
         this.txtBoxAddress.TabIndex = 2;
         this.txtBoxAddress.Text = "0xDEADBEEF";
         this.txtBoxAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiKeyDownHandler);
         // 
         // txtBoxValue
         // 
         this.txtBoxValue.Location = new System.Drawing.Point(84, 85);
         this.txtBoxValue.Name = "txtBoxValue";
         this.txtBoxValue.Size = new System.Drawing.Size(145, 20);
         this.txtBoxValue.TabIndex = 4;
         this.txtBoxValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiKeyDownHandler);
         // 
         // cmbBoxValueType
         // 
         this.cmbBoxValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbBoxValueType.FormattingEnabled = true;
         this.cmbBoxValueType.Location = new System.Drawing.Point(84, 59);
         this.cmbBoxValueType.Name = "cmbBoxValueType";
         this.cmbBoxValueType.Size = new System.Drawing.Size(145, 21);
         this.cmbBoxValueType.TabIndex = 3;
         // 
         // btnApply
         // 
         this.btnApply.Location = new System.Drawing.Point(73, 111);
         this.btnApply.Name = "btnApply";
         this.btnApply.Size = new System.Drawing.Size(75, 23);
         this.btnApply.TabIndex = 5;
         this.btnApply.Text = "OK";
         this.btnApply.UseVisualStyleBackColor = true;
         this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(154, 111);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 6;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // childFrmEditCheatEntry
         // 
         this.AcceptButton = this.btnApply;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(241, 147);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnApply);
         this.Controls.Add(this.cmbBoxValueType);
         this.Controls.Add(this.txtBoxValue);
         this.Controls.Add(this.txtBoxAddress);
         this.Controls.Add(this.txtBoxDescription);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "childFrmEditCheatEntry";
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Edit cheat entry";
         this.TopMost = true;
         this.ResumeLayout(false);
         this.PerformLayout();

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
   }
}