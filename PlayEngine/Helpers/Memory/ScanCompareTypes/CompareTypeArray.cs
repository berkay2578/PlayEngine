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
using System.Collections.Generic;

namespace PlayEngine.Helpers.MemoryClasses.ScanCompareTypes {
   public class CompareTypeArray : IScanCompareType {
      private static CompareTypeArray _mSelf = null;
      public static CompareTypeArray mSelf
      {
         get {
            if (_mSelf == null)
               _mSelf = new CompareTypeArray();
            return _mSelf;
         }
      }

      public override Boolean compare(dynamic value, dynamic memoryValue, dynamic previousMemoryValue, dynamic[] extraParams = null) {
         List<Tuple<UInt32, Byte[]>> listResults = extraParams[0];
         Byte[] bufValue = value;
         Byte[] bufMemory = memoryValue;
         Int32 indexEnd = bufMemory.Length - bufValue.Length;
         for (Int32 index = 0; index < indexEnd; index += bufValue.Length) {
            Boolean isFound = false;
            for (Int32 j = 0; j < bufValue.Length - 1; j++) {
               isFound = bufMemory[index + j] == bufValue[j];
               if (!isFound)
                  break;
            }
            if (isFound)
               listResults.Add(new Tuple<UInt32, Byte[]>((UInt32)index, bufValue));
         }
         return listResults.Count > 0;
      }

      public override String ToString() {
         return "Search for this array";
      }
   }
}
