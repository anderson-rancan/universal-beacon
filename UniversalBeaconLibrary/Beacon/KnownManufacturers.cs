using System.Linq;
using System.Reflection;

namespace UniversalBeaconLibrary.Beacon
{
    public struct KnownManufacturer
    {
        public string Name { get; set; }
        public ushort Id { get; set; }

        public KnownManufacturer(ushort id, string companyName)
        {
            Name = companyName;
            Id = id;
        }

        public static KnownManufacturer Microsoft => new KnownManufacturer(6, "Microsoft");

        public static KnownManufacturer Apple => new KnownManufacturer(76, "Apple, Inc.");

        public static KnownManufacturer Samsung => new KnownManufacturer(117, "Samsung Electronics Co. Ltd.");

        public static KnownManufacturer Unknown => new KnownManufacturer(ushort.MaxValue, "Unknown manufacturer");

        public static KnownManufacturer FromManufacturerId(ushort id)
        {
            var company = typeof(KnownManufacturer)
                .GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Where(_ => ((KnownManufacturer)_.GetValue(null)).Id == id)
                .Select(_ => _.GetValue(null));

            return company.Any()
                ? (KnownManufacturer)company.First()
                : Unknown;
        }
    }
}
