using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagination.Models;

[Table("Users")]
public class Users
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int EmployeeID { get; set; }
        
    [Column("FirstName")]
    [MaxLength(50)]
    public string FirstName { get; set; }
        
    [Column("LastName")]
    [MaxLength(50)]
    public string LastName { get; set; }    
        
    [Column("Email")]
    [MaxLength(50)]
    public string Email { get; set; }
        
    [Column("Age")]
    public int Age { get; set; }    
}