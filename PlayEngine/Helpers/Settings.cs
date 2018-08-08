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
using System.IO;
using System.Xml.Serialization;

namespace PlayEngine.Helpers {
   [Serializable]
   [XmlRoot("PS4")]
   public class PS4Settings {
      [XmlElement]
      public String IPAddress = "0.0.0.0";
      [XmlElement]
      public Int32 IPPort = 9020;
      [XmlElement]
      public String LastUsedPayload = "Firmware_v5.05";
   }
   [Serializable]
   [XmlRoot("Settings")]
   [XmlInclude(typeof(PS4Settings))]
   public class Settings {
      [XmlIgnore]
      public static Settings mInstance = null;
      [XmlIgnore]
      public static XmlSerializer serializer = null;

      [XmlElement("PS4")]
      public PS4Settings ps4 = new PS4Settings();
      [XmlElement("FastScan")]
      public Boolean fastScanEnabled = true;

      public static Settings loadSettings(String settingsFilePath = "Settings.xml") {
         if (serializer == null)
            serializer = new XmlSerializer(typeof(Settings));

         Settings settings = null;
         if (!System.IO.File.Exists(settingsFilePath)) {
            settings = new Settings();
            settings.saveToFile();
            return settings;
         }

         using (StreamReader reader = new StreamReader(settingsFilePath))
            settings = (Settings)serializer.Deserialize(reader);
         return settings;
      }
      public Boolean saveToFile(String settingsFilePath = "Settings.xml") {
         if (serializer == null)
            serializer = new XmlSerializer(typeof(Settings));

         try {
            using (StreamWriter writer = new StreamWriter(settingsFilePath))
               serializer.Serialize(writer, this);
            return true;
         } catch (Exception) {
            return false;
         }
      }
   }
}
