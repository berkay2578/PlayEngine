using System;
using System.IO;
using System.Runtime.InteropServices;

namespace librpc.Packets {
   public class ProcessWritePacket : IPacket {
      public UInt32 processId;
      public UInt64 address;
      public UInt32 length;
      public Byte[] data;

      public override Byte[] serialize() {
         using (MemoryStream s = new MemoryStream()) {
            s.Write(BitConverter.GetBytes(processId), 0, sizeof(UInt32));
            s.Write(BitConverter.GetBytes(address), 0, sizeof(UInt64));
            s.Write(BitConverter.GetBytes(length), 0, sizeof(UInt32));
            s.Write(data, 0, data.Length);
            return s.ToArray();
         }
      }

      public static UInt32 getSize() {
         return (UInt32)(Marshal.SizeOf(typeof(ProcessWritePacket)) - Marshal.SizeOf(typeof(IPacket)));
      }
   }
}
