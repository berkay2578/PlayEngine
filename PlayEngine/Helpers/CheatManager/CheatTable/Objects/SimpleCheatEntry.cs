using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PlayEngine.Helpers.CheatManager.CheatTable.Objects {
   [Serializable]
   [XmlRoot("SimpleCheatEntry")]
   public class SimpleCheatEntry : ICheatEntry {
      [XmlArray("PointerOffsetsList")]
      [XmlArrayItem("PointerOffset")]
      public List<UInt32> listPointerOffsets = new List<UInt32>();

      [XmlElement("Address")]
      public UInt64 address;

      public override Boolean isSimple() {
         return true;
      }
   }
}
