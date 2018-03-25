namespace AngularWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewColumnsIntoUsersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "FirstName", c => c.String());
            AddColumn("dbo.User", "LastName", c => c.String());
            AddColumn("dbo.User", "Gender", c => c.String());
            AddColumn("dbo.User", "Titre", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Titre");
            DropColumn("dbo.User", "Gender");
            DropColumn("dbo.User", "LastName");
            DropColumn("dbo.User", "FirstName");
        }
    }
}
