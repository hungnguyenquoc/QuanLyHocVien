namespace QuanLyHocVien.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingCourses",
                c => new
                    {
                        Book_ID = c.Int(nullable: false, identity: true),
                        Book_Name = c.String(nullable: false, maxLength: 256),
                        Book_Email = c.String(maxLength: 100),
                        Book_Phone = c.String(maxLength: 100),
                        Book_CodeDiscount = c.String(maxLength: 100),
                        PaymentMethod = c.String(maxLength: 256),
                        PaymentStatus = c.String(maxLength: 256),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Book_ID);
            
            CreateTable(
                "dbo.BookingDetails",
                c => new
                    {
                        Book_ID = c.Int(nullable: false),
                        Cou_ID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_ID, t.Cou_ID })
                .ForeignKey("dbo.BookingCourses", t => t.Book_ID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Cou_ID, cascadeDelete: true)
                .Index(t => t.Book_ID)
                .Index(t => t.Cou_ID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Cou_ID = c.Int(nullable: false, identity: true),
                        Cou_Name = c.String(maxLength: 256),
                        Cou_Alias = c.String(maxLength: 256),
                        Cou_Description = c.String(maxLength: 256),
                        Cou_Content = c.String(),
                        Cou_Image = c.String(maxLength: 256),
                        Cou_MoreImages = c.String(storeType: "xml"),
                        Cou_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cou_PromotionPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cou_ViewCount = c.Int(),
                        CategoryID = c.Int(nullable: false),
                        Re_ID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Cou_ID)
                .ForeignKey("dbo.CourseCategories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.OpenRegisters", t => t.Re_ID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.Re_ID);
            
            CreateTable(
                "dbo.CourseCategories",
                c => new
                    {
                        Cate_ID = c.Int(nullable: false, identity: true),
                        Cate_Name = c.String(nullable: false, maxLength: 256),
                        Cate_Alias = c.String(nullable: false, maxLength: 256),
                        Cate_Description = c.String(maxLength: 500),
                        Cate_Image = c.String(maxLength: 256),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Cate_ID);
            
            CreateTable(
                "dbo.OpenRegisters",
                c => new
                    {
                        Re_ID = c.Int(nullable: false, identity: true),
                        Re_Name = c.String(maxLength: 256),
                        Time_Start = c.DateTime(nullable: false),
                        Time_End = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Re_ID);
            
            CreateTable(
                "dbo.ProductTags",
                c => new
                    {
                        Cou_ID = c.Int(nullable: false),
                        Tag_ID = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.Cou_ID, t.Tag_ID })
                .ForeignKey("dbo.Courses", t => t.Cou_ID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.Tag_ID, cascadeDelete: true)
                .Index(t => t.Cou_ID)
                .Index(t => t.Tag_ID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Tag_ID = c.String(nullable: false, maxLength: 50),
                        Tag_Name = c.String(nullable: false, maxLength: 50),
                        Tag_Type = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Tag_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductTags", "Tag_ID", "dbo.Tags");
            DropForeignKey("dbo.ProductTags", "Cou_ID", "dbo.Courses");
            DropForeignKey("dbo.BookingDetails", "Cou_ID", "dbo.Courses");
            DropForeignKey("dbo.Courses", "Re_ID", "dbo.OpenRegisters");
            DropForeignKey("dbo.Courses", "CategoryID", "dbo.CourseCategories");
            DropForeignKey("dbo.BookingDetails", "Book_ID", "dbo.BookingCourses");
            DropIndex("dbo.ProductTags", new[] { "Tag_ID" });
            DropIndex("dbo.ProductTags", new[] { "Cou_ID" });
            DropIndex("dbo.Courses", new[] { "Re_ID" });
            DropIndex("dbo.Courses", new[] { "CategoryID" });
            DropIndex("dbo.BookingDetails", new[] { "Cou_ID" });
            DropIndex("dbo.BookingDetails", new[] { "Book_ID" });
            DropTable("dbo.Tags");
            DropTable("dbo.ProductTags");
            DropTable("dbo.OpenRegisters");
            DropTable("dbo.CourseCategories");
            DropTable("dbo.Courses");
            DropTable("dbo.BookingDetails");
            DropTable("dbo.BookingCourses");
        }
    }
}
