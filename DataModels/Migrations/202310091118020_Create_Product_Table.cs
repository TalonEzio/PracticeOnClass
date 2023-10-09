namespace DataModels.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Create_Product_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(maxLength: 50),
                    ImageUrl = c.String(maxLength: 128, fixedLength: true),
                    Price = c.Decimal(precision: 18, scale: 2),
                    Discount = c.Int(),
                    Quantity = c.Int(),
                    Rate = c.Int(),
                    Created = c.DateTime(nullable: false),
                    Updated = c.DateTime(),
                    Deleted = c.DateTime(),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
