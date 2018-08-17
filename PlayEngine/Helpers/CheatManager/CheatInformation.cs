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
using System.ComponentModel;

namespace PlayEngine.Helpers.CheatManager {
   public class CheatInformation : INotifyPropertyChanged {
      public event PropertyChangedEventHandler PropertyChanged;
      private void setField<T>(ref T field, T value, String propertyName) {
         if (EqualityComparer<T>.Default.Equals(field, value))
            return;
         field = value;
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }

      public List<UInt32> listPointerOffsets = new List<UInt32>();
      public dynamic frozenValue;
      public UInt32 sectionOffset;

      private Boolean _isFrozen;
      public Boolean isFrozen
      {
         get { return _isFrozen; }
         set { setField(ref _isFrozen, value, "isFrozen"); }
      }

      private String _description;
      public String description
      {
         get { return _description; }
         set { setField(ref _description, value, "description"); }
      }

      private librpc.MemorySection _memorySection;
      public librpc.MemorySection memorySection
      {
         get { return _memorySection; }
         set { setField(ref _memorySection, value, "memorySection"); }
      }

      private UInt64 _address;
      public UInt64 address
      {
         get { return memorySection == null ? _address : memorySection.start + sectionOffset; }
         set { setField(ref _address, value, "address"); }
      }

      private Type _valueType;
      public Type valueType
      {
         get { return _valueType; }
         set { setField(ref _valueType, value, "valueType"); }
      }

      private dynamic _value;
      public dynamic value
      {
         get { return Memory.ActiveProcess.read(address, valueType); }
         set {
            try {
               Memory.ActiveProcess.write(address, value, valueType);
            } catch (OverflowException) {
               switch (Type.GetTypeCode(valueType)) {
                  case TypeCode.SByte:
                     valueType = typeof(Byte);
                     break;
                  case TypeCode.Byte:
                     valueType = typeof(SByte);
                     break;
                  case TypeCode.Int16:
                     valueType = typeof(UInt16);
                     break;
                  case TypeCode.UInt16:
                     valueType = typeof(Int16);
                     break;
                  case TypeCode.Int32:
                     valueType = typeof(UInt32);
                     break;
                  case TypeCode.UInt32:
                     valueType = typeof(Int32);
                     break;
                  case TypeCode.Int64:
                     valueType = typeof(UInt64);
                     break;
                  case TypeCode.UInt64:
                     valueType = typeof(Int64);
                     break;
               }
               Memory.ActiveProcess.write(address, value, valueType);
            }

            frozenValue = value;
            setField(ref _value, value, "value");
         }
      }
   }
}