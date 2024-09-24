using System.ComponentModel.DataAnnotations;

public class Alert
{
    
    public int ID { get; set; }
    public DateTime AlertDate { get; set; }
    [Required]
    [MinLength(20), MaxLength(200)]
    public string Description { get; set; }

    public bool IsResolved { get; set; }

    public int ProductID { get; set; }
    public Product Product { get; set; }
}
