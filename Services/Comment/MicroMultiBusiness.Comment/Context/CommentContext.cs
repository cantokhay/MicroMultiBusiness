using MicroMultiBusiness.Comment.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroMultiBusiness.Comment.Context
{
    public class CommentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1442;initial Catalog=MicroMultiBusinessCommentDb;User=sa;Password=230491Can.");
        }

        public DbSet<UserComment> UserComments { get; set; }
    }
}