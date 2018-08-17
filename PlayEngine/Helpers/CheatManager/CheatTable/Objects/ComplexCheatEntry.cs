using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PlayEngine.Helpers.CheatManager.CheatTable.Objects {
   [Serializable]
   [XmlRoot("ComplexCheatEntry")]
   public class ComplexCheatEntry : ICheatEntry {
      [XmlElement("SectionIndex")]
      public Int32 sectionIndex;
      [XmlElement("SectionOffset")]
      public UInt32 sectionOffset;

      public override Boolean isSimple() {
         return false;
      }
   }
}
