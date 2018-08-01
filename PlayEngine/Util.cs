using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Configuration;
using librpc;
using System.Collections.Generic;
using PlayEngine.Helpers;

namespace PlayEngine {

   class GameInfo {
      public const String GAME_INFO_5_05_PROCESS_NAME = "SceCdlgApp";
      public const String GAME_INFO_5_05_SECTION_NAME = "libSceCdlgUtilServer.sprx";
      public const Int32 GAME_INFO_5_05_SECTION_PROT = 3;
      public const Int32 GAME_INFO_5_05_ID_OFFSET = 0xA0;
      public const Int32 GAME_INFO_5_05_VERSION_OFFSET = 0xC8;

      public String GameID = "";
      public String Version = "";

      public GameInfo() {
         try {
            ProcessInfo processInfo = Memory.getProcessInfoFromName(GAME_INFO_5_05_PROCESS_NAME);

            var listSections = Memory.Sections.getMemorySections(processInfo);
            if (listSections.Count != 1)
               return;
            var section = listSections.Find(elm => elm.name == GAME_INFO_5_05_SECTION_NAME);

            GameID = Memory.readString(processInfo.pid, section.start + GAME_INFO_5_05_ID_OFFSET);
            Version = Memory.readString(processInfo.pid, section.start + GAME_INFO_5_05_VERSION_OFFSET);
         } catch { }
      }
   }
}
