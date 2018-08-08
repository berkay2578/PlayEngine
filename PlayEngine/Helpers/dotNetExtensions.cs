/*
   PlayEngine - Cheat Engine for the PS4

   MIT License
   
   Copyright (c) 2018 Berkay Yigit
   
   Permission is hereby granted, free of charge, to any person obtaining a copy
   of this software and associated documentation files (the "Software"), to deal
   in the Software without restriction, including without limitation the rights
   to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
   copies of the Software, and to permit persons to whom the Software is
   furnished to do so, subject to the following conditions:
   
   The above copyright notice and this permission notice shall be included in all
   copies or substantial portions of the Software.
   
   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
   IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
   FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
   AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
   LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
   OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
   SOFTWARE.
*/

using System;
using System.Text;

namespace PlayEngine.Helpers {
   public static class dotNetExtensions {
      public static Boolean ContainsEx(this String source, String toCheck, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase) {
         return source != null && toCheck != null && source.IndexOf(toCheck, comparison) >= 0;
      }

      public static dynamic getObject(this Byte[] byteArray, Type objectType) {
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
