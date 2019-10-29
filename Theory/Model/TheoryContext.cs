using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theory.Model;

namespace Theory.Model
{
    public class TheoryContext: IdentityDbContext
    {
        public TheoryContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Theory.Model.Questions> Questions { get; set; }

        public DbSet<Theory.Model.StudentAnswers> StudentAnswers { get; set; }
        public DbSet<Theory.Model.Answer> Answer { get; set; }

    }
}
