using System;
using System.IO;
using System.Runtime.InteropServices;

namespace librpc.Packets {
   public class ProcessReadPacket : IPacket {
      public UInt32 processId;
      public UInt64 address;
      public UInt32 length;

      public override Byte[] serialize() {
         using (MemoryStream s = new MemoryStream()) {
            s.Write(BitConverter.GetBytes(processId), 0, sizeof(UInt32));
            s.Write(BitConverter.GetBytes(address), 0, sizeof(UInt64));
            s.Write(BitConverter.GetBytes(length), 0, sizeof(UInt32));
            return s.ToArray();
         }
      }

      public static UInt32 getSize() {
         return (UInt32)(Marshal.SizeOf(typeof(ProcessReadPacket)) - Marshal.SizeOf(typeof(IPacket)));
      }
   }
}
