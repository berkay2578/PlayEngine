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
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using PlayEngine.Helpers.MemoryClasses.ScanCompareTypes;

namespace PlayEngine.Helpers {
   public class Memory {
      public enum ScanStatus {
         CantScan,
         CanScan,
         DidScan,
         Scanning
      }
      public static ScanStatus currentScanStatus;

      public class ActiveProcess {
         public static librpc.ProcessInfo info = null;

         public static Byte[] readByteArray(UInt64 address, UInt32 size) {
            return Memory.readByteArray(info.id, address, size);
         }
         public static String readString(UInt64 address) {
            return Memory.readString(info.id, address);
         }
         public static dynamic read(UInt64 address, Type valueType) {
            return Memory.read(info.id, address, valueType);
         }

         public static void writeByteArray(UInt64 address, Byte[] bytes) {
            Memory.writeByteArray(info.id, address, bytes);
         }
         public static void writeString(UInt64 address, String str) {
            Memory.writeString(info.id, address, str);
         }
         public static void write(UInt64 address, Object value, Type valueType) {
            Memory.write(info.id, address, value, valueType);
         }

         public static void setActiveProcess(librpc.ProcessInfo processInfo) {
            info = processInfo;
         }
      }

      public class Sections {
         public static List<librpc.MemorySection> getMemorySections(librpc.ProcessInfo processInfo, librpc.VM_PROT protection = librpc.VM_PROT.RO) {
            var listMemoryEntries = new List<librpc.MemorySection>();
            foreach (var memorySection in processInfo.listProcessMemorySections)
               if ((memorySection.protection & protection) == protection)
                  listMemoryEntries.Add(memorySection);

            return listMemoryEntries;
         }
         public static librpc.MemorySection findMemorySectionByName(librpc.ProcessInfo processInfo, String sectionName, librpc.VM_PROT protection = librpc.VM_PROT.RO) {
            librpc.MemorySection result = null;
            foreach (var memorySection in processInfo.listProcessMemorySections) {
               if (memorySection.name == sectionName &&
                   (memorySection.protection & protection) == protection) {
                  result = memorySection;
                  break;
               }
            }

            return result;
         }
      }
      public class CUSAInfo {
         public static String getId() {
            librpc.ProcessInfo processInfo = Memory.getProcessInfoFromName("SceCdlgApp");
            if (processInfo == null)
               return String.Empty;
            librpc.MemorySection memorySection = Sections.findMemorySectionByName(processInfo, "libSceCdlgUtilServer.sprx", librpc.VM_PROT.RW);
            if (memorySection == null)
               return String.Empty;

            return Memory.readString(processInfo.id, memorySection.start + 0xA0);
         }
         public static String getVersionStr() {
            librpc.ProcessInfo processInfo = Memory.getProcessInfoFromName("SceCdlgApp");
            if (processInfo == null)
               return String.Empty;
            librpc.MemorySection memorySection = Sections.findMemorySectionByName(processInfo, "libSceCdlgUtilServer.sprx", librpc.VM_PROT.RW);
            if (memorySection == null)
               return String.Empty;

            return Memory.readString(processInfo.id, memorySection.start + 0xC8);
         }
      }

      public static librpc.PS4RPC ps4RPC = null;
      public static Boolean initPS4RPC(String ipAddress) {
         try {
            if (ps4RPC != null && ps4RPC.isConnected)
               ps4RPC.disconnect();
            ps4RPC = new librpc.PS4RPC(ipAddress);
            ps4RPC.connect();
         } catch { }
         return ps4RPC != null && ps4RPC.isConnected;
      }
      public static librpc.ProcessInfo getProcessInfoFromName(String processName) {
         return Memory.ps4RPC.getProcessInfo(Memory.ps4RPC.getProcessList().Where(proc => proc.name == processName).First().id);
      }
      
