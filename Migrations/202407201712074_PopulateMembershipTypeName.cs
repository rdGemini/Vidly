namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET NAME = 'Pay as you go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET NAME = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET NAME = 'Quaterly' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET NAME = 'Annual' WHERE Id = 4");
            AddColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
        }
    }
}
