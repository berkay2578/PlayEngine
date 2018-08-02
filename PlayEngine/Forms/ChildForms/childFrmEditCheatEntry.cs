using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PlayEngine.Forms.ChildForms {
   public partial class childFrmEditCheatEntry : Form {
      public class ReturnInformation {
         public String description;
         public librpc.MemorySection section;
         public UInt32 sectionAddressOffset;
         public Type valueType;
         public String value;
      }
      public ReturnInformation returnInformation;

      private Boolean isCreatingNewEntry = false;
      public childFrmEditCheatEntry(List<librpc.MemorySection> listMemorySections, String description, librpc.MemorySection section, UInt32 sectionAddressOffset, Type valueType, Object value,
            Int32 focusIndex = 0, Boolean isCreatingNewEntry = false) {
         this.isCreatingNewEntry = isCreatingNewEntry;

         InitializeComponent();
         cmbBoxSection.Items.AddRange(listMemorySections.ToArray());
         cmbBoxValueType.Items.AddRange(new Object[] {
            typeof(SByte), typeof(Byte),
            typeof(Int16), typeof(UInt16),
            typeof(Int32), typeof(UInt32),
            typeof(Int64), typeof(UInt64),
            typeof(Single), typeof(Double),
            typeof(String), typeof(Byte[])
         });

         if (isCreatingNewEntry) {
            this.Text = "Create new cheat entry";
            txtBoxValue.Enabled = false;
            txtBoxDescription.Select();
         } else {
            cmbBoxSection.SelectedItem = section;
            cmbBoxValueType.SelectedItem = valueType;
            txtBoxDescription.Text = description;
            txtBoxSectionAddressOffset.Text = $"0x{sectionAddressOffset.ToString("X")}";
            txtBoxValue.Text = value.ToString();

            foreach (Control cntrl in this.Controls)
               if (cntrl.TabIndex == focusIndex)
                  cntrl.Select();
         }
      }

      private void btnApply_Click(Object sender, EventArgs e) {
         if (isCreatingNewEntry) {
            if (cmbBoxSection.SelectedIndex < 0) {
               MessageBox.Show("Section cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }
            if (String.IsNullOrEmpty(txtBoxSectionAddressOffset.Text)) {
               MessageBox.Show("Section offset cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }
            if (cmbBoxValueType.SelectedIndex < 0) {
               MessageBox.Show("Value type cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }
         }

         this.returnInformation = new ReturnInformation
         {
            description = txtBoxDescription.Text,
            section = (librpc.MemorySection)cmbBoxSection.SelectedItem,
            sectionAddressOffset = UInt32.Parse(txtBoxSectionAddressOffset.Text.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber),
            valueType = (Type)cmbBoxValueType.SelectedItem,
            value = txtBoxValue.Text
         };
         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void btnCancel_Click(Object sender, EventArgs e) {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      private void uiKeyDownHandler(Object sender, KeyEventArgs e) {
         if (e.KeyCode == Keys.Enter) {
            e.SuppressKeyPress = true;
            btnApply.PerformClick();
         } else if (e.KeyCode == Keys.Escape) {
            e.SuppressKeyPress = true;
            btnCancel.PerformClick();
         }
      }
   }
}
