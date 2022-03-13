using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using  store_server_main.Dto;


namespace  API.Controller
{
    [ApiController]

    public class SpecialityController:ControllerBase
    {
private readonly ApplicationDbContext ctx = new ApplicationDbContext();


[HttpGet]
[Route("add/spec")]

public  void create ()

{

    foreach (Specialty i in Enum.GetValues(typeof(Specialty)))  
{  

  var x= ctx.specialtyys.Where(c => c.specialty==i).FirstOrDefault();
Console.WriteLine(x);


    if(x==null){
      Specialtyy specialtyy=new Specialtyy();
      specialtyy.specialty=i;
      ctx.specialtyys.Add(specialtyy);
ctx.SaveChanges();


    }
}

    


}
[HttpGet]
[Route("/speciality/all")]
public ICollection<Specialtyy> get(){
      Console.WriteLine( ctx.specialtyys.ToList());

  return (ICollection<Specialtyy>)ctx.specialtyys.ToArray().AsEnumerable();
   




}

    }
        
    
}