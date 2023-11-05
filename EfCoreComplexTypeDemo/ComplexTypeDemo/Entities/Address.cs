using System.ComponentModel.DataAnnotations.Schema;

namespace ComplexTypeDemo.Entities;

public class Address
{
    public string City { get; set; }
    public string Line1 { get; set; }
    public string? Line2 { get; set; }
    public string PostCode { get; set; }
}