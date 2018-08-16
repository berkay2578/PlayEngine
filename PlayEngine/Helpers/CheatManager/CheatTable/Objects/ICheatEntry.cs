using System;
using System.Xml.Serialization;

using PlayEngine.Helpers.MemoryClasses.ScanValueTypes;

namespace PlayEngine.Helpers.CheatManager.CheatTable.Objects {
   [Serializable]
   [XmlRoot("CheatEntry")]
   [XmlInclude(typeof(SimpleCheatEntry))]
   [XmlInclude(typeof(ComplexCheatEntry))]
   public abstract class ICheatEntry {
      [XmlElement("Description")]
      public String description;
      [XmlElement("ValueType")]
      public Type valueType;

      public abstract Boolean isSimple();
   }
}
