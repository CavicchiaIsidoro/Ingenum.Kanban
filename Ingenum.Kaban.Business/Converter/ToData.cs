using Ingenum.Kaban.Business.Models;
using Ingenum.Kanban.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ingenum.Kaban.Business.Converter
{
    public static class ToData
    {
        #region BoardBusiness -> Board
        public static Board ToBoard(this BoardBusiness model)
        {
            return new Board
            {
                BoardName = model.BoardName,
                Username = model.Username,
                IsLocked = model.IsLocked,
                Tasks = model.Tasks.ToTask().ToList()
            };
        }

        public static IEnumerable<Board> ToBoard(this IEnumerable<BoardBusiness> listModel) => listModel.Select(b => b.ToBoard());
        #endregion

        #region TaskBusiness -> Task
        public static Task ToTask(this TaskBusiness model)
        {
            return new Task
            {
                Description = model.Description,
                EndDate = model.EndDate,
                Intitule = model.Intitule,
                TaskId = model.TaskId,
                Section = (SectionEnum)model.Section,
                BoardId = model.BoardId
            };
        }

        public static IEnumerable<Task> ToTask(this IEnumerable<TaskBusiness> listModel) => listModel.Select(t => t.ToTask());
        #endregion
    }
}
