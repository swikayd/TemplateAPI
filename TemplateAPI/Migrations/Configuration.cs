namespace TemplateAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TemplateAPI.Models.TemplateAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TemplateAPI.Models.TemplateAPIContext context)
        {
            context.Templates.AddOrUpdate(
                 p => p.Id,
                 new Models.Template
                 {
                     TemplateId = 1,
                     Json = "Test",
                     CreationDate = DateTime.Today,
                     Version = "1.2.0"
                 },
                 new Models.Template
                 {
                     TemplateId = 2,
                     Json = "Test2",
                     CreationDate = DateTime.Today,
                     Version = "2.2.0"
                 }
                 );

        }
    }
}
