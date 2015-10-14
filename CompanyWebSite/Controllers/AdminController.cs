using System.IO;
using System.Web.Mvc;
using CompanyWebSite.Infrastructure;
using ServiceLayer.ServiceContract;

namespace CompanyWebSite.Controllers
{
    
    public partial class AdminController : Controller
    {
        private readonly IRequestRepository _requestRepository;

        public AdminController(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }
        // GET: Admin
        public virtual ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public virtual ActionResult AllRequests()
        {
            var requests = _requestRepository.GetAllRequests();
            foreach (var request in requests)
            {
                request.UploadPath = Path.GetFileName(Server.PhysicalPathToVirtualConverter(request.UploadPath, Request));
            }
            return View(requests);
        }
      

        [HttpGet]
        public virtual ActionResult DownloadFile(int requestId)
        {
            var request = _requestRepository.FindRequestById(requestId);
            request.UploadPath = Server.PhysicalPathToVirtualConverter(request.UploadPath, Request);
            //var fileContent = System.IO.File.ReadAllBytes(request.UploadPath);
            return File(request.UploadPath,System.Net.Mime.MediaTypeNames.Application.Octet,Path.GetFileName(request.UploadPath));
            
        }
    }
}