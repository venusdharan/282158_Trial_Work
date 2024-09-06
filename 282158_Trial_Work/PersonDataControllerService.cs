using XRoadLib;
using XRoadLib.Headers;
using XRoadLib.Schema;

namespace _282158_Trial_Work
{
    public class PersonDataControllerService : ServiceManager<XRoadHeader>
    {
        public PersonDataControllerService()
        : base("4.0", new DefaultSchemaExporter("http://triophore.x-road.eu/", typeof(PersonDataControllerService).Assembly))
        { }
    }
}
