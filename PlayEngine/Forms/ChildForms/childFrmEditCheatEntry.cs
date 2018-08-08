/*
   PlayEngine - Cheat Engine for the PS4

   MIT License
   
   Copyright (c) 2018 Berkay Yigit
   
   Permission is hereby granted, free of charge, to any person obtaining a copy
   of this software and associated documentation files (the "Software"), to deal
   in the Software without restriction, including without limitation the rights
   to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
   copies of the Software, and to permit persons to whom the Software is
   furnished to do so, subject to the following conditions:
   
   The above copyright notice and this permission notice shall be included in all
   copies or substantial portions of the Software.
   
   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
   IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
   FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
   AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
   LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
   OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
   SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PlayEngine.Forms.ChildForms {
   public partial class childFrmEditCheatEntry : Form {
      public class ReturnInformation {
         public String description;
         public UInt64 address;
         public Type valueType;
         public String value;
      }
      public ReturnInformation returnInformation;

      private Boolean isCreatingNewEntry = false;
      public childFrmEditCheatEntry(String description, UInt64 address, Type valueType, String value, Int32 focusIndex = 0, Boolean isCreatingNewEntry = false) {
         this.isCreatingNewEntry = isCreatingNewEntry;

         InitializeComponent();
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
            txtBoxDescription.Text = description;
            txtBoxAddress.Text = $"0x{address.ToString("X")}";
            cmbBoxValueType.SelectedItem = valueType;
            txtBoxValue.Text = value;

            foreach (Control cntrl in this.Controls)
               if (cntrl.TabIndex == focusIndex)
                  cntrl.Select();
         }
      }

      private void btnApply_Click(Object sender, EventArgs e) {
         if (isCreatingNewEntry) {
            if (String.IsNullOrEmpty(txtBoxAddress.Text)) {
               MessageBox.Show("Address cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            address = UInt64.Parse(txtBoxAddress.Text.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber),
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
