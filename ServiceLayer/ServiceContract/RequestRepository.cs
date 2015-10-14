using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DomainClasses;

namespace ServiceLayer.ServiceContract
{
    public class RequestRepository : IRequestRepository
    {
        private readonly IApplicatioDbContext _applicatioDbContext;
        private readonly IDbSet<Request> _requests; 
        public RequestRepository(IApplicatioDbContext dbContext)
        {
            _applicatioDbContext = dbContext;
            _requests = _applicatioDbContext.Set<Request>();
        }
        public void AddNewRequest(Request request)
        {
            _requests.Add(request);
            _applicatioDbContext.SaveChanges();
        }

        public void RemoveRequest(int requestId)
        {
            var request = _requests.FirstOrDefault(r => r.RequestId == requestId);
            _requests.Remove(request);
            _applicatioDbContext.SaveChanges();
        }

        public void EditRequest(int requestId,Request requestParam)
        {
            var request = FindRequestById(requestId);
            if (request!=null)
            {
                request = requestParam;
                _applicatioDbContext.SaveChanges();
            }
        }

        public Request FindRequest(string interceptionCode)
        {
            return _requests.FirstOrDefault(i => i.InterceptionCode == interceptionCode);
            
        }

        public Request FindRequestById(int requestId)
        {
            return _requests.FirstOrDefault(r => r.RequestId == requestId);
        }

        public IList<Request> GetAllRequests()
        {
            return _requests.ToList();
        } 
    }
}