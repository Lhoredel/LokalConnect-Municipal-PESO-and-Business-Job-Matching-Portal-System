public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() : base("name=DefaultConnection")
    {
    }
    
    public DbSet<Job> Jobs { get; set; }
    public DbSet<JobSeeker> JobSeekers { get; set; }
    public DbSet<Business> Businesses { get; set; }
    public DbSet<JobApplication> JobApplications { get; set; }
    
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // Configure relationships
        modelBuilder.Entity<Job>()
            .HasRequired(j => j.Business)
            .WithMany(b => b.Jobs)
            .HasForeignKey(j => j.BusinessId);
            
        modelBuilder.Entity<JobApplication>()
            .HasRequired(ja => ja.Job)
            .WithMany(j => j.JobApplications)
            .HasForeignKey(ja => ja.JobId);
            
        modelBuilder.Entity<JobApplication>()
            .HasRequired(ja => ja.JobSeeker)
            .WithMany(js => js.JobApplications)
            .HasForeignKey(ja => ja.JobSeekerId);
    }
}
