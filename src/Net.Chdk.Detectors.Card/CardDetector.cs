using Net.Chdk.Model.Card;
using System.Linq;
using System.Management;

namespace Net.Chdk.Detectors.Card
{
    public sealed class CardDetector
    {
        private const string CardsQueryString = "SELECT * FROM Win32_Volume WHERE DriveType = 2";

        public CardInfo[] GetCards()
        {
            using (var searcher = new ManagementObjectSearcher(CardsQueryString))
            using (var volumes = searcher.Get())
            {
                return volumes
                    .Cast<ManagementObject>()
                    .Select(GetCard)
                    .ToArray();
            }
        }

        public CardInfo GetCard(string driveLetter)
        {
            using (var searcher = new ManagementObjectSearcher($"{CardsQueryString} AND DriveLetter = '{driveLetter}'"))
            using (var volumes = searcher.Get())
            {
                return volumes
                    .Cast<ManagementObject>()
                    .Select(GetCard)
                    .SingleOrDefault();
            }
        }

        private CardInfo GetCard(ManagementObject volume)
        {
            var deviceId = (string)volume["DeviceID"];
            var driveLetter = (string)volume["DriveLetter"];
            var label = (string)volume["Label"];
            var fileSystem = (string)volume["FileSystem"];
            var capacity = (ulong)volume["Capacity"];
            var freeSpace = (ulong)volume["FreeSpace"];

            return new CardInfo
            {
                DeviceId = deviceId,
                DriveLetter = driveLetter,
                Label = label,
                FileSystem = fileSystem,
                Capacity = capacity,
                FreeSpace = freeSpace,
            };
        }
    }
}
