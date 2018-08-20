using System;
using System.IO;

namespace librpc.Packets {
   public partial class IPacket {
      public Byte id;
      public RPC_PACKET dataType;
      public UInt32 dataLength;

      public Byte[] serializeHeader() {
         using (MemoryStream s = new MemoryStream()) {
            s.WriteByte(id);
            s.WriteByte((Byte)dataType);
            s.Write(BitConverter.GetBytes(dataLength), 0, sizeof(UInt32));
            return s.ToArray();
         }
      }
      public static IPacket deserializeHeader(Byte[] bufPacketHeader) {
         IPacket packet = new IPacket();
         packet.id = bufPacketHeader[0];
         packet.dataType = (RPC_PACKET)bufPacketHeader[1];
         packet.dataLength = BitConverter.ToUInt32(bufPacketHeader, 2);
         return packet;
      }

      public virtual Byte[] serialize() {
         throw new InvalidOperationException();
      }
   }
}
