/* golden: 12/2/2018      */
/* berkay(2578): 3/8/2018 */

using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

namespace librpc {
   public class PS4RPC {
      private Socket sock;
      private IPEndPoint enp;
      public Boolean IsConnected
      {
         get;
         private set;
      }

      public const Int32 RPC_PORT = 733;
      private const UInt32 RPC_PACKET_MAGIC = 0xBDAABBCC;
      private const Int32 RPC_MAX_DATA_LEN = 8192;

      /** commands **/
      private enum RPC_CMDS : UInt32 {
         RPC_PROC_READ = 0xBD000001,
         RPC_PROC_WRITE = 0xBD000002,
         RPC_PROC_LIST = 0xBD000003,
         RPC_PROC_INFO = 0xBD000004,
         RPC_PROC_INTALL = 0xBD000005,
         RPC_PROC_CALL = 0xBD000006,
         RPC_PROC_ELF = 0xBD000007,
         RPC_END = 0xBD000008,
         RPC_REBOOT = 0xBD000009,
         RPC_KERN_BASE = 0xBD00000A,
         RPC_KERN_READ = 0xBD00000B,
         RPC_KERN_WRITE = 0xBD00000C
      };

      /** packet sizes **/
      private const Int32 RPC_PACKET_SIZE = 12;
      private const Int32 RPC_PROC_READ_SIZE = 16;
      private const Int32 RPC_PROC_WRITE_SIZE = 16;
      private const Int32 RPC_PROC_LIST_SIZE = 36;
      private const Int32 RPC_PROC_INFO1_SIZE = 4;
      private const Int32 RPC_PROC_INFO2_SIZE = 60;
      private const Int32 RPC_PROC_INSTALL1_SIZE = 4;
      private const Int32 RPC_PROC_INSTALL2_SIZE = 12;
      private const Int32 RPC_PROC_CALL1_SIZE = 68;
      private const Int32 RPC_PROC_CALL2_SIZE = 12;
      private const Int32 RPC_PROC_ELF_SIZE = 8;
      private const Int32 RPC_KERN_BASE_SIZE = 8;
      private const Int32 RPC_KERN_READ_SIZE = 12;
      private const Int32 RPC_KERN_WRITE_SIZE = 12;

      /** status **/
      private enum RPC_STATUS : UInt32 {
         RPC_SUCCESS = 0x80000000,
         RPC_TOO_MUCH_DATA = 0xF0000001,
         RPC_READ_ERROR = 0xF0000002,
         RPC_WRITE_ERROR = 0xF0000003,
         RPC_LIST_ERROR = 0xF0000004,
         RPC_INFO_ERROR = 0xF0000005,
         RPC_INFO_NO_MAP = 0x80000006,
         RPC_NO_PROC = 0xF0000007,
         RPC_INSTALL_ERROR = 0xF0000008,
         RPC_CALL_ERROR = 0xF0000009,
         RPC_ELF_ERROR = 0xF000000A,
      };

      /** messages **/
      private static Dictionary<RPC_STATUS, String> StatusMessages = new Dictionary<RPC_STATUS, String>()
        {
            { RPC_STATUS.RPC_SUCCESS, "success"},
            { RPC_STATUS.RPC_TOO_MUCH_DATA, "too much data"},
            { RPC_STATUS.RPC_READ_ERROR, "read error"},
            { RPC_STATUS.RPC_WRITE_ERROR, "write error"},
            { RPC_STATUS.RPC_LIST_ERROR, "process list error"},
            { RPC_STATUS.RPC_INFO_ERROR, "process information error"},
            { RPC_STATUS.RPC_NO_PROC, "no such process error"},
            { RPC_STATUS.RPC_INSTALL_ERROR, "could not install rpc" },
            { RPC_STATUS.RPC_CALL_ERROR, "could not call address" },
            { RPC_STATUS.RPC_ELF_ERROR, "could not map elf" }
        };
      private const String NotConnectedErrorMessage = "librpc: not connected";
      private const String TooManyArgumentsErrorMessage = "librpc: too many call arguments";

