public class Business
{
    public int BusinessId { get; set; }
    
    [Required]
    [StringLength(100)]
    public string CompanyName { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Phone]
    public string Phone { get; set; }
    
    public string Address { get; set; }
    public string City { get; set; }
    
    [StringLength(100)]
    public string Industry { get; set; }
    
    public string Description { get; set; }
    public string Website { get; set; }
    
    public DateTime RegistrationDate { get; set; }
    public bool IsVerified { get; set; }
    
    public virtual ICollection<Job> Jobs { get; set; }
}
