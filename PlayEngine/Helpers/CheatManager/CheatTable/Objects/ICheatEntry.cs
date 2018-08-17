using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PlayEngine.Helpers.CheatManager.CheatTable.Objects {
   [Serializable]
   [XmlRoot("CheatEntry")]
   [XmlInclude(typeof(ComplexCheatEntry))]
   public abstract class ICheatEntry {
      [XmlElement("Description")]
      public String description;
      [XmlElement("ValueType")]
      public Type valueType;

      [XmlArray("PointerOffsetsList")]
      [XmlArrayItem("PointerOffset")]
      public List<UInt32> listPointerOffsets = new List<UInt32>();

      public abstract Boolean isSimple();
   }
}
