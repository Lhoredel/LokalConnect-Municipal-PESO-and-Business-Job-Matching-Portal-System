public class JobsController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();
 
    public ActionResult Index(string search, string category, string jobType, string location)
    {
        var jobs = db.Jobs
            .Where(j => j.IsActive && j.ExpiryDate > DateTime.Now)
            .Include(j => j.Business);
            
        if (!string.IsNullOrEmpty(search))
        {
            jobs = jobs.Where(j => j.Title.Contains(search) || 
                                 j.Description.Contains(search) ||
                                 j.CompanyName.Contains(search));
        }
        
        if (!string.IsNullOrEmpty(category))
        {
            jobs = jobs.Where(j => j.Category == category);
        }
        
        if (!string.IsNullOrEmpty(jobType))
        {
            jobs = jobs.Where(j => j.JobType == jobType);
        }
        
        if (!string.IsNullOrEmpty(location))
        {
            jobs = jobs.Where(j => j.Location.Contains(location));
        }
        
        var categories = db.Jobs.Select(j => j.Category).Distinct().ToList();
        var jobTypes = db.Jobs.Select(j => j.JobType).Distinct().ToList();
        
        ViewBag.Categories = categories;
        ViewBag.JobTypes = jobTypes;
        
        return View(jobs.ToList());
    }
    
   
    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        
        Job job = db.Jobs
            .Include(j => j.Business)
            .FirstOrDefault(j => j.JobId == id);
            
        if (job == null)
        {
            return HttpNotFound();
        }
        
        return View(job);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Apply(int jobId, string coverLetter)
    {
         
        int jobSeekerId = 1; 
        
        var application = new JobApplication
        {
            JobId = jobId,
            JobSeekerId = jobSeekerId,
            ApplicationDate = DateTime.Now,
            CoverLetter = coverLetter,
            Status = "Pending"
        };
        
        db.JobApplications.Add(application);
        db.SaveChanges();
        
        TempData["SuccessMessage"] = "Application submitted successfully!";
        return RedirectToAction("Details", new { id = jobId });
    }
}
