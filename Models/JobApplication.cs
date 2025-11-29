public class JobApplication
{
    public int JobApplicationId { get; set; }
    public int JobId { get; set; }
    public int JobSeekerId { get; set; }
    
    public DateTime ApplicationDate { get; set; }
    
    [StringLength(500)]
    public string CoverLetter { get; set; }
    
    public string Status { get; set; } // Pending, Reviewed, Accepted, Rejected
    
    // Navigation properties
    public virtual Job Job { get; set; }
    public virtual JobSeeker JobSeeker { get; set; }
}