      /// <summary>
      /// Initializes PS4RPC class
      /// </summary>
      /// <param name="addr">PlayStation 4 address</param>
      public PS4RPC(IPAddress addr) {
         enp = new IPEndPoint(addr, RPC_PORT);
         sock = new Socket(enp.AddressFamily, SocketType.Stream, ProtocolType.Tcp) { NoDelay = true, ReceiveTimeout = 5 * 1000, SendTimeout = 5 * 1000 };
      }

      /// <summary>
      /// Initializes PS4RPC class
      /// </summary>
      /// <param name="ip">PlayStation 4 ip address</param>
      public PS4RPC(String ip) {
         IPAddress addr;
         try {
            addr = IPAddress.Parse(ip);
         } catch (FormatException ex) {
            throw ex;
         }

         enp = new IPEndPoint(addr, RPC_PORT);
         sock = new Socket(enp.AddressFamily, SocketType.Stream, ProtocolType.Tcp) { NoDelay = true, ReceiveTimeout = 5 * 1000, SendTimeout = 5 * 1000 };
      }

      private static String GetNullTermString(Byte[] data, Int32 offset) {
         Int32 length = Array.IndexOf<Byte>(data, 0, offset) - offset;
         if (length < 0) {
            length = data.Length - offset;
         }

         return Encoding.ASCII.GetString(data, offset, length);
      }

      private static Byte[] SubArray(Byte[] data, Int32 offset, Int32 length) {
         Byte[] bytes = new Byte[length];
         Buffer.BlockCopy(data, offset, bytes, 0, length);
         return bytes;
      }

      private static Boolean IsFatalStatus(RPC_STATUS status) {
         // if status first nibble starts with F
         return (UInt32)status >> 28 == 15;
      }

      /// <summary>
      /// Connects to PlayStation 4
      /// </summary>
      public void Connect() {
         if (!IsConnected) {
            sock.Connect(enp);
            IsConnected = true;
         }
      }

      /// <summary>
      /// Disconnects from PlayStation 4
      /// </summary>
      public void Disconnect() {
         SendCMDPacket(RPC_CMDS.RPC_END, 0);
         sock.Dispose();
         IsConnected = false;
      }

      private void SendPacketData(Int32 length, params Object[] fields) {
         MemoryStream rs = new MemoryStream();
         foreach (Object field in fields) {
            Byte[] bytes = null;

            switch (field) {
               case Char _:
                  bytes = BitConverter.GetBytes((Char)field);
                  break;

               case Byte _:
                  bytes = BitConverter.GetBytes((Byte)field);
                  break;

               case Int16 _:
                  bytes = BitConverter.GetBytes((Int16)field);
                  break;

               case UInt16 _:
                  bytes = BitConverter.GetBytes((UInt16)field);
                  break;

               case Int32 _:
                  bytes = BitConverter.GetBytes((Int32)field);
                  break;

               case UInt32 _:
                  bytes = BitConverter.GetBytes((UInt32)field);
                  break;

               case Int64 _:
                  bytes = BitConverter.GetBytes((Int64)field);
                  break;

               case UInt64 _:
                  bytes = BitConverter.GetBytes((UInt64)field);
                  break;

               case Byte[] _:
                  bytes = (Byte[])field;
                  break;
            }

            if (bytes != null) rs.Write(bytes, 0, bytes.Length);
         }

         SendData(rs.ToArray(), length);
         rs.Dispose();
      }

      private void SendCMDPacket(RPC_CMDS cmd, Int32 length) {
         SendPacketData(RPC_PACKET_SIZE, RPC_PACKET_MAGIC, (UInt32)cmd, length);
      }

      private RPC_STATUS ReceiveRPCStatus() {
         Byte[] status = new Byte[4];
         sock.Receive(status, 4, SocketFlags.None);
         return (RPC_STATUS)BitConverter.ToUInt32(status, 0);
      }

