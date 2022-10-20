using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Recruitment.Models;
using Recruitment.Repository;
using System.Diagnostics;
using System.Linq;

namespace Recruitment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CategoryRepository categoryRep = new CategoryRepository();
        private CountryRepository countryRepository = new CountryRepository();
        private ExperienceRepository experienceRepository = new ExperienceRepository();
        private SalaryRepository salaryRepository = new SalaryRepository();
        private VacancyRepository vacancyRepository = new VacancyRepository();
        private JobTitleRepository JobTitleRepository = new JobTitleRepository();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index(VacancySearchViewModel vacancySearchViewModel)
        {
            ViewBag.Categories = categoryRep.GetAllCategories();
            ViewBag.Countries = countryRepository.GetAllCountries();
            ViewBag.Salaries = salaryRepository.GetAllSalaries();
            ViewBag.Experiences = experienceRepository.GetAllExperiencies();
            ViewBag.JobTitle = Enumerable.Empty<SelectListItem>();

             //================Solution #1===============
            //var x = vacancyRepository.GetAllVacancies(vacancySearchViewModel.JobTitleID,
            //    vacancySearchViewModel.CategoryID,vacancySearchViewModel.Description, 
            //    vacancySearchViewModel.CountryID, vacancySearchViewModel.YearsOfExperienceID,
            //    vacancySearchViewModel.SalaryID);
            //return View(x); // this work in call direct repository and send to view
            //===========================================================
            ////================Solution #2===============
            //var x = Get(vacancySearchViewModel.JobTitleID,
            //    vacancySearchViewModel.CategoryID, vacancySearchViewModel.Description,
            //    vacancySearchViewModel.CountryID, vacancySearchViewModel.YearsOfExperienceID,
            //    vacancySearchViewModel.SalaryID);
            //return View(x.Value); // this work in call api repository 
            //===========================================================
            return View(new VacancySearchViewModel());
        }
        public IActionResult vacancyApply()
        {
            ViewBag.Categories = categoryRep.GetAllCategories();
            ViewBag.Countries = countryRepository.GetAllCountries();
            ViewBag.Salaries = salaryRepository.GetAllSalaries();
            ViewBag.Experiences = experienceRepository.GetAllExperiencies();
            ViewBag.JobTitle = Enumerable.Empty<SelectListItem>();
            return View(new CandidateCvModel());
        }
        [HttpPost]
        public IActionResult vacancyApply(int? JobTitleID, int? CategoryID, string Description, int? CountryID,
         int? YearsOfExperienceID, int? SalaryID)
        {
            ViewBag.Categories = categoryRep.GetAllCategories();
            ViewBag.Countries = countryRepository.GetAllCountries();
            ViewBag.Salaries = salaryRepository.GetAllSalaries();
            ViewBag.Experiences = experienceRepository.GetAllExperiencies();
            ViewBag.JobTitle = Enumerable.Empty<SelectListItem>();
            return View(new CandidateCvModel());
        }
        [HttpGet]
        public JsonResult Get(int? JobTitleID, int? CategoryID,string Description,int? CountryID,
         int? YearsOfExperienceID,int? SalaryID)
        {
            var mod = vacancyRepository.GetAllVacancies( JobTitleID,CategoryID,  Description, CountryID,YearsOfExperienceID, SalaryID);
            return Json(mod);
        }
        public JsonResult LoadJobTitle(int categoryID)
        {
            var JobTitle = JobTitleRepository.GetJobTitleByCategory( categoryID );
            var JobTitlesData = JobTitle.Select(m => new SelectListItem()
            {
                Text = m.Title.ToString(),
                Value = m.Id.ToString(),
            });
            return Json(JobTitlesData);
        }
        //public ActionResult AddEditSector(string EncryptedId)
        //{
        //    if (Session["UserRole"].ToString() != "1" && Session["UserRole"].ToString() != "4")
        //        return RedirectToAction("AccessDenied", "Home");
        //    try
        //    {
        //        ViewBag.userRoles = db.Roles.ToList();
        //        ViewBag.Branches = db.Branches.Where(a => a.IsHead_quarter == true).ToList();

        //        ViewBag.Sectors = db.Sectors.ToList();

        //        ViewBag.Departments = db.Departments.ToList();
        //        ViewBag.EnableButton = true;
        //        if (ModelState.IsValid)
        //        {
        //            int decId = 0;
        //            if (EncryptedId != null && EncryptedId != "0")
        //            {
        //                decId = int.Parse(simpleAES.DecryptString(EncryptedId));
        //            }
        //            if (decId != 0)
        //            {
        //                SectorModel sectorMol = sectorEntityToModel(db.Sectors.Find(decId));

        //                return View(sectorMol);
        //            }
        //            else
        //            {
        //                return View();
        //            }
        //        }
        //        return View();

        //    }
        //    catch (Exception ex)
        //    {

        //        return View(ex);
        //    }
        //}
        //[HttpPost]
        //public ActionResult AddEditSector(string EncryptedId, SectorModel sectorMdl)
        //{
        //    try
        //    {
        //        ViewBag.Branches = db.Branches.Where(a => a.IsHead_quarter == true).ToList();

        //        ViewBag.Sectors = db.Sectors.ToList();
        //        ViewBag.Roles = db.Roles.ToList();
        //        sectorMdl.EncryptID = EncryptedId;
        //        // TODO: Add update logic here
        //        if (ModelState.IsValid)
        //        {
        //            int decId = 0;
        //            if (EncryptedId != "0" && EncryptedId != null)
        //            {
        //                decId = int.Parse(simpleAES.DecryptString(EncryptedId));
        //            }
        //            if (decId != 0)
        //            {
        //                var result = db.Sectors.Where(a => a.ID != decId).AsQueryable();
        //                if (result.Where(x => x.SectorCode == sectorMdl.SectorCode).ToList().Count > 0)
        //                {
        //                    ModelState.AddModelError("SectorCode", MidBank_Inbox_WorkFlow.Language.Resource.SectorCodeError);


        //                    return View(sectorMdl);
        //                }
        //                if (result.Where(x => x.Name.Trim() == sectorMdl.SectorName.Trim()).ToList().Count > 0)
        //                {
        //                    ModelState.AddModelError("SectorName", MidBank_Inbox_WorkFlow.Language.Resource.SectorNameError);
        //                    return View(sectorMdl);

        //                }
        //                else if (result.Where(x => x.Email == sectorMdl.Email).ToList().Count > 0 && sectorMdl.Email != null)
        //                {
        //                    ModelState.AddModelError("Email", MidBank_Inbox_WorkFlow.Language.Resource.EmailError);
        //                    return View(sectorMdl);
        //                }
        //                Sector sector = db.Sectors.Find(decId);
        //                sectorModelToEntity(sector, sectorMdl);
        //                sector.UpdatedBy = int.Parse(simpleAES.DecryptString(Session["UserID"].ToString()));
        //                sector.UpdatedDate = DateTime.Now;

        //                db.Entry(sector).State = System.Data.Entity.EntityState.Modified;

        //                db.SaveChanges();
        //                return RedirectToAction("Index");
        //            }
        //            else
        //            {
        //                Sector u = new Sector();
        //                sectorModelToEntity(u, sectorMdl);
        //                var result = db.Sectors.AsQueryable();
        //                if (result.Where(x => x.SectorCode == sectorMdl.SectorCode).ToList().Count > 0)
        //                {
        //                    ModelState.AddModelError("SectorCode", MidBank_Inbox_WorkFlow.Language.Resource.SectorCodeError);


        //                    return View(sectorMdl);
        //                }
        //                if (result.Where(x => x.Name.Trim() == sectorMdl.SectorName.Trim()).ToList().Count > 0)
        //                {
        //                    ModelState.AddModelError("SectorName", MidBank_Inbox_WorkFlow.Language.Resource.SectorNameError);
        //                    return View(sectorMdl);

        //                }
        //                else if (result.Where(x => x.Email == sectorMdl.Email).ToList().Count > 0 && sectorMdl.Email != null)
        //                {
        //                    ModelState.AddModelError("Email", MidBank_Inbox_WorkFlow.Language.Resource.EmailError);
        //                    return View(sectorMdl);
        //                }

        //                db.Sectors.Add(u);
        //                db.SaveChanges();

        //                return RedirectToAction("Index");
        //            }

        //        }
        //        else
        //        {
        //            return View(sectorMdl);
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        return View(e);
        //    }
        //}
        public IActionResult Details()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}