namespace Library_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DTBS : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderBooks", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Person_PersonID", "dbo.People");
            DropForeignKey("dbo.OrderBooks", "BookId", "dbo.BookInfoes");
            DropIndex("dbo.OrderBooks", new[] { "OrderId" });
            DropIndex("dbo.OrderBooks", new[] { "BookId" });
            DropIndex("dbo.Orders", new[] { "Person_PersonID" });
            RenameColumn(table: "dbo.OrderBooks", name: "BookId", newName: "BookInfo_BookID");
            DropPrimaryKey("dbo.OrderBooks");
            AddColumn("dbo.OrderBooks", "BookName", c => c.String());
            AddColumn("dbo.OrderBooks", "StudientName", c => c.String());
            AddColumn("dbo.OrderBooks", "IssueDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OrderBooks", "OrderID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.OrderBooks", "BookInfo_BookID", c => c.Int());
            AddPrimaryKey("dbo.OrderBooks", "OrderID");
            CreateIndex("dbo.OrderBooks", "BookInfo_BookID");
            AddForeignKey("dbo.OrderBooks", "BookInfo_BookID", "dbo.BookInfoes", "BookID");
            DropColumn("dbo.OrderBooks", "id");
            DropTable("dbo.Orders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Money = c.Single(nullable: false),
                        BookReturnededDate = c.DateTime(nullable: false),
                        Person_PersonID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderID);
            
            AddColumn("dbo.OrderBooks", "id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.OrderBooks", "BookInfo_BookID", "dbo.BookInfoes");
            DropIndex("dbo.OrderBooks", new[] { "BookInfo_BookID" });
            DropPrimaryKey("dbo.OrderBooks");
            AlterColumn("dbo.OrderBooks", "BookInfo_BookID", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderBooks", "OrderID", c => c.Int(nullable: false));
            DropColumn("dbo.OrderBooks", "IssueDate");
            DropColumn("dbo.OrderBooks", "StudientName");
            DropColumn("dbo.OrderBooks", "BookName");
            AddPrimaryKey("dbo.OrderBooks", "id");
            RenameColumn(table: "dbo.OrderBooks", name: "BookInfo_BookID", newName: "BookId");
            CreateIndex("dbo.Orders", "Person_PersonID");
            CreateIndex("dbo.OrderBooks", "BookId");
            CreateIndex("dbo.OrderBooks", "OrderId");
            AddForeignKey("dbo.OrderBooks", "BookId", "dbo.BookInfoes", "BookID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "Person_PersonID", "dbo.People", "PersonID");
            AddForeignKey("dbo.OrderBooks", "OrderId", "dbo.Orders", "OrderID", cascadeDelete: true);
        }
    }
}
