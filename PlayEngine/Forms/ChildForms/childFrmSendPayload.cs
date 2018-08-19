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
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

using PlayEngine.Helpers;

namespace PlayEngine.Forms.ChildForms {
   public partial class childFrmSendPayload : Form {
      public childFrmSendPayload() {
         InitializeComponent();
         foreach (var payloadDir in Directory.GetDirectories(Path.Combine(Application.StartupPath, "Payloads")))
            cmbBoxPayload.Items.Add(new DirectoryInfo(payloadDir).Name);
         if (cmbBoxPayload.Items.Count == 0) {
            MessageBox.Show("No payload was found inside 'Payloads/'!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.DialogResult = DialogResult.Abort;
            this.Close();
         }

         txtBoxIPAddress.Text = Settings.mInstance.ps4.IPAddress;
         txtBoxIPPort.Text = Settings.mInstance.ps4.IPPort.ToString();
         cmbBoxPayload.SelectedIndex = 0;
         if (cmbBoxPayload.Items.Count == 1) {
            cmbBoxPayload.Enabled = false;
         } else {
            if (cmbBoxPayload.Items.Contains(Settings.mInstance.ps4.LastUsedPayload))
               cmbBoxPayload.SelectedItem = Settings.mInstance.ps4.LastUsedPayload;
         }
      }

      private void btnSendPayload_Click(Object sender, EventArgs e) {
         try {
            Boolean payloadAlreadyInjected = false;
            String payloadDir = Path.Combine(Application.StartupPath, "Payloads\\" + (String)cmbBoxPayload.SelectedItem);
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)) {
               try {
                  IAsyncResult result = socket.BeginConnect(txtBoxIPAddress.Text, 2578, null, null);
                  result.AsyncWaitHandle.WaitOne(1000);
                  socket.EndConnect(result);
                  payloadAlreadyInjected = true;
               } catch { } finally {
                  socket.Close();
               }
            }
            if (payloadAlreadyInjected) {
               MessageBox.Show("Payload is already injected, connecting...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
               using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)) {
                  socket.Connect(txtBoxIPAddress.Text, Convert.ToInt32(txtBoxIPPort.Text));
                  socket.SendFile(Path.Combine(payloadDir, "payload.bin"));
                  socket.Shutdown(SocketShutdown.Both);
                  socket.Close();
               }
               MessageBox.Show("Payload successfully injected!", "Success");
            }
            Settings.mInstance.ps4.IPAddress = txtBoxIPAddress.Text;
            Settings.mInstance.ps4.IPPort = Convert.ToInt32(txtBoxIPPort.Text);
            Settings.mInstance.ps4.LastUsedPayload = (String)cmbBoxPayload.SelectedItem;
            Settings.mInstance.saveToFile();

            this.DialogResult = DialogResult.OK;
            this.Close();
         } catch (Exception ex) {
            MessageBox.Show(ex.ToString(), "Error during sending payload!", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void btnForceSendPayload_Click(Object sender, EventArgs e) {
         try {
            String payloadDir = Path.Combine(Application.StartupPath, "Payloads\\" + (String)cmbBoxPayload.SelectedItem);
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)) {
               socket.Connect(txtBoxIPAddress.Text, Convert.ToInt32(txtBoxIPPort.Text));
               socket.SendFile(Path.Combine(payloadDir, "payload.bin"));
               socket.Shutdown(SocketShutdown.Both);
               socket.Close();
               MessageBox.Show("Payload successfully injected!", "Success");
            }

            Settings.mInstance.ps4.IPAddress = txtBoxIPAddress.Text;
            Settings.mInstance.ps4.IPPort = Convert.ToInt32(txtBoxIPPort.Text);
            Settings.mInstance.ps4.LastUsedPayload = (String)cmbBoxPayload.SelectedItem;
            Settings.mInstance.saveToFile();

            this.DialogResult = DialogResult.OK;
            this.Close();
         } catch (Exception ex) {
            MessageBox.Show(ex.ToString(), "Error during force sending payload!", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }
   }
}
