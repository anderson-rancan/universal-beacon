using System;

namespace UniversalBeaconLibrary.Beacon
{
    public enum BeaconType
    {
        /// <summary>
        /// Bluetooth LE advertisment that is not recognized as one of the beacon formats
        /// supported by this library.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Beacon conforming to the Google Eddystone specification.
        /// </summary>
        Eddystone,

        /// <summary>
        /// Beacon conforming to the Apple iBeacon specification.
        /// iBeacon is a Trademark of Apple Inc.
        /// Note: the beacon broadcast payload is not parsed by this library.
        /// </summary>
        iBeacon,

        AXABeacon
    }

    public static partial class Extension
    {
        private static readonly Guid _eddystoneGuid = new Guid("0000FEAA-0000-1000-8000-00805F9B34FB");
        private static readonly Guid _axaBeacon = new Guid("0000FFF6-0000-1000-8000-00805F9B34FB");

        public static Guid ToGuid(this BeaconType self)
        {
            switch (self)
            {                
                case BeaconType.Eddystone: return _eddystoneGuid;
                case BeaconType.AXABeacon: return _axaBeacon;
                case BeaconType.iBeacon:
                case BeaconType.Unknown:
                default: return Guid.Empty;
            }
        }

        public static BeaconType ToBeaconType(this Guid self)
        {
            if (self.Equals(_eddystoneGuid))
                return BeaconType.Eddystone;
            else if (self.Equals(_axaBeacon))
                return BeaconType.AXABeacon;
            else
                return BeaconType.Unknown;
        }
    }
}
