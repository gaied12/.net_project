using System.Net.Mail;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store_server_main.Dto;
using store_server_main.Services;

namespace API.Controller
{
    [ApiController]

    public class MettingsController:ControllerBase
    {
      private const string msgNo="votre rendez vous est annulé veuillez choisir une autre date !";
      private const string msgYes="Félicitation Votre Rendez-vous est accepté Soyez à l'heure !";
        EmailServices email=new  EmailServices();

      
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();

[HttpPost]

[Route("add/metting")]
public Metting create (MettingDto m)

{
    Patient patient=new Patient();
    patient.firstName=m.firstName;
    patient.lastName=m.lastName;
    patient.email=m.email;
    patient.phone=m.phoneNum;
    ctx.Patients.Add(patient);
    ctx.SaveChanges();
    Metting metting=new Metting();
    Doctor doctor=new Doctor();
    Console.WriteLine(m.doctorId);
    doctor=ctx.doctors.Find(m.doctorId);
    metting.doctor=doctor;
    metting.patient=patient;
    metting.start=m.time;
    metting.date=m.date;
    metting.state=State.PENDING;
    ctx.mettings.Add(metting);
    ctx.SaveChanges();

    
return metting;
}
[HttpGet]
[Route("alll/metting/{id}")]
public ICollection<Metting> allMetById (int id){

ICollection<Metting> mettings=ctx.mettings.Include(x =>x.doctor).Include(x =>x.patient).Where(x=>x.state==State.PENDING && x.doctor.Id==id).ToList();

  return mettings;


    }
    [HttpGet]

[Route("accept/metting/{id}")]
public Metting acceptMet (int id){
var metting=ctx.mettings.Include(x=>x.doctor).Include(x=>x.patient).FirstOrDefault(x =>x.Id==id);
metting.state=State.ACCEPTED;
ctx.SaveChanges();
  email.SenEmailConf(metting.patient.email,msgYes);



  return metting;



    }
    [HttpGet]

    [Route("cancel/metting/{id}")]
public Metting cancelMet (int id){
Metting metting=ctx.mettings.Find(id);
metting.state=State.CANCEL;
ctx.SaveChanges();
  email.SenEmailConf(metting.patient.email,msgNo);



  return metting;



    }
[HttpGet]
[Route("all/meet/aceppted/{id}")]
public ICollection<Metting> allMettingAccep (int id){

ICollection<Metting> mettings=ctx.mettings.Include(x =>x.doctor).Include(x =>x.patient).Where(x=>x.state==State.ACCEPTED && x.doctor.Id==id).ToList();
  return mettings;

    }
    [HttpGet]
[Route("send/email")]
public void sendEmail(){

}



   










 

    }



}