using System;
using System.Collections.Generic;
using XRoadLib.Attributes;

namespace _282158_Trial_Work.XRoad
{
    [XRoadService("PersonDataChangesService")]
    public interface IPersonDataChangesService
    {
        [XRoadOperation("GetChanges")]
        IList<PersonDataChange> GetChanges(DateTime startDate, DateTime endDate);
    }

    public class PersonDataChange
    {
        [XRoadXmlElement("personalIdentificationNumber")]
        public string PersonalIdentificationNumber { get; set; }

        [XRoadXmlElement("changes")]
        public List<string> Changes { get; set; }
    }
}
