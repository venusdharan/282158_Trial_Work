using XRoadLib.Attributes;

namespace _282158_Trial_Work.Contract
{
    public interface IXDateOfDeath
    {
        //[XRoadService("PersonDataChangesService")]
        [XRoadTitle("en", "Date of death between start and stop")]
        [XRoadNotes("en", "The service should be able to accept specified time periods and return information about individuals whose death records were created within that timeframe.")]
        IList<XDeathRecord> GetChanges(DateOfDeathRequest request);
    }
}
