using Ingenum.Kaban.Business.Models;
using Ingenum.Kaban.Business.Models.Enum;
using Ingenum.Kanban.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ingenum.Kaban.Business.Converter
{
    public static class ToBusiness
    {
        #region Board -> BoardBusiness
        public static BoardBusiness ToBardBusiness(this Board model)
        {
            return new BoardBusiness
            {
                BoardId = model.BoardId,
                BoardName = model.BoardName,
                Username = model.Username,
                IsLocked = model.IsLocked,
                Tasks = model.Tasks?.ToTaskBusiness() ?? new List<TaskBusiness>()
            };
        }

        public static IEnumerable<BoardBusiness> ToBoardBusiness(this IEnumerable<Board> listModel) => listModel.Select(b => b.ToBardBusiness());
        #endregion

        #region Task -> TaskBusiness
        public static TaskBusiness ToTaskBusiness(this Task model)
        {
            return new TaskBusiness
            {
                Description = model.Description,
                EndDate = model.EndDate,
                Intitule = model.Intitule,
                Section = (SectionEnumBusiness)model.Section,
                TaskId = model.TaskId,
                BoardId = model.BoardId,
                //Board = model.Board.ToBardBusiness()
            };
        }

        public static IEnumerable<TaskBusiness> ToTaskBusiness(this IEnumerable<Task> listModel) => listModel.Select(t => t.ToTaskBusiness());
        #endregion
    }
}
