using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace Models {
public class Interest
{

    public int Id { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
}
}