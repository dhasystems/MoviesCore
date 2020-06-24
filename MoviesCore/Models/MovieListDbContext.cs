using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCore.Models
{
    public class MovieListDbContext : DbContext 
    {
        public MovieListDbContext(DbContextOptions<MovieListDbContext> options) : base(options)
        {

        }
        public DbSet<MovieListModel> MovieLists { get; set; }
    }
}
