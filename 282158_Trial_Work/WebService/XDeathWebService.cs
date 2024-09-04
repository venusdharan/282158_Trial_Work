using _282158_Trial_Work.Contract;
using _282158_Trial_Work.Data;
using Microsoft.EntityFrameworkCore;
using XRoadLib.Attributes;

namespace _282158_Trial_Work.WebService
{
  
    public class XDeathWebService : IXDateOfDeath
    {
        private readonly PersonDataContext _dbContext;

        public XDeathWebService(PersonDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [XRoadService("PersonDataChangesService")]
        public IList<XDeathRecord> GetChanges(DateOfDeathRequest request)
        {
            var startDate = request.startDate;
            var endDate = request.endDate;
            if (startDate > endDate)
                throw new ArgumentException("Start date cannot be after end date.");


            // Query the database 
            var deathRecords = _dbContext.Persons
                .Where(p => p.DateOfDeath.HasValue &&
                            p.DateOfDeath.Value >= startDate &&
                            p.DateOfDeath.Value <= endDate)
                .Select(p => new XDeathRecord
                {
                    PersonalIdentificationNumber = p.PersonalCode,
                    DateOfDeath = p.DateOfDeath.Value
                })
                .ToList();

            return deathRecords;
        }
    }
}
