namespace StockMaximumGain.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Bridge : DbContext
    {
        public Bridge()
            : base("name=Bridge")
        {
        }

        public virtual DbSet<rsi> rsi { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