      private RPC_STATUS CheckRPCStatus() {
         RPC_STATUS status = ReceiveRPCStatus();
         if (IsFatalStatus(status)) {
            StatusMessages.TryGetValue(status, out String value);
            throw new Exception($"librpc: {value}");
         }

         return status;
      }

      private void SendData(Byte[] data, Int32 length) {
         Int32 left = length;
         Int32 offset = 0;
         Int32 sent;
         while (left > 0) {
            if (left > RPC_MAX_DATA_LEN) {
               Byte[] bytes = SubArray(data, offset, RPC_MAX_DATA_LEN);
               sent = sock.Send(bytes, RPC_MAX_DATA_LEN, SocketFlags.None);
               offset += sent;
               left -= sent;
            } else {
               Byte[] bytes = SubArray(data, offset, left);
               sent = sock.Send(bytes, left, SocketFlags.None);
               offset += sent;
               left -= sent;
            }
         }
      }

      private Byte[] ReceiveData(Int32 length) {
         MemoryStream s = new MemoryStream();

         Int32 left = length;
         while (left > 0) {
            Byte[] b = new Byte[RPC_MAX_DATA_LEN];
            Int32 recv = sock.Receive(b, RPC_MAX_DATA_LEN, SocketFlags.None);
            s.Write(b, 0, recv);
            left -= recv;
         }

         Byte[] data = s.ToArray();

         s.Dispose();

         return data;
      }

      /// <summary>
      /// Read memory
      /// </summary>
      /// <param name="pid">Process ID</param>
      /// <param name="address">Memory address</param>
      /// <param name="length">Data length</param>
      /// <returns></returns>
      public Byte[] ReadMemory(Int32 pid, UInt64 address, Int32 length) {
         if (!IsConnected) {
            throw new Exception(NotConnectedErrorMessage);
         }

         SendCMDPacket(RPC_CMDS.RPC_PROC_READ, RPC_PROC_READ_SIZE);
         SendPacketData(RPC_PROC_READ_SIZE, pid, address, length);
         CheckRPCStatus();
         return ReceiveData(length);
      }

      /// <summary>
      /// Write memory
      /// </summary>
      /// <param name="pid">Process ID</param>
      /// <param name="address">Memory address</param>
      /// <param name="data">Data</param>
      public void WriteMemory(Int32 pid, UInt64 address, Byte[] data) {
         if (!IsConnected) {
            throw new Exception(NotConnectedErrorMessage);
         }

         if (data.Length > RPC_MAX_DATA_LEN) {
            // write RPC_MAX_DATA_LEN
            Byte[] nowdata = SubArray(data, 0, RPC_MAX_DATA_LEN);

            SendCMDPacket(RPC_CMDS.RPC_PROC_WRITE, RPC_PROC_WRITE_SIZE);
            SendPacketData(RPC_PROC_WRITE_SIZE, pid, address, RPC_MAX_DATA_LEN);
            CheckRPCStatus();
            SendData(nowdata, RPC_MAX_DATA_LEN);
            CheckRPCStatus();

            // call WriteMemory again with rest of it
            Int32 nextlength = data.Length - RPC_MAX_DATA_LEN;
            UInt64 nextaddr = address + RPC_MAX_DATA_LEN;
            Byte[] nextdata = SubArray(data, RPC_MAX_DATA_LEN, nextlength);
            WriteMemory(pid, nextaddr, nextdata);
         } else if (data.Length > 0) {
            SendCMDPacket(RPC_CMDS.RPC_PROC_WRITE, RPC_PROC_WRITE_SIZE);
            SendPacketData(RPC_PROC_WRITE_SIZE, pid, address, data.Length);
            CheckRPCStatus();
            SendData(data, data.Length);
            CheckRPCStatus();
         }
      }

