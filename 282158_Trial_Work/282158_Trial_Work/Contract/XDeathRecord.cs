using XRoadLib.Attributes;
using XRoadLib.Serialization;

namespace _282158_Trial_Work.Contract
{
    public class XDeathRecord : XRoadSerializable
    {
        [XRoadXmlElement("personalIdentificationNumber", IsOptional = false)]
        public string PersonalIdentificationNumber { get; set; }

        [XRoadXmlElement("dateOfDeath", IsOptional = false)]
        public DateTime DateOfDeath { get; set; }
    }
}
