using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PlayEngine.Helpers.CheatManager {
   [Serializable]
   [XmlRoot("CheatInformation")]
   public class CheatInformation {
      [XmlIgnore]
      public Boolean isFrozen = false;

      [XmlArray("PointerOffsets")]
      [XmlArrayItem("Offset")]
      public List<UInt32> pointerOffsets = new List<UInt32>();

      [XmlElement]
      public UInt32 sectionAddressOffset;
   }
}
