/* golden: 12/2/2018      */
/* berkay(2578): 3/8/2018 */

using System;
using System.Collections.Generic;

namespace librpc {
   public class Process {
      public String name;
      public UInt32 id;

      /// <summary>
      /// Initializes Process class
      /// </summary>
      /// <param name="name">Process name</param>
      /// <param name="pid">Process ID</param>
      /// <returns></returns>
      public Process(String name, UInt32 pid) {
         this.name = name;
         this.id = pid;
      }
   }

   public enum VM_PROT : UInt32 {
      NONE = 0x00,
      RO = 0x01,
      WO = 0x02,
      RW = 0x03,
      XO = 0x04,
      RX = 0x05,
      WX = 0x06,
      RWX = 0x07
   }
   public class MemorySection {
      public String name;
      public UInt64 start;
      public UInt64 end;
      public UInt64 offset;
      public VM_PROT protection;

      public Int32 index;
      public UInt32 length
      {
         get {
            return (UInt32)(end - start);
         }
      }
      public override String ToString() {
         return $"{name} (0x{offset:X}-{length / 1024}KB)[{protection.ToString()}]";
      }
   }

   public class ProcessInfo {
      public UInt32 id;
      public List<MemorySection> listProcessMemorySections = new List<MemorySection>();

      /// <summary>
      /// Initializes ProcessInfo class with memory entries and process ID
      /// </summary>
      /// <param name="pid">Process ID</param>
      /// <param name="sections">Process memory sections</param>
      /// <returns></returns>
      public ProcessInfo(UInt32 pid, IEnumerable<MemorySection> sections) {
         this.id = pid;
         this.listProcessMemorySections.AddRange(sections);
      }
   }
}
