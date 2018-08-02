/* golden: 12/2/2018      */
/* berkay(2578): 1/8/2018 */

namespace librpc {
   public class Process {
      public string name;
      public int pid;

      /// <summary>
      /// Initializes Process class
      /// </summary>
      /// <param name="name">Process name</param>
      /// <param name="pid">Process ID</param>
      /// <returns></returns>
      public Process(string name, int pid) {
         this.name = name;
         this.pid = pid;
      }
   }

   public class ProcessList {
      public Process[] processes;

      /// <summary>
      /// Initializes ProcessList class
      /// </summary>
      /// <param name="number">Number of processes</param>
      /// <param name="names">Process names</param>
      /// <param name="pids">Process IDs</param>
      /// <returns></returns>
      public ProcessList(int number, string[] names, int[] pids) {
         processes = new Process[number];
         for (int i = 0; i < number; i++) {
            processes[i] = new Process(names[i], pids[i]);
         }
      }

      /// <summary>
      /// Finds a process based off name
      /// </summary>
      /// <param name="name">Process name</param>
      /// <param name="contains">Condition to check if process name contains name</param>
      /// <returns></returns>
      public Process FindProcess(string name, bool contains = false) {
         foreach (Process p in processes) {
            if (contains) {
               if (p.name.Contains(name)) {
                  return p;
               }
            } else {
               if (p.name == name) {
                  return p;
               }
            }
         }

         return null;
      }
   }

   public enum VM_PROT {
      NONE = 0x00,
      READ = 0x01,
      WRITE = 0x02,
      RW = 0x03,
      EXEC = 0x04,
      RX = 0x05,
      WX = 0x06,
      RWX = 0x07
   }
   public class MemorySection {
      public string name;
      public ulong start;
      public ulong end;
      public ulong offset;
      public VM_PROT protection;

      public int length
      {
         get {
            return (int)(end - start);
         }
      }
      public override string ToString() {
         return $"{name}(0x{offset:X}-{length/1024}KB)[{protection.ToString()}]";
      }
   }

   public class ProcessInfo {
      public int pid;
      public MemorySection[] memorySections;

      /// <summary>
      /// Initializes ProcessInfo class with memory entries and process ID
      /// </summary>
      /// <param name="pid">Process ID</param>
      /// <param name="memorySections">Process memory sections</param>
      /// <returns></returns>
      public ProcessInfo(int pid, MemorySection[] entries) {
         this.pid = pid;
         this.memorySections = entries;
      }

      /// <summary>
      /// Finds a virtual memory entry based off name
      /// </summary>
      /// <param name="name">Virtual memory entry name</param>
      /// <returns></returns>
      public MemorySection FindEntry(string name) {
         foreach (MemorySection entry in memorySections) {
            if (entry.name == name) {
               return entry;
            }
         }

         return null;
      }

      /// <summary>
      /// Finds a virtual memory entry based off size
      /// </summary>
      /// <param name="size">Virtual memory entry size</param>
      /// <returns></returns>
      public MemorySection FindEntry(ulong size) {
         foreach (MemorySection entry in memorySections) {
            if ((entry.start - entry.end) == size) {
               return entry;
            }
         }

         return null;
      }
   }
}
