using Ingenum.Kaban.Business.Converter;
using Ingenum.Kaban.Business.Models;
using Ingenum.Kaban.Business.Models.Enum;
using Ingenum.Kaban.Business.Repository;
using System;
using Xunit;

namespace Ingenum.Kanban.Test
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            var repo = new TaskReposiroty(new Data.IngenumKanbanContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Data.IngenumKanbanContext>()));
            TaskBusiness task = new TaskBusiness
            {
                Description = "Test",
                EndDate = DateTime.Now,
                Intitule = "Test",
                Section = SectionEnumBusiness.TODO,
            };

            //var result = await repo.AddTest(task);

            //Assert.True(result);

        }
    }
}
