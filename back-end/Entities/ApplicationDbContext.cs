using Microsoft.EntityFrameworkCore;
namespace API.Entities{

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(){

    
        
    }
    public DbSet<Doctor>  doctors{get;set;}
    public DbSet <Specialtyy> specialtyys{get;set;}
        public DbSet <Metting> mettings{get;set;}
        public DbSet <Patient> Patients {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){

        optionsBuilder.UseSqlite("Filename=./data.db");



    }


}
}