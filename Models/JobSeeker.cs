public class JobSeeker
{
    public int JobSeekerId { get; set; }
    
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }
    
    [Required]
    [StringLength(50)]
    public string LastName { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Phone]
    public string Phone { get; set; }
    
    public string Address { get; set; }
    public string City { get; set; }
    
    public string Skills { get; set; }
    public string Education { get; set; }
    public string Experience { get; set; }
    public string ResumePath { get; set; }
    
    public DateTime RegistrationDate { get; set; }
    
    public virtual ICollection<JobApplication> JobApplications { get; set; }
}
