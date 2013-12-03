using System.Data.Entity;
using StudentportalenAPI.DAL.Configuration.Entityframework;

namespace StudentportalenAPI.DAL
{
    public class DbInitializer : DropCreateDatabaseAlways<StudentportalenAPIDbContext>
    {
        protected override void Seed(StudentportalenAPIDbContext context)
        {
            var uow = new UnitOfWork(context);

            //uow.ArticleRepository.Insert(new Article { Body = "<p>Heyo content!</p>", Title = "Title" , Ignored = "NOT OUTPUTTEDEDED"});
            uow.SaveChangesAsync();
        }
    }
}