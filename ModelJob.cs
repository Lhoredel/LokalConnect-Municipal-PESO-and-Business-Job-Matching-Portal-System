public class Job
{
    public int JobId { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Title { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    public string CompanyName { get; set; }
    
    [Required]
    public string Location { get; set; }
    
    [Required]
    public string JobType { get; set; }  
    [Required]
    public string Category { get; set; }  
    [Range(0, double.MaxValue)]
    public decimal? Salary { get; set; }
    
    public DateTime PostedDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    
    public bool IsActive { get; set; }
    public int BusinessId { get; set; }
  
    public virtual Business Business { get; set; }
    public virtual ICollection<JobApplication> JobApplications { get; set; }
}
