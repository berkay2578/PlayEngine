namespace PlayEngine.Forms.ChildForms {
   partial class childFrmSendPayload {
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
         this.cmbBoxPayload = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.txtBoxIPAddress = new System.Windows.Forms.TextBox();
         this.txtBoxIPPort = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.btnSendPayload = new System.Windows.Forms.Button();
         this.btnForceSendPayload = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // cmbBoxPayload
         // 
         this.cmbBoxPayload.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbBoxPayload.FormattingEnabled = true;
         this.cmbBoxPayload.Location = new System.Drawing.Point(66, 12);
         this.cmbBoxPayload.Name = "cmbBoxPayload";
         this.cmbBoxPayload.Size = new System.Drawing.Size(161, 21);
         this.cmbBoxPayload.TabIndex = 0;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 15);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(48, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "Payload:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(12, 49);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(20, 13);
         this.label2.TabIndex = 2;
         this.label2.Text = "IP:";
         // 
         // txtBoxIPAddress
         // 
         this.txtBoxIPAddress.Location = new System.Drawing.Point(38, 46);
         this.txtBoxIPAddress.Name = "txtBoxIPAddress";
         this.txtBoxIPAddress.Size = new System.Drawing.Size(107, 20);
         this.txtBoxIPAddress.TabIndex = 3;
         // 
         // txtBoxIPPort
         // 
         this.txtBoxIPPort.Location = new System.Drawing.Point(167, 46);
         this.txtBoxIPPort.Name = "txtBoxIPPort";
         this.txtBoxIPPort.Size = new System.Drawing.Size(60, 20);
         this.txtBoxIPPort.TabIndex = 4;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(151, 49);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(10, 13);
         this.label3.TabIndex = 5;
         this.label3.Text = ":";
         // 
         // btnSendPayload
         // 
         this.btnSendPayload.Location = new System.Drawing.Point(167, 72);
         this.btnSendPayload.Name = "btnSendPayload";
         this.btnSendPayload.Size = new System.Drawing.Size(60, 23);
         this.btnSendPayload.TabIndex = 6;
         this.btnSendPayload.Text = "Send";
         this.btnSendPayload.UseVisualStyleBackColor = true;
         this.btnSendPayload.Click += new System.EventHandler(this.btnSendPayload_Click);
         // 
         // btnForceSendPayload
         // 
         this.btnForceSendPayload.Location = new System.Drawing.Point(88, 71);
         this.btnForceSendPayload.Name = "btnForceSendPayload";
         this.btnForceSendPayload.Size = new System.Drawing.Size(73, 23);
         this.btnForceSendPayload.TabIndex = 7;
         this.btnForceSendPayload.Text = "Force send";
         this.btnForceSendPayload.UseVisualStyleBackColor = true;
         this.btnForceSendPayload.Click += new System.EventHandler(this.btnForceSendPayload_Click);
         // 
         // childFrmSendPayload
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(241, 106);
         this.Controls.Add(this.btnForceSendPayload);
         this.Controls.Add(this.btnSendPayload);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.txtBoxIPPort);
         this.Controls.Add(this.txtBoxIPAddress);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.cmbBoxPayload);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "childFrmSendPayload";
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Send Payload";
         this.TopMost = true;
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ComboBox cmbBoxPayload;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox txtBoxIPAddress;
      private System.Windows.Forms.TextBox txtBoxIPPort;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Button btnSendPayload;
      private System.Windows.Forms.Button btnForceSendPayload;
   }
}