using System;
using UniversalBeaconLibrary.Beacon;

namespace XamarinBeacon.Beacon
{
    public class AxaBatTempHumFrame : BeaconFrameBase
    {
        public byte Battery { get; set; }

        public byte Humidity { get; set; }

        public sbyte Temperature { get; set; }

        public AxaBatTempHumFrame(byte[] payload) 
            : base(payload)
        {
            ParsePayload();
        }

        public override void Update(BeaconFrameBase otherFrame)
        {
            base.Update(otherFrame);
            ParsePayload();
        }

        private void ParsePayload()
        {
            if (Payload.Length > 1)
            {
                Battery = Payload[2];
            }

            if (Payload.Length > 2)
            {
                Temperature = Convert.ToSByte(BitConverter.ToString(Payload, 3, 1), 16);
            }

            if (Payload.Length > 3)
            {
                Humidity = Payload[4];
            }
        }
    }
}
