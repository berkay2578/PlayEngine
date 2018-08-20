using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using PlayEngine.Helpers;

namespace librpc.Packets {
   public class ProcessInfoResponsePacket : IPacket {
      public UInt32 memorySectionsCount;
      public List<MemorySection> listMemorySections;

      public override Byte[] serialize() {
         throw new InvalidOperationException();
      }
      public static ProcessInfoResponsePacket deserialize(Byte[] bufPacket) {
         var result = new ProcessInfoResponsePacket();
         result.memorySectionsCount = BitConverter.ToUInt32(bufPacket, 0);
         result.listMemorySections = new List<MemorySection>((Int32)result.memorySectionsCount);
         for (Int32 i = 4, j = 0; i < bufPacket.Length - 1; i += Marshal.SizeOf(typeof(MemorySection)), j++) {
            result.listMemorySections.Add(new MemorySection()
            {
               name = dotNetExtensions.getNullTerminatedString(bufPacket, i),
               start = BitConverter.ToUInt64(bufPacket, i + 32),
               end = BitConverter.ToUInt64(bufPacket, i + 32 + 8),
               offset = BitConverter.ToUInt64(bufPacket, i + 32 + 8 + 8),
               protection = (VM_PROT)BitConverter.ToUInt32(bufPacket, i + 32 + 8 + 8 + 8),
               index = j
            });
         }

         return result;
      }
   }
}
