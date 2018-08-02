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

      public childFrmEditCheatEntry(List<librpc.MemorySection> listMemorySections, String description, librpc.MemorySection section, UInt32 sectionAddressOffset, Type valueType, Object value,
            Int32 focusIndex) {
         InitializeComponent();
         cmbBoxSection.Items.AddRange(listMemorySections.ToArray());
         cmbBoxSection.SelectedItem = section;

         cmbBoxValueType.Items.AddRange(new Object[] {
            typeof(SByte), typeof(Byte),
            typeof(Int16), typeof(UInt16),
            typeof(Int32), typeof(UInt32),
            typeof(Int64), typeof(UInt64),
            typeof(Single), typeof(Double),
            typeof(String), typeof(Byte[])
         });
         cmbBoxValueType.SelectedItem = valueType;

         txtBoxDescription.Text = description;
         txtBoxSectionAddressOffset.Text = sectionAddressOffset.ToString("X");
         txtBoxValue.Text = value.ToString();

         foreach (Control cntrl in this.Controls)
            if (cntrl.TabIndex == focusIndex)
               cntrl.Select();
      }

      private void btnApply_Click(Object sender, EventArgs e) {
         this.returnInformation = new ReturnInformation
         {
            description = txtBoxDescription.Text,
            section = (librpc.MemorySection)cmbBoxSection.SelectedItem,
            sectionAddressOffset = UInt32.Parse(txtBoxSectionAddressOffset.Text, System.Globalization.NumberStyles.HexNumber),
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