      public static Byte[] readByteArray(UInt32 procId, UInt64 address, UInt32 size) {
         Byte[] returnBuf = null;
         try {
            returnBuf = ps4RPC.readMemory(procId, address, size);
         } catch (Exception ex) {
            Console.WriteLine("Error during ReadByteArray:\r\nProcessId: {0}, Address: {1}, Size: {2}\r\n{3}",
                procId, address.ToString("X"), size, ex.ToString());
         }
         return returnBuf;
      }
      public static String readString(UInt32 procId, UInt64 address) {
         String returnStr = String.Empty;
         try {
            returnStr = ps4RPC.readString(procId, address);
         } catch (Exception ex) {
            Console.WriteLine("Error during ReadString:\r\nProcessId: {0}, Address: {1}\r\n{2}",
                procId, address.ToString("X"), ex.ToString());
         }
         return returnStr;
      }
      public static dynamic read(UInt32 procId, UInt64 address, Type valueType) {
         if (valueType == typeof(String))
            return readString(procId, address);
         Byte[] readBuffer = readByteArray(procId, address, (UInt32)(valueType == typeof(Boolean) ? 1 : Marshal.SizeOf(valueType)));
         return readBuffer == null ? -1 : readBuffer.getObject(valueType);
      }

      public static void writeByteArray(UInt32 procId, UInt64 address, Byte[] bytes) {
         try {
            ps4RPC.writeMemory(procId, address, bytes);
         } catch (Exception ex) {
            Console.WriteLine("Error during WriteByteArray:\r\nProcessId: {0}, Address: {1}, bytes.Length: {2}\r\n{3}",
                   procId, address.ToString("X"), bytes.Length, ex.ToString());
         }
      }
      public static void writeString(UInt32 procId, UInt64 address, String str) {
         try {
            ps4RPC.writeString(procId, address, str);
         } catch (Exception ex) {
            Console.WriteLine("Error during WriteString:\r\nProcessId: {0}, Address: {1}, String: {2}\r\n{3}",
                procId, address.ToString("X"), str, ex.ToString());
         }
      }
      public static void write(UInt32 procId, UInt64 address, Object value, Type valueType) {
         if (valueType == typeof(String))
            writeString(procId, address, (String)value);
         else
            writeByteArray(procId, address, value.getBytes(valueType));
      }

