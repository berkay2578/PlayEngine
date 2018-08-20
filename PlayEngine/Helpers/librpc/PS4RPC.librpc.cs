/* golden: 12/2/2018      */
/* berkay(2578): 3/8/2018 */

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace librpc {
   public enum RPC_PACKET : Byte {
      RPC_RESULT = 0,
      RPC_PROCESS_GET_LIST,
      RPC_PROCESS_INFO,
      RPC_PROCESS_PROTECTION,
      RPC_PROCESS_READ,
      RPC_PROCESS_WRITE,
      RPC_PROCESS_ALLOC,
      RPC_PROCESS_INSTALL_STUB,
      RPC_PROCESS_CALL,
      RPC_PROCESS_INJECT_ELF,
      RPC_KERNEL_GET_BASE,
      RPC_KERNEL_READ,
      RPC_KERNEL_WRITE,
      RPC_PS4_REBOOT,
      RPC_TERMINATE
   }

   public enum RPC_RESULT : Byte {
      RPC_RESULT_SUCCESS = 0,
      RPC_RESULT_ERROR,
      RPC_RESULT_ERROR_NO_MAP,
      RPC_RESULT_ERROR_NO_PROCESS
   }

   public class PS4RPC {
      private Socket sock;
      private IPEndPoint endPoint;
      private Byte lastPacketId = 0;
      public Boolean isConnected { get; private set; }

      private void throwNotConnectedException() {
         throw new Exception("librpc: RPC not connected!");
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

         endPoint = new IPEndPoint(addr, 2578);
         sock = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp) { NoDelay = true, ReceiveTimeout = 10 * 1000, SendTimeout = 10 * 1000 };
      }

      private List<KeyValuePair<Byte, Byte[]>> savedPackets = new List<KeyValuePair<Byte, Byte[]>>();
      private T receivePacket<T>(Byte packetId) where T : Packets.IPacket {
         Func<RPC_PACKET, Byte[], T> fnDeserializePacket = new Func<RPC_PACKET, Byte[], T>((RPC_PACKET _dataType, Byte[] _bufPacket) =>
         {
            // ugly conversion
            if (_dataType == RPC_PACKET.RPC_PROCESS_GET_LIST)
               return (T)(Object)Packets.ProcessListPacket.deserialize(_bufPacket);
            else if (_dataType == RPC_PACKET.RPC_PROCESS_INFO)
               return (T)(Object)Packets.ProcessInfoResponsePacket.deserialize(_bufPacket);
            else if (_dataType == RPC_PACKET.RPC_PROCESS_READ)
               return (T)(Object)Packets.ProcessReadResponsePacket.deserialize(_bufPacket);
            else
               throw new Exception($"rpc error -- RPC_RESULT: {((RPC_RESULT)_bufPacket[0]).ToString()}");
         });
         foreach (var item in savedPackets) {
            if (item.Key == packetId) {
               RPC_PACKET _dataType;
               if (typeof(T) == typeof(Packets.ProcessListPacket))
                  _dataType = RPC_PACKET.RPC_PROCESS_GET_LIST;
               else if (typeof(T) == typeof(Packets.ProcessInfoResponsePacket))
                  _dataType = RPC_PACKET.RPC_PROCESS_INFO;
               else if (typeof(T) == typeof(Packets.ProcessReadResponsePacket))
                  _dataType = RPC_PACKET.RPC_PROCESS_READ;
               else
                  _dataType = RPC_PACKET.RPC_RESULT;
               return fnDeserializePacket(_dataType, item.Value);
            }
         }

         // get header
         Byte[] bufPacketHeader = new Byte[6];
         sock.Receive(bufPacketHeader, 6, SocketFlags.None);
         var packetHeader = Packets.IPacket.deserializeHeader(bufPacketHeader);
         // get packet
         Byte[] bufPacket = new Byte[packetHeader.dataLength];
         sock.Receive(bufPacket, (Int32)packetHeader.dataLength, SocketFlags.None);

         if (packetHeader.id == packetId)
            return fnDeserializePacket(packetHeader.dataType, bufPacket);
         else
            savedPackets.Add(new KeyValuePair<Byte, Byte[]>(packetHeader.id, bufPacket));

         Thread.Sleep(2000);
         return receivePacket<T>(packetId);
      }
      private void sendPacket(Packets.IPacket packet) {
         sock.Send(packet.serializeHeader());
         if (packet.dataLength > 0)
            sock.Send(packet.serialize());
      }

      /// <summary>
      /// Connects to PlayStation 4
      /// </summary>
      public void connect() {
         if (!isConnected) {
            sock.Connect(endPoint);
            isConnected = true;
         }
      }

      /// <summary>
      /// Disconnects from PlayStation 4
      /// </summary>
      public void disconnect() {
         var packet = new Packets.IPacket()
         {
            id = lastPacketId++,
            dataType = RPC_PACKET.RPC_TERMINATE,
            dataLength = 0
         };
         sendPacket(packet);
         sock.Dispose();
         isConnected = false;
      }

      /// <summary>
      /// Read memory
      /// </summary>
      /// <param name="_processId">Process ID</param>
      /// <param name="_address">Memory address</param>
      /// <param name="_length">Data length</param>
      /// <returns></returns>
      public Byte[] readMemory(UInt32 _processId, UInt64 _address, UInt32 _length) {
         if (!isConnected)
            throwNotConnectedException();

         var packet = new Packets.ProcessReadPacket()
         {
            id = lastPacketId++,
            dataType = RPC_PACKET.RPC_PROCESS_READ,
            dataLength = Packets.ProcessReadPacket.getSize(),
            processId = _processId,
            address = _address,
            length = _length
         };
         sendPacket(packet);
         receivePacket<Packets.ResultPacket>(packet.id);
         return receivePacket<Packets.ProcessReadResponsePacket>(packet.id).data;
      }

      /// <summary>
      /// Write memory
      /// </summary>
      /// <param name="_processId">Process ID</param>
      /// <param name="_address">Memory address</param>
      /// <param name="_data">Data</param>
      /// <returns></returns>
      public void writeMemory(UInt32 _processId, UInt64 _address, Byte[] _data) {
         if (!isConnected)
            throwNotConnectedException();

         var packet = new Packets.ProcessWritePacket()
         {
            id = lastPacketId++,
            dataType = RPC_PACKET.RPC_PROCESS_READ,
            dataLength = Packets.ProcessWritePacket.getSize(),
            processId = _processId,
            address = _address,
            length = (UInt32)_data.Length,
            data = _data
         };
         sendPacket(packet);
         receivePacket<Packets.ResultPacket>(packet.id);
      }

      /// <summary>
      /// Get current process list
      /// </summary>
      /// <returns></returns>
      public List<Process> getProcessList() {
         if (!isConnected)
            throwNotConnectedException();

         var packet = new Packets.IPacket()
         {
            id = lastPacketId++,
            dataType = RPC_PACKET.RPC_PROCESS_GET_LIST,
            dataLength = 0
         };
         sendPacket(packet);
         receivePacket<Packets.ResultPacket>(packet.id);

         List<Process> result = new List<Process>();
         var processes = receivePacket<Packets.ProcessListPacket>(packet.id).listProcesses;
         foreach (var item in processes)
            result.Add(new Process(item.name, item.processId));

         return result;
      }

      /// <summary>
      /// Get process information (memory map)
      /// </summary>
      /// <param name="_processId">Process ID</param>
      /// <returns></returns>
      public ProcessInfo getProcessInfo(UInt32 _processId) {
         if (!isConnected)
            throwNotConnectedException();

         var packet = new Packets.ProcessInfoPacket()
         {
            id = lastPacketId++,
            dataType = RPC_PACKET.RPC_PROCESS_INFO,
            dataLength = Packets.ProcessInfoPacket.getSize(),
            processId = _processId
         };
         sendPacket(packet);
         receivePacket<Packets.ResultPacket>(packet.id);

         var responsePacket = receivePacket<Packets.ProcessInfoResponsePacket>(packet.id);
         return new ProcessInfo(_processId, responsePacket.listMemorySections);
      }

      public String readString(UInt32 pid, UInt64 address) {
         String str = "";
         UInt64 i = 0;

         while (true) {
            Byte value = readMemory(pid, address + i, 1)[0];
            if (value == 0x00)
               break;

            str += Convert.ToChar(value);
            i++;
         }

         return str;
      }
      public void writeString(UInt32 pid, UInt64 address, String str) {
         writeMemory(pid, address, Encoding.ASCII.GetBytes(str));
         writeMemory(pid, address + (UInt64)str.Length, new Byte[] { 0x00 });
      }
   }
}