      /// <summary>
      /// Get kernel base address
      /// </summary>
      /// <returns></returns>
      public UInt64 KernelBase() {
         if (!IsConnected) {
            throw new Exception(NotConnectedErrorMessage);
         }

         SendCMDPacket(RPC_CMDS.RPC_KERN_BASE, 0);
         CheckRPCStatus();
         return BitConverter.ToUInt64(ReceiveData(RPC_KERN_BASE_SIZE), 0);

      }

      /// <summary>
      /// Read memory from kernel
      /// </summary>
      /// <param name="address">Memory address</param>
      /// <param name="length">Data length</param>
      /// <returns></returns>
      public Byte[] KernelReadMemory(UInt64 address, Int32 length) {
         if (!IsConnected) {
            throw new Exception(NotConnectedErrorMessage);
         }

         SendCMDPacket(RPC_CMDS.RPC_KERN_READ, RPC_KERN_READ_SIZE);
         SendPacketData(RPC_KERN_READ_SIZE, address, length);
         CheckRPCStatus();
         return ReceiveData(length);
      }

      /// <summary>
      /// Write memory in kernel
      /// </summary>
      /// <param name="address">Memory address</param>
      /// <param name="data">Data</param>
      public void KernelWriteMemory(UInt64 address, Byte[] data) {
         if (!IsConnected) {
            throw new Exception(NotConnectedErrorMessage);
         }

         if (data.Length > RPC_MAX_DATA_LEN) {
            // write RPC_MAX_DATA_LEN
            Byte[] nowdata = SubArray(data, 0, RPC_MAX_DATA_LEN);

            SendCMDPacket(RPC_CMDS.RPC_KERN_WRITE, RPC_KERN_WRITE_SIZE);
            SendPacketData(RPC_KERN_WRITE_SIZE, address, RPC_MAX_DATA_LEN);
            CheckRPCStatus();
            SendData(nowdata, RPC_MAX_DATA_LEN);
            CheckRPCStatus();

            // call WriteMemory again with rest of it
            Int32 nextlength = data.Length - RPC_MAX_DATA_LEN;
            UInt64 nextaddr = address + RPC_MAX_DATA_LEN;
            Byte[] nextdata = SubArray(data, RPC_MAX_DATA_LEN, nextlength);
            KernelWriteMemory(nextaddr, nextdata);
         } else if (data.Length > 0) {
            SendCMDPacket(RPC_CMDS.RPC_KERN_WRITE, RPC_KERN_WRITE_SIZE);
            SendPacketData(RPC_KERN_WRITE_SIZE, address, data.Length);
            CheckRPCStatus();
            SendData(data, data.Length);
            CheckRPCStatus();
         }
      }

      /// <summary>
      /// Get current process list
      /// </summary>
      /// <returns></returns>
      public List<Process> GetProcessList() {
         if (!IsConnected) {
            throw new Exception(NotConnectedErrorMessage);
         }

         SendCMDPacket(RPC_CMDS.RPC_PROC_LIST, 0);
         CheckRPCStatus();

         // recv count
         Byte[] bnumber = new Byte[4];
         sock.Receive(bnumber, 4, SocketFlags.None);
         Int32 number = BitConverter.ToInt32(bnumber, 0);

         // recv data
         Byte[] data = ReceiveData(number * RPC_PROC_LIST_SIZE);

         // parse data
         List<Process> listProcesses = new List<Process>();
         String[] procnames = new String[number];
         Int32[] pids = new Int32[number];
         for (Int32 i = 0; i < number; i++) {
            Int32 offset = i * RPC_PROC_LIST_SIZE;
            listProcesses.Add(new Process(GetNullTermString(data, offset), BitConverter.ToInt32(data, offset + 32)));
         }

         return listProcesses;
      }

