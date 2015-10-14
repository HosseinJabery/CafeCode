using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using DomainClasses;
using ServiceLayer.ServiceContract;
using System.Collections;
using System.Collections.Generic;
using DataLayer;
using System.Data.Entity;
using System.Linq;
using ViewModels;

namespace CompanyWebSite.Controllers
{

    public partial class HomeController : Controller
    {
        private readonly IRequestRepository _requestRepository;
        public HomeController(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;

            AddMenu();
        }
        // GET: Home
        public virtual ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public virtual ActionResult NewRequest()
        {
            var subjectList = new SelectList(new[] { "", "پروژه برنامه نویسی", "ترجمه", "طراحی وب سایت", "تحقیق" });
            var daysOfMonth=new SelectList(new[] {"1","2","3","4"});
            var daysOfWeek=new SelectList(new[] {"روز","هفته","ماه"});
            ViewBag.daysOfMonth = daysOfMonth;
            ViewBag.daysOfWeek = daysOfWeek;
            ViewBag.SubjectList = subjectList;
            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult NewRequest(NewRequestViewModel request, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
               
                request.UploadPath = UploadFile(file);
                request.InterceptionCode = GenerateInterceptionCode();
                var requestObject = new Request
                {
                    Name = request.Name,
                    Description = request.Description,
                    Email = request.Email,
                    InterceptionCode = request.InterceptionCode,
                    PhoneNumber = request.PhoneNumber,
                    RequestId = request.RequestId,
                    Subject = request.Subject,
                    UploadPath = request.UploadPath,
                    DeliveryDays = request.DeliveryDays + request.DaysOrWeeks

                };
                _requestRepository.AddNewRequest(requestObject);
                return View(MVC.Home.Views.success, requestObject);
            }
            else
            {
                ModelState.AddModelError("", "ورودی ها نامعتبر هستند");
            }
            return View(request);
        }

        public virtual ActionResult FindRequest(string interceptionCode)
        {
            
            
            var request = _requestRepository.FindRequest(interceptionCode);
            if (request == null)
            {
                return View();
            }
            var adminViewModel = new AdminRequestViewModel()
            {
                RequestViewModel = new NewRequestViewModel
                {
                    Name = request.Name,
                    Description = request.Description,
                    Email = request.Email,
                    InterceptionCode = request.InterceptionCode,
                    PhoneNumber = request.PhoneNumber,
                    Subject = request.Subject,
                    DeliveryDays = request.DeliveryDays  
                },
                RequestStatus = request.RequestStatus,
                RejectReason = request.RejectReason,
                Price = request.Price,
                DeadLine = request.DeadLine,
                Progress = request.Progress

            };
            return View(adminViewModel);
        }

        private static string GenerateInterceptionCode()
        {
            var initialCode = Guid.NewGuid().ToString().Split('-');
            return initialCode[0] + initialCode[1];
        }

        private string UploadFile(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Files/"), fileName);
                file.SaveAs(path);
                return path;
            }
            return "";
        }


        private void AddMenu()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            Menu m = new Menu
            {
                Caption = "محصولات",
                Children = new List<Menu>()
                {
                    new Menu() {Caption = "Sum"}
                }
            };

            dbContext.Menues.Add(m);
            dbContext.SaveChanges();
        }


        private IList<Menu> GetAll()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            return dbContext.Menues.Where(m => m.ParenId == null)
                .Include(c => c.Children).ToList();
        }
    }
}
