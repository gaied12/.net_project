using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using  store_server_main.Dto;


namespace  API.Controller
{
    [ApiController]

    public class DoctorController:ControllerBase
    {
private readonly ApplicationDbContext ctx = new ApplicationDbContext();


[HttpPost]
[Route("add/doctor")]
public Doctor create (DoctorDto d)

{
    
    Doctor doctor=new Doctor();
    doctor.email=d.email;
    doctor.address=d.address;
    doctor.firstName=d.firstName;
    doctor.lastName=d.lastName;
    doctor.number=d.phoneNum;
    var spec=ctx.specialtyys.Find(d.specId);
    Console.WriteLine(spec);
    doctor.specialty=spec;
    doctor.city=d.city;
    doctor.password=d.password;


    ctx.doctors.Add(doctor);
ctx.SaveChanges();
return doctor;


}
 
 [HttpPost]
[Route("auth/doctor")]
public int auth (LoginDto loginDto){
    Console.WriteLine(loginDto.email);
   var c = ctx.doctors.Where(x=>x.email == loginDto.email).FirstOrDefault();
         
          if(c!=null && c.password==loginDto.password ){

           return c.Id ;
          }
         

         return -1;
    


}
 [HttpGet]
[Route("all/doctor")]
public ICollection<Doctor> allDoctors (){
  Console.WriteLine(ctx.doctors.ToList<Doctor>());
return ctx.doctors.Include(x=>x.specialty).ToList<Doctor>();


  


}
 [HttpGet]
[Route("all/doctor/filter")]
public ICollection<Doctor> allDoctorsBySpec (string adresse,int specId){

ICollection<Doctor> doctors=ctx.doctors.Include(x =>x.specialty).Where(x=>x.city==adresse && x.specialty.Id==specId).ToList();

  return doctors;



    }
[HttpGet]
[Route("doctor/{id}")]
public virtual Doctor? doctorByID (int id){


Doctor doctor=ctx.doctors.Include(x=>x.specialty).FirstOrDefault(x =>x.Id==id);



  return doctor;




    }

    }
}