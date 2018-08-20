using System;

namespace librpc.Packets {
   public class ProcessReadResponsePacket : IPacket {
      public Byte[] data;

      public override Byte[] serialize() {
         throw new InvalidOperationException();
      }
      public static ProcessReadResponsePacket deserialize(Byte[] bufPacket) {
         var result = new ProcessReadResponsePacket();
         result.data = new Byte[bufPacket.Length];
         Buffer.BlockCopy(bufPacket, 0, result.data, 0, bufPacket.Length);

         return result;
      }
   }
}
