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
        [Theory]
        [InlineData(1)]
        public void DeleteTask(int id)
        {
            // 1. Arrange
            var repo = new TaskReposiroty(new Data.IngenumKanbanContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Data.IngenumKanbanContext>()));
            var task = repo.Get(id);

            // 2. Act
            var result = repo.Delete(task);

            // 3. Assert
            Assert.True(result);
        }
    }
}
