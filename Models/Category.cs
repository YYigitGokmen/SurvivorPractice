using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Category : BaseEntity
{
    [Required]
    public string Name { get; set; }

    // One-to-many relationship: One Category can have many Competitors
    public List<Competitor> Competitors { get; set; }
}