      /// <summary>
      /// Get process information (memory map)
      /// </summary>
      /// <param name="pid">Process ID</param>
      /// <returns></returns>
      public ProcessInfo GetProcessInfo(Int32 pid) {
         if (!IsConnected) {
            throw new Exception(NotConnectedErrorMessage);
         }

         SendCMDPacket(RPC_CMDS.RPC_PROC_INFO, RPC_PROC_INFO1_SIZE);
         SendPacketData(RPC_PROC_INFO1_SIZE, pid);

         RPC_STATUS status = CheckRPCStatus();
         if (status == RPC_STATUS.RPC_INFO_NO_MAP) {
            return new ProcessInfo(pid, null);
         }

         // recv count
         Byte[] bnumber = new Byte[4];
         sock.Receive(bnumber, 4, SocketFlags.None);
         Int32 number = BitConverter.ToInt32(bnumber, 0);

         // recv data
         Byte[] data = ReceiveData(number * RPC_PROC_INFO2_SIZE);

         // parse data
         MemorySection[] entries = new MemorySection[number];
         for (Int32 i = 0; i < number; i++) {
            Int32 offset = i * RPC_PROC_INFO2_SIZE;
            String name = GetNullTermString(data, offset);
            entries[i] = new MemorySection
            {
               name = string.IsNullOrWhiteSpace(name) ? "-noname-" : name,
               start = BitConverter.ToUInt64(data, offset + 32),
               end = BitConverter.ToUInt64(data, offset + 40),
               offset = BitConverter.ToUInt64(data, offset + 48),
               protection = (VM_PROT)BitConverter.ToUInt32(data, offset + 56)
            };
         }

         return new ProcessInfo(pid, entries);
      }

      /// <summary>
      /// Install RPC into a process, this returns a stub address that you should pass into call functions
      /// </summary>
      /// <param name="pid">Process ID</param>
      /// <returns></returns>
      public UInt64 InstallRPC(Int32 pid) {
         if (!IsConnected) {
            throw new Exception(NotConnectedErrorMessage);
         }

         SendCMDPacket(RPC_CMDS.RPC_PROC_INTALL, RPC_PROC_INSTALL1_SIZE);
         SendPacketData(RPC_PROC_INSTALL1_SIZE, pid);
         CheckRPCStatus();
         Byte[] data = ReceiveData(RPC_PROC_INSTALL2_SIZE);
         return BitConverter.ToUInt64(data, 4);
      }

