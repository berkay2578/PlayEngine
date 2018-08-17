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
using System.Globalization;
using System.IO;
using System.Xml.Serialization;
using PlayEngine.Helpers.CheatManager.CheatTable.Objects;

namespace PlayEngine.Helpers.CheatManager.CheatTable {
   [Serializable]
   [XmlRoot("CheatTable")]
   public class CheatTableFile {
      [XmlIgnore]
      public static XmlSerializer serializer = null;

      [XmlElement("PlayEngineVersion")]
      public Version playEngineVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
      [XmlElement("TargetProcess")]
      public String targetProcess = "eboot.bin";
      [XmlElement("CusaID")]
      public String cusaId;
      [XmlElement("CusaVersion")]
      public String cusaVersion;
      [XmlArray("CheatEntries")]
      public List<ICheatEntry> cheatEntries = new List<ICheatEntry>();

      public static Version getAssemblyVersion() {
         return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
      }

      public static CheatTableFile loadFromFile(String cheatTableFilePath) {
         if (serializer == null)
            serializer = new XmlSerializer(typeof(CheatTableFile));

         CheatTableFile cheatTable = null;
         using (StreamReader reader = new StreamReader(cheatTableFilePath))
            cheatTable = (CheatTableFile)serializer.Deserialize(reader);
         return cheatTable;
      }
      public Boolean saveToFile(String cheatTableFilePath) {
         if (serializer == null)
            serializer = new XmlSerializer(typeof(CheatTableFile));

         try {
            using (StreamWriter writer = new StreamWriter(cheatTableFilePath))
               serializer.Serialize(writer, this);
            return true;
         } catch (Exception) {
            return false;
         }
      }

      public static CheatTableFile updateOldFormat(String oldFormatFilePath) {
         if (!File.Exists(oldFormatFilePath))
            throw new FileNotFoundException("Cheat table file is not found!", oldFormatFilePath);

         String[] lines = File.ReadAllLines(oldFormatFilePath, System.Text.Encoding.UTF8);
         String[] split = lines[0].Split('|');
         if (split[0] != "1.4")
            throw new NotSupportedException($"Only PS4Cheater v1.4 cheat files are supported!\r\nThis cheat file is for v{split[0]}");
         if (split[4] != "FM:505")
            throw new NotSupportedException($"Only 5.05FW cheat files are supported!\r\nThis cheat file is for {split[4].Replace("FM:", "")}FW");

         CheatTableFile cheatTableFile = new CheatTableFile();
         cheatTableFile.targetProcess = split[1];
         cheatTableFile.cusaId = split[2].Replace("ID:", "");
         cheatTableFile.cusaVersion = split[3].Replace("VER:", "");
         for (Int32 i = 1; i < lines.Length - 1; i++) {
            split = lines[i].Split('|');
            if (lines[0] == "data") {
               ComplexCheatEntry complexCheatEntry = new ComplexCheatEntry()
               {
                  description = split[6],
                  sectionIndex = Convert.ToInt32(split[1]),
                  sectionOffset = Convert.ToUInt32(split[2], 16),
                  valueType = split[3] == "4 bytes" ? typeof(Int32) : split[3] == "float" ? typeof(Single) : throw new NotImplementedException()
               };
               cheatTableFile.cheatEntries.Add(complexCheatEntry);
            }
         }
         return cheatTableFile;
      }
   }
}
