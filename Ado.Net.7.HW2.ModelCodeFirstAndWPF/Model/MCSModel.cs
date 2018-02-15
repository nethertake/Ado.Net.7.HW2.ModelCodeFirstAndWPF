namespace Ado.Net._7.HW2.ModelCodeFirstAndWPF.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MCSModel : DbContext
    {
        public MCSModel()
            : base("name=MCSModel1")
        {
        }

        public virtual DbSet<TablesManufacturer> TablesManufacturers { get; set; }
        public virtual DbSet<TablesModel> TablesModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
