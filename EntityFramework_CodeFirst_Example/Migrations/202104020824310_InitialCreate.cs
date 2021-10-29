namespace EntityFramework_CodeFirst_Example.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        ContractId = c.Int(nullable: false, identity: true),
                        ContractName = c.String(nullable: false, maxLength: 225),
                        ContractTypeId = c.Int(nullable: false),
                        AttendName = c.String(nullable: false, maxLength: 20),
                        ContractDate = c.DateTime(nullable: false),
                        ContractStart = c.DateTime(nullable: false),
                        ContractEnd = c.DateTime(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Customer_CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.ContractId)
                .ForeignKey("dbo.ContractTypes", t => t.ContractTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .Index(t => t.ContractTypeId)
                .Index(t => t.Customer_CustomerId);
            
            CreateTable(
                "dbo.ContractTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContractTypeName = c.String(nullable: false),
                        MinValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 225),
                        CompanyAddress = c.String(nullable: false, maxLength: 225),
                        CompanyPhoneNumber = c.String(nullable: false, maxLength: 20),
                        CompanyEmail = c.String(nullable: false, maxLength: 50),
                        CompanyTaxCode = c.String(nullable: false, maxLength: 20),
                        RepresentiveName = c.String(nullable: false, maxLength: 50),
                        RepresentiveEmail = c.String(nullable: false, maxLength: 50),
                        RepresentivePhoneNumber = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        PaymentNumber = c.Int(nullable: false),
                        PaymentCode = c.String(nullable: false, maxLength: 20),
                        PaymentAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Representative = c.String(nullable: false, maxLength: 225),
                        InvoiceCode = c.String(nullable: false, maxLength: 20),
                        Contract_ContractId = c.Int(),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.Contracts", t => t.Contract_ContractId)
                .Index(t => t.Contract_ContractId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "Contract_ContractId", "dbo.Contracts");
            DropForeignKey("dbo.Contracts", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Contracts", "ContractTypeId", "dbo.ContractTypes");
            DropIndex("dbo.Payments", new[] { "Contract_ContractId" });
            DropIndex("dbo.Contracts", new[] { "Customer_CustomerId" });
            DropIndex("dbo.Contracts", new[] { "ContractTypeId" });
            DropTable("dbo.Payments");
            DropTable("dbo.Customers");
            DropTable("dbo.ContractTypes");
            DropTable("dbo.Contracts");
        }
    }
}
