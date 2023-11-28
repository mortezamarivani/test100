using System.Linq;
using Microsoft.EntityFrameworkCore;
using Gx.DataLayer.Entities.Crud;

namespace Gx.DataLayer.Context
{
    public class GxDbContext : DbContext
    {
        #region constructor

        public GxDbContext(DbContextOptions<GxDbContext> options) : base(options)
        {
        }

        #endregion

        #region Db Sets

        public DbSet<Crud> Crud { get; set; }

        #endregion

        #region disable cascading delete in database

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascades = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascades)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}