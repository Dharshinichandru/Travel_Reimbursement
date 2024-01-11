
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Travel_Reimbursement.Models;
using Travel_Reimbursement.Models.Domain;

namespace Travel_Reimbursement.ContextDBConfig
{
    public class Travel_ReimbursementDbContext : IdentityDbContext<ApplicationUser>
    {
        public Travel_ReimbursementDbContext(DbContextOptions<Travel_ReimbursementDbContext> options) : base(options)
        {   

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<TravelModel> ? Traveltable {get;set;}
        public virtual DbSet<FileModel> Filetable {get; set;}
        public DbSet<ManagerRegisterModel> ? ManagerRegistertable {get;set;}
      
    }
}