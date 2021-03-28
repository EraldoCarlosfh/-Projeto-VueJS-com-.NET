
using ApiNetCoreBox.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiNetCoreBox.Data{
    public class DataContext: DbContext{

        public DataContext(DbContextOptions<DataContext> options) : base(options){
            Database.EnsureCreated();
        }

        public DbSet<Technical> Technicals { get; set; }    

        public DbSet<Stack> Stacks {get; set;}

    }

}