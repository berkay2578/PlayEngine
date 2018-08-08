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

namespace PlayEngine.Helpers.MemoryClasses.ScanCompareTypes {
   public class CompareTypeDecreasedValue : IScanCompareType {
      private static CompareTypeDecreasedValue _mSelf = null;
      public static CompareTypeDecreasedValue mSelf
      {
         get {
            if (_mSelf == null)
               _mSelf = new CompareTypeDecreasedValue();
            return _mSelf;
         }
      }

      public override Boolean supportsScanValue
      {
         get {
            return false;
         }
      }
      public override Boolean compare(dynamic value, dynamic memoryValue, dynamic previousMemoryValue, dynamic[] extraParams = null) {
         return memoryValue < previousMemoryValue;
      }

      public override String ToString() {
         return "Decreased value";
      }
   }
}
