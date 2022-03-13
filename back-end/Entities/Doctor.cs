using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace API.Entities
{
    public class Doctor
    {
public int Id { get; set; }
public string email{ get; set;}
public string password{ get; set;}
public string firstName { get; set;}
public string lastName { get; set;}
public long number { get; set;}


        [Required]
public virtual Specialtyy specialty { get; set;}

public string city { get; set;}

public string address { get; set;}
public ICollection<Metting> mettings ;

    }
    
}