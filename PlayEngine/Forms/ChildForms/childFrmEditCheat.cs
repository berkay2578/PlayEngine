using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PlayEngine.Forms.ChildForms {
   public partial class childFrmEditCheat : Form {
      public class ReturnInformation {
         public String description;
         public librpc.MemorySection section;
         public UInt32 sectionAddressOffset;
         public String valueType;
         public String value;
      }
      public ReturnInformation returnInformation;

      public childFrmEditCheat(List<librpc.MemorySection> listMemorySections, String description, librpc.MemorySection section, UInt32 sectionAddressOffset, String strValueType, Object value) {
         InitializeComponent();
         foreach (var memSection in listMemorySections)
            cmbBoxSection.Items.Add(memSection);
         cmbBoxSection.SelectedItem = section;
         cmbBoxValueType.SelectedItem = strValueType;

         txtBoxDescription.Text = description;
         txtBoxSectionAddressOffset.Text = sectionAddressOffset.ToString("X");
         txtBoxValue.Text = value.ToString();
      }

      private void btnApply_Click(Object sender, EventArgs e) {
         this.returnInformation = new ReturnInformation
         {
            description = txtBoxDescription.Text,
            section = (librpc.MemorySection)cmbBoxSection.SelectedItem,
            sectionAddressOffset = UInt32.Parse(txtBoxSectionAddressOffset.Text, System.Globalization.NumberStyles.HexNumber),
            valueType = (String)cmbBoxValueType.SelectedItem,
            value = txtBoxValue.Text
         };
         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void btnCancel_Click(Object sender, EventArgs e) {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }
   }
}
