using System;
using System.Windows.Forms;

using PlayEngine.Helpers;

namespace PlayEngine {
   internal static class Program {
      private static void onExit(Object sender, EventArgs e) {
         if (Memory.ps4RPC != null)
            Memory.ps4RPC.Disconnect();
      }

      [STAThread]
      private static void Main() {
         Settings.mInstance = Settings.loadSettings();

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.ApplicationExit += new EventHandler(onExit);
         Application.Run(new Forms.MainForm());
      }
   }
}

