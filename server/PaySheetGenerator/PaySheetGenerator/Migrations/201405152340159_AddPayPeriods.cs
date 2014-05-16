namespace PaySheetGenerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddPayPeriods : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PayPeriods",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TimeStarted = c.DateTime(nullable: false, defaultValue: DateTime.UtcNow),
                        TimeEnded = c.DateTime(),
                        TimeClaimed = c.DateTime(),
                        TimePaid = c.DateTime(),
                        Description = c.String(),
                        Notes = c.String(),
                        Employee_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employees", t => t.Employee_ID)
                .Index(t => t.Employee_ID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.PayPeriods", "Employee_ID", "dbo.Employees");
            DropIndex("dbo.PayPeriods", new[] { "Employee_ID" });
            DropTable("dbo.PayPeriods");
        }
    }
}
