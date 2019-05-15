using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DockerProject;

namespace DockerProject.Models
{
    public class DockerProjectContext : DbContext
    {
        public DockerProjectContext (DbContextOptions<DockerProjectContext> options)
            : base(options)
        {
        }

        public DbSet<DockerProject.EntityTest> EntityTest { get; set; }

        public DbSet<DockerProject.EntityTest2> EntityTest2 { get; set; }
    }
}
