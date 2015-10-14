using System.Collections.Generic;
using DomainClasses;

namespace ServiceLayer.ServiceContract
{
    public interface IRequestRepository
    {
        void AddNewRequest(Request request);
        void RemoveRequest(int requestId);
        Request FindRequest(string interceptionCode);
        Request FindRequestById(int requestId);
        IList<Request> GetAllRequests();


    }
}