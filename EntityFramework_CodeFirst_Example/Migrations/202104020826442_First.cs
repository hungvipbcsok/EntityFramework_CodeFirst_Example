namespace EntityFramework_CodeFirst_Example.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contracts", "TestColumn", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contracts", "TestColumn");
        }
    }
}
