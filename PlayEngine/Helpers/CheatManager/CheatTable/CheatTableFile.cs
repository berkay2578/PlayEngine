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
