using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Competitor : BaseEntity
{
    [Required]
    public string Name { get; set; }

    public int Age { get; set; }

    [Required]
    public string Skill { get; set; }

    // Foreign Key
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public Category Category { get; set; }
}
