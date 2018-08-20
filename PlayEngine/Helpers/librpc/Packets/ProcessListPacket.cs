using System;
using System.Collections.Generic;

using PlayEngine.Helpers;

namespace librpc.Packets {
   public class ProcessListItem {
      public UInt32 processId;
      public String name;
   }

   public class ProcessListPacket : IPacket {
      public UInt32 processCount;
      public List<ProcessListItem> listProcesses;

      public override Byte[] serialize() {
         throw new InvalidOperationException();
      }
      public static ProcessListPacket deserialize(Byte[] bufPacket) {
         var result = new ProcessListPacket();
         result.processCount = BitConverter.ToUInt32(bufPacket, 0);
         result.listProcesses = new List<ProcessListItem>((Int32)result.processCount);
         for (Int32 i = 4; i < bufPacket.Length - 1; i += 36) {
            result.listProcesses.Add(new ProcessListItem()
            {
               processId = BitConverter.ToUInt32(bufPacket, i),
               name = dotNetExtensions.getNullTerminatedString(bufPacket, i + 4)
            });
         }

         return result;
      }
   }
}
