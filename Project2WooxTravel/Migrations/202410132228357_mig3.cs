﻿namespace Project2WooxTravel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);
            
            AlterColumn("dbo.Categories", "CategoryStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "CategoryStatus", c => c.String());
            DropTable("dbo.Admins");
        }
    }
}