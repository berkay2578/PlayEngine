using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PlayEngine.Helpers.CheatManager.CheatTable.Objects {
   [Serializable]
   [XmlRoot("ComplexCheatEntry")]
   public class ComplexCheatEntry : ICheatEntry {
      [XmlArray("PointerOffsetsList")]
      [XmlArrayItem("PointerOffset")]
      public List<UInt32> listPointerOffsets = new List<UInt32>();

      [XmlElement("SectionIndex")]
      public Int32 sectionIndex;
      [XmlElement("SectionProtection")]
      public librpc.VM_PROT sectionProtection;
      [XmlElement("SectionOffset")]
      public UInt32 sectionOffset;

      public override Boolean isSimple() {
         return false;
      }
   }
}
