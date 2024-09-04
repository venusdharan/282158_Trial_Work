using System.Xml.Serialization;
using XRoadLib.Serialization;

namespace _282158_Trial_Work.Contract
{
    public class DateOfDeathRequest :  XRoadSerializable
    {
        [XmlElement(Order = 1)]
        public DateTime startDate { get; set; }

        [XmlElement(Order = 2)]
        public DateTime endDate { get; set; }
    }
}
