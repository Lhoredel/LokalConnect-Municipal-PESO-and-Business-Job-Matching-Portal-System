public class HomeController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();
    
    public ActionResult Index()
    {
        var viewModel = new HomeViewModel
        {
            RecentJobs = db.Jobs
                .Where(j => j.IsActive && j.ExpiryDate > DateTime.Now)
                .OrderByDescending(j => j.PostedDate)
                .Take(6)
                .ToList(),
            JobCount = db.Jobs.Count(j => j.IsActive && j.ExpiryDate > DateTime.Now),
            BusinessCount = db.Businesses.Count(),
            JobSeekerCount = db.JobSeekers.Count()
        };
        
        return View(viewModel);
    }
    
    public ActionResult About()
    {
        return View();
    }
    
    public ActionResult Contact()
    {
        return View();
    }
}
