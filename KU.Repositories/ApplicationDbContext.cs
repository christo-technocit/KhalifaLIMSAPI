using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KU.Repositories.Models;



namespace KU.Repositories
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public string CurrentUserId { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        { 
          
        
        }

        public DbSet<SavedForm> SavedForm { get; set; }
        public DbSet<Template> Template { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<FormAttribute> FormAttribute { get; set; }
        public DbSet<FormAttributeValue> FormAttributeValue { get; set; }
        public DbSet<TotalRecords> Totalrecords { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ApplicationUsers> ApplicationUsers { get; set; }
        public DbSet<ApplicationUsersDelete> ApplicationUsersDelete { get; set; }
        public DbSet<ApplicationUsersList> ApplicationUsersList { get; set; }
        public DbSet<UserGroups> UserGroups { get; set; }
        public DbSet<FormAttributeValue_files> formAttributeValue_Files { get; set; }
        public DbSet<Questionnaire> Questionnaire { get; set; }
        public DbSet<CountryMaster> CountryMaster { get; set; }
        public DbSet<GenericResult> GenericResult { get; set; }

    }
}

