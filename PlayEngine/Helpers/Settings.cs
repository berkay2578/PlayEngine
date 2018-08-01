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
