/*
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
using System.Xml.Serialization;

namespace PlayEngine.Helpers.CheatManager.CheatTable {
   [Serializable]
   [XmlRoot("CheatTable")]
   public class CheatTableFile {
      [XmlIgnore]
      public static XmlSerializer serializer = null;

      [XmlElement]
      public Version TableVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

      public static CheatTableFile loadCheatTableFile(String cheatTableFilePath) {
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
   }
}
