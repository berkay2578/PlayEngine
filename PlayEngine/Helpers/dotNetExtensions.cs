using System;
using System.Text;

namespace PlayEngine.Helpers {
   public static class dotNetExtensions {
      public static Boolean Contains(this String source, String toCheck, StringComparison comparison = StringComparison.OrdinalIgnoreCase) {
         return source != null && toCheck != null && source.IndexOf(toCheck, comparison) >= 0;
      }

      public static dynamic getObject(this byte[] byteArray, Type objectType) {
         switch (Type.GetTypeCode(objectType)) {
            case TypeCode.Boolean:
               return BitConverter.ToBoolean(byteArray, 0);
            case TypeCode.Byte:
               return byteArray[0];
            case TypeCode.Char:
               return Encoding.UTF8.GetChars(byteArray)[0];
            case TypeCode.Double:
               return BitConverter.ToDouble(byteArray, 0);
            case TypeCode.Single:
               return BitConverter.ToSingle(byteArray, 0);
            case TypeCode.Int16:
               return BitConverter.ToInt16(byteArray, 0);
            case TypeCode.Int32:
               return BitConverter.ToInt32(byteArray, 0);
            case TypeCode.Int64:
               return BitConverter.ToInt64(byteArray, 0);
            case TypeCode.UInt16:
               return BitConverter.ToUInt16(byteArray, 0);
            case TypeCode.UInt32:
               return BitConverter.ToUInt32(byteArray, 0);
            case TypeCode.UInt64:
               return BitConverter.ToUInt64(byteArray, 0);
         }

         return null;
      }
      public static Byte[] getBytes(this Object obj, Type objectType) {
         switch (Type.GetTypeCode(objectType)) {
            case TypeCode.Boolean:
               return BitConverter.GetBytes((Boolean)obj);
            case TypeCode.Byte:
               return new Byte[1] { (Byte)obj };
            case TypeCode.Char:
               return Encoding.ASCII.GetBytes(new[] { (Char)obj });
            case TypeCode.Double:
               return BitConverter.GetBytes((Double)obj);
            case TypeCode.Single:
               return BitConverter.GetBytes((Single)obj);
            case TypeCode.Int16:
               return BitConverter.GetBytes((Int16)obj);
            case TypeCode.Int32:
               return BitConverter.GetBytes((Int32)obj);
            case TypeCode.Int64:
               return BitConverter.GetBytes((Int64)obj);
            case TypeCode.UInt16:
               return BitConverter.GetBytes((UInt16)obj);
            case TypeCode.UInt32:
               return BitConverter.GetBytes((UInt32)obj);
            case TypeCode.UInt64:
               return BitConverter.GetBytes((UInt64)obj);
            case TypeCode.String:
               return Encoding.ASCII.GetBytes((String)obj);
         }

         return null;
      }
   }
}
