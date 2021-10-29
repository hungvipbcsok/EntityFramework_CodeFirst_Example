namespace EntityFramework_CodeFirst_Example.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityFramework_CodeFirst_Example.Model.ManagePaymentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EntityFramework_CodeFirst_Example.Model.ManagePaymentContext";
        }

        protected override void Seed(EntityFramework_CodeFirst_Example.Model.ManagePaymentContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
