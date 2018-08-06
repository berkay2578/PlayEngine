/*
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

namespace PlayEngine.Helpers.MemoryClasses.ScanValueTypes {
   public class ValueTypeString : IScanValueType {
      private static ValueTypeString _mSelf = null;
      public static ValueTypeString mSelf
      {
         get {
            if (_mSelf == null)
               _mSelf = new ValueTypeString();
            return _mSelf;
         }
      }

      public override List<ScanCompareTypes.IScanCompareType> supportedFirstScanCompareTypes
      {
         get {
            var retList = new List<ScanCompareTypes.IScanCompareType>()
            {
               ScanCompareTypes.CompareTypeString.mSelf,
            };
            return retList;
         }
      }
      public override List<ScanCompareTypes.IScanCompareType> supportedNextScanCompareTypes
      {
         get {
            var retList = new List<ScanCompareTypes.IScanCompareType>()
            {
               ScanCompareTypes.CompareTypeString.mSelf
            };
            return retList;
         }
      }
      public override Boolean supportsHexCompare { get; set; } = false;

      public override Type getType() {
         return typeof(String);
      }
      public override Type getSignedType() {
         throw new InvalidOperationException("Cannot return signed type of String");
      }
      public override String ToString() {
         return "String";
      }
   }
}
