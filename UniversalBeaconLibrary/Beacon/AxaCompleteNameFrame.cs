using UniversalBeaconLibrary.Beacon;

namespace XamarinBeacon.Beacon
{
    public class AxaCompleteNameFrame : BeaconFrameBase
    {
        public string CompleteName { get; set; }

        public AxaCompleteNameFrame(byte[] payload)
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
            CompleteName = System.Text.Encoding.UTF8.GetString(Payload);
        }
    }
}