      /// <summary>
      /// Call function (returns rax)
      /// </summary>
      /// <param name="pid">Process ID</param>
      /// <param name="rpcstub">Stub address from InstallRPC</param>
      /// <param name="address">Address to call</param>
      /// <param name="args">Arguments array</param>
      /// <returns></returns>
      public UInt64 Call(Int32 pid, UInt64 rpcstub, UInt64 address, params Object[] args) {
         if (!IsConnected) {
            throw new Exception(NotConnectedErrorMessage);
         }

         SendCMDPacket(RPC_CMDS.RPC_PROC_CALL, RPC_PROC_CALL1_SIZE);

         MemoryStream rs = new MemoryStream();
         rs.Write(BitConverter.GetBytes(pid), 0, sizeof(Int32));
         rs.Write(BitConverter.GetBytes(rpcstub), 0, sizeof(UInt64));
         rs.Write(BitConverter.GetBytes(address), 0, sizeof(UInt64));

         Int32 num = 0;
         foreach (Object arg in args) {
            Byte[] bytes = new Byte[8];

            switch (arg) {
               case Char _: {
                  Byte[] tmp = BitConverter.GetBytes((Char) arg);
                  Buffer.BlockCopy(tmp, 0, bytes, 0, sizeof(Char));

                  Byte[] pad = new Byte[sizeof(UInt64) - sizeof(Char)];
                  Buffer.BlockCopy(pad, 0, bytes, sizeof(Char), pad.Length);
                  break;
               }
               case Byte _: {
                  Byte[] tmp = BitConverter.GetBytes((Byte) arg);
                  Buffer.BlockCopy(tmp, 0, bytes, 0, sizeof(Byte));

                  Byte[] pad = new Byte[sizeof(UInt64) - sizeof(Byte)];
                  Buffer.BlockCopy(pad, 0, bytes, sizeof(Byte), pad.Length);
                  break;
               }
               case Int16 _: {
                  Byte[] tmp = BitConverter.GetBytes((Int16) arg);
                  Buffer.BlockCopy(tmp, 0, bytes, 0, sizeof(Int16));

                  Byte[] pad = new Byte[sizeof(UInt64) - sizeof(Int16)];
                  Buffer.BlockCopy(pad, 0, bytes, sizeof(Int16), pad.Length);
                  break;
               }
               case UInt16 _: {
                  Byte[] tmp = BitConverter.GetBytes((UInt16) arg);
                  Buffer.BlockCopy(tmp, 0, bytes, 0, sizeof(UInt16));

                  Byte[] pad = new Byte[sizeof(UInt64) - sizeof(UInt16)];
                  Buffer.BlockCopy(pad, 0, bytes, sizeof(UInt16), pad.Length);
                  break;
               }
               case Int32 _: {
                  Byte[] tmp = BitConverter.GetBytes((Int32) arg);
                  Buffer.BlockCopy(tmp, 0, bytes, 0, sizeof(Int32));

                  Byte[] pad = new Byte[sizeof(UInt64) - sizeof(Int32)];
                  Buffer.BlockCopy(pad, 0, bytes, sizeof(Int32), pad.Length);
                  break;
               }
               case UInt32 _: {
                  Byte[] tmp = BitConverter.GetBytes((UInt32) arg);
                  Buffer.BlockCopy(tmp, 0, bytes, 0, sizeof(UInt32));

                  Byte[] pad = new Byte[sizeof(UInt64) - sizeof(UInt32)];
                  Buffer.BlockCopy(pad, 0, bytes, sizeof(UInt32), pad.Length);
                  break;
               }
               case Int64 _: {
                  Byte[] tmp = BitConverter.GetBytes((Int64) arg);
                  Buffer.BlockCopy(tmp, 0, bytes, 0, sizeof(Int64));
                  break;
               }
               case UInt64 _: {
                  Byte[] tmp = BitConverter.GetBytes((UInt64) arg);
                  Buffer.BlockCopy(tmp, 0, bytes, 0, sizeof(UInt64));
                  break;
               }
            }

            rs.Write(bytes, 0, bytes.Length);
            num++;
         }

         if (num > 6) {
            throw new Exception(TooManyArgumentsErrorMessage);
         }
         if (num < 6) {
            for (Int32 i = 0; i < (6 - num); i++) {
               rs.Write(BitConverter.GetBytes((UInt64)0), 0, sizeof(UInt64));
            }
         }

         SendData(rs.ToArray(), RPC_PROC_CALL1_SIZE);
         rs.Dispose();

         CheckRPCStatus();

         Byte[] data = ReceiveData(RPC_PROC_CALL2_SIZE);
         return BitConverter.ToUInt64(data, 4);
      }

      /// <summary>
      /// Load an elf into a process
      /// </summary>
      /// <param name="pid">Process ID</param>
      /// <param name="elf">Elf bytes</param>
      public void LoadElf(Int32 pid, Byte[] elf) {
         SendCMDPacket(RPC_CMDS.RPC_PROC_ELF, RPC_PROC_ELF_SIZE);
         SendPacketData(RPC_PROC_ELF_SIZE, pid, elf.Length);
         SendData(elf, elf.Length);
         CheckRPCStatus();
      }

      /// <summary>
      /// Load an elf into a process
      /// </summary>
      /// <param name="pid">Process ID</param>
      /// <param name="filename">Elf file path</param>
      public void LoadElf(Int32 pid, String filename) {
         LoadElf(pid, File.ReadAllBytes(filename));
      }

      /// <summary>
      /// Reboot console
      /// </summary>
      public void Reboot() {
         if (!IsConnected) {
            throw new Exception(NotConnectedErrorMessage);
         }

         SendCMDPacket(RPC_CMDS.RPC_REBOOT, 0);
         sock.Dispose();
         IsConnected = false;
      }

