﻿/*
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

namespace PlayEngine.Helpers.MemoryClasses.ScanValueTypes {
   public class ValueType8Bytes : IScanValueType {
      private static ValueType8Bytes _mSelf = null;
      public static ValueType8Bytes mSelf
      {
         get {
            if (_mSelf == null)
               _mSelf = new ValueType8Bytes();
            return _mSelf;
         }
      }

      public override Type getType() {
         return typeof(UInt64);
      }
      public override Type getSignedType() {
         return typeof(Int64);
      }
      public override Int32 getSize() {
         return sizeof(UInt64);
      }
      public override String ToString() {
         return "8 Bytes";
      }
   }
}