      public static List<Tuple<UInt64, dynamic>> scan(UInt64 searchStartAddress, Byte[] searchBuffer, dynamic value, Type valueType, IScanCompareType compareType, dynamic[] extraParams = null) {
         List<Tuple<UInt64, dynamic>> listResults = new List<Tuple<UInt64, dynamic>>();
         if (valueType == typeof(Byte[])) {
            Byte[] valueBuffer = value;
            Int64 lenValueBuffer = valueBuffer.LongLength;
            Int64[] bufBoyerMoore = new Int64[256];
            for (Int32 i = 0; i < 256; i++)
               bufBoyerMoore[i] = lenValueBuffer;
            Int64 indexPatternEnd = lenValueBuffer - 1;
            for (Int64 i = 0; i < indexPatternEnd; i++)
               bufBoyerMoore[value[i]] = indexPatternEnd;

            Int64 index = 0;
            while (index <= searchBuffer.LongLength - lenValueBuffer) {
               for (Int64 i = indexPatternEnd; searchBuffer[index + i] == value[i]; i--) {
                  if (i == 0) {
                     listResults.Add(new Tuple<UInt64, dynamic>(searchStartAddress + (UInt64)index, value));
                     break;
                  }
               }
               index += bufBoyerMoore[searchBuffer[index + indexPatternEnd]];
            }
         } else {
            if (compareType.GetType() == typeof(CompareTypeExactValue)) {
               var patternMatchScanResults = scan(searchStartAddress, searchBuffer, dotNetExtensions.getBytes(value, valueType), typeof(Byte[]), null);
               foreach (Tuple<UInt64, dynamic> tuple in patternMatchScanResults)
                  listResults.Add(new Tuple<UInt64, dynamic>(tuple.Item1, value));
            } else {
               Int32 objectTypeSize = 0;
               Func<Int32 /* searchBufferIndex */, dynamic /* returnValue */> fnGetMemoryValueAt = null;
               switch (Type.GetTypeCode(valueType)) {
                  case TypeCode.SByte: {
                     fnGetMemoryValueAt = (iBuffer) => searchBuffer[iBuffer];
                     objectTypeSize = sizeof(SByte);
                  }
                  break;
                  case TypeCode.Byte: {
                     fnGetMemoryValueAt = (iBuffer) => searchBuffer[iBuffer];
                     objectTypeSize = sizeof(Byte);
                  }
                  break;
                  case TypeCode.Boolean: {
                     fnGetMemoryValueAt = (iBuffer) => BitConverter.ToBoolean(searchBuffer, iBuffer);
                     objectTypeSize = 1;
                  }
                  break;
                  case TypeCode.Int16: {
                     fnGetMemoryValueAt = (iBuffer) => BitConverter.ToInt16(searchBuffer, iBuffer);
                     objectTypeSize = sizeof(Int16);
                  }
                  break;
                  case TypeCode.UInt16: {
                     fnGetMemoryValueAt = (iBuffer) => BitConverter.ToUInt16(searchBuffer, iBuffer);
                     objectTypeSize = sizeof(UInt16);
                  }
                  break;
                  case TypeCode.Int32: {
                     fnGetMemoryValueAt = (iBuffer) => BitConverter.ToUInt32(searchBuffer, iBuffer);
                     objectTypeSize = sizeof(Int32);
                  }
                  break;
                  case TypeCode.UInt32: {
                     fnGetMemoryValueAt = (iBuffer) => BitConverter.ToUInt32(searchBuffer, iBuffer);
                     objectTypeSize = sizeof(UInt32);
                  }
                  break;
                  case TypeCode.Int64: {
                     fnGetMemoryValueAt = (iBuffer) => BitConverter.ToUInt64(searchBuffer, iBuffer);
                     objectTypeSize = sizeof(Int64);
                  }
                  break;
                  case TypeCode.UInt64: {
                     fnGetMemoryValueAt = (iBuffer) => BitConverter.ToUInt64(searchBuffer, iBuffer);
                     objectTypeSize = sizeof(UInt64);
                  }
                  break;
                  case TypeCode.Double: {
                     fnGetMemoryValueAt = (iBuffer) => BitConverter.ToDouble(searchBuffer, iBuffer);
                     objectTypeSize = sizeof(Double);
                  }
                  break;
                  case TypeCode.Single: {
                     fnGetMemoryValueAt = (iBuffer) => BitConverter.ToSingle(searchBuffer, iBuffer);
                     objectTypeSize = sizeof(Single);
                  }
                  break;
                  case TypeCode.String: {
                     var scanResults = scan(searchStartAddress, searchBuffer, ((Object)value).getBytes(typeof(String)), typeof(Byte[]), compareType, extraParams);
                     foreach (Tuple<UInt64, dynamic> tuple in scanResults)
                        listResults.Add(new Tuple<UInt64, dynamic>(tuple.Item1, Encoding.ASCII.GetString(tuple.Item2)));
                     return listResults;
                  }
               }

               Int32 indexEnd = searchBuffer.Length - objectTypeSize;
               if (indexEnd > 0) {
                  for (Int32 index = 0; index < indexEnd; index += objectTypeSize) {
                     dynamic memoryValue = fnGetMemoryValueAt(index);
                     if (compareType.compare(value, memoryValue, null, extraParams))
                        listResults.Add(new Tuple<UInt64, dynamic>(searchStartAddress + (UInt64)index, memoryValue));
                  }
               }
            }
         }
         return listResults;
      }
   }
}