      /** read wrappers **/
      public Byte ReadByte(Int32 pid, UInt64 address) {
         return ReadMemory(pid, address, sizeof(Byte))[0];
      }
      public Char ReadChar(Int32 pid, UInt64 address) {
         return BitConverter.ToChar(ReadMemory(pid, address, sizeof(Char)), 0);
      }
      public Int16 ReadInt16(Int32 pid, UInt64 address) {
         return BitConverter.ToInt16(ReadMemory(pid, address, sizeof(Int16)), 0);
      }
      public UInt16 ReadUInt16(Int32 pid, UInt64 address) {
         return BitConverter.ToUInt16(ReadMemory(pid, address, sizeof(UInt16)), 0);
      }
      public Int32 ReadInt32(Int32 pid, UInt64 address) {
         return BitConverter.ToInt32(ReadMemory(pid, address, sizeof(Int32)), 0);
      }
      public UInt32 ReadUInt32(Int32 pid, UInt64 address) {
         return BitConverter.ToUInt32(ReadMemory(pid, address, sizeof(UInt32)), 0);
      }
      public Int64 ReadInt64(Int32 pid, UInt64 address) {
         return BitConverter.ToInt64(ReadMemory(pid, address, sizeof(Int64)), 0);
      }
      public UInt64 ReadUInt64(Int32 pid, UInt64 address) {
         return BitConverter.ToUInt64(ReadMemory(pid, address, sizeof(UInt64)), 0);
      }

      /** write wrappers **/
      public void WriteByte(Int32 pid, UInt64 address, Byte value) {
         WriteMemory(pid, address, new Byte[] { value });
      }
      public void WriteChar(Int32 pid, UInt64 address, Char value) {
         WriteMemory(pid, address, BitConverter.GetBytes(value));
      }
      public void WriteInt16(Int32 pid, UInt64 address, Int16 value) {
         WriteMemory(pid, address, BitConverter.GetBytes(value));
      }
      public void WriteUInt16(Int32 pid, UInt64 address, UInt16 value) {
         WriteMemory(pid, address, BitConverter.GetBytes(value));
      }
      public void WriteInt32(Int32 pid, UInt64 address, Int32 value) {
         WriteMemory(pid, address, BitConverter.GetBytes(value));
      }
      public void WriteUInt32(Int32 pid, UInt64 address, UInt32 value) {
         WriteMemory(pid, address, BitConverter.GetBytes(value));
      }
      public void WriteInt64(Int32 pid, UInt64 address, Int64 value) {
         WriteMemory(pid, address, BitConverter.GetBytes(value));
      }
      public void WriteUInt64(Int32 pid, UInt64 address, UInt64 value) {
         WriteMemory(pid, address, BitConverter.GetBytes(value));
      }

      /* float/double */
      public Single ReadSingle(Int32 pid, UInt64 address) {
         return BitConverter.ToSingle(ReadMemory(pid, address, sizeof(Single)), 0);
      }
      public void WriteSingle(Int32 pid, UInt64 address, Single value) {
         WriteMemory(pid, address, BitConverter.GetBytes(value));
      }
      public Double ReadDouble(Int32 pid, UInt64 address) {
         return BitConverter.ToDouble(ReadMemory(pid, address, sizeof(Double)), 0);
      }
      public void WriteDouble(Int32 pid, UInt64 address, Double value) {
         WriteMemory(pid, address, BitConverter.GetBytes(value));
      }

      /* string */
      public String ReadString(Int32 pid, UInt64 address) {
         String str = "";
         UInt64 i = 0;

         while (true) {
            Byte value = ReadByte(pid, address + i);
            if (value == 0) {
               break;
            }

            str += Convert.ToChar(value);
            i++;
         }

         return str;
      }
      public void WriteString(Int32 pid, UInt64 address, String str) {
         WriteMemory(pid, address, Encoding.ASCII.GetBytes(str));
         WriteByte(pid, address + (UInt64)str.Length, 0);
      }
   }
}
