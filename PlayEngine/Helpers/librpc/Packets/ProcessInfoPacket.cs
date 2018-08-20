using System;
using System.IO;
using System.Runtime.InteropServices;

namespace librpc.Packets {
   public class ProcessInfoPacket : IPacket {
      public UInt32 processId;

      public override Byte[] serialize() {
         using (MemoryStream s = new MemoryStream()) {
            s.Write(BitConverter.GetBytes(processId), 0, sizeof(UInt32));
            return s.ToArray();
         }
      }

      public static UInt32 getSize() {
         return (UInt32)(Marshal.SizeOf(typeof(ProcessInfoPacket)) - Marshal.SizeOf(typeof(IPacket)));
      }
   }
}
