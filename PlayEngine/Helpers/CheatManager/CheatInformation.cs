using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PlayEngine.Helpers.CheatManager {
   [Serializable]
   [XmlRoot("CheatInformation")]
   public class CheatInformation {
      [XmlArray("PointerOffsets")]
      [XmlArrayItem("Offset")]
      public List<UInt32> pointerOffsets = new List<UInt32>();

      [XmlElement]
      public UInt32 sectionAddressOffset;
   }
}
