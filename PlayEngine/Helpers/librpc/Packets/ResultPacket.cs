using System;
using System.IO;

namespace librpc.Packets {
   public class ResultPacket : IPacket {
      public RPC_RESULT result;

      public override Byte[] serialize() {
         using (MemoryStream s = new MemoryStream()) {
            s.WriteByte((Byte)result);
            return s.ToArray();
         }
      }
   }
}
