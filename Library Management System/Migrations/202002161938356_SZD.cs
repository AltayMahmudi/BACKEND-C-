namespace Library_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SZD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookInfoes",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        BookName = c.String(nullable: false, maxLength: 50),
                        BookAuthor = c.String(nullable: false, maxLength: 50),
                        BookPublicationName = c.String(nullable: false, maxLength: 50),
                        BookReleaseDate = c.DateTime(nullable: false, storeType: "date"),
                        BookPrice = c.String(nullable: false, maxLength: 50),
                        BookQuantity = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.BookID);
            
            CreateTable(
                "dbo.OrderBooks",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        BookOrderName = c.String(nullable: false, maxLength: 50),
                        PersonOrderName = c.String(nullable: false, maxLength: 50),
                        Deadline = c.DateTime(nullable: false, storeType: "date"),
                        IssueDate = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 15),
                        Email = c.String(nullable: false, maxLength: 50),
                        BookInventory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        İd = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 100),
                        BookInfos_BookID = c.Int(),
                    })
                .PrimaryKey(t => t.İd)
                .ForeignKey("dbo.BookInfoes", t => t.BookInfos_BookID)
                .Index(t => t.BookInfos_BookID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "BookInfos_BookID", "dbo.BookInfoes");
            DropIndex("dbo.Users", new[] { "BookInfos_BookID" });
            DropTable("dbo.Users");
            DropTable("dbo.People");
            DropTable("dbo.OrderBooks");
            DropTable("dbo.BookInfoes");
        }
    }
}
