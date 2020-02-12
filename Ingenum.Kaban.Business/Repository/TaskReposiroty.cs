using Ingenum.Kaban.Business.Converter;
using Ingenum.Kaban.Business.Models;
using Ingenum.Kaban.Business.Models.Enum;
using Ingenum.Kaban.Business.Models.Interface;
using Ingenum.Kanban.Data;
using Ingenum.Kanban.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingenum.Kaban.Business.Repository
{
    public class TaskReposiroty : IRepository<TaskBusiness>
    {
        private IngenumKanbanContext context = null;

        public TaskReposiroty(IngenumKanbanContext pcc)
        {
            this.context = pcc;
        }

        /// <summary>
        /// Add Task to the DB
        /// </summary>
        /// <param name="entity"></param>
        public bool Add(TaskBusiness entity)
        {
            try
            {
                // Get the board
                var board = this.context.Boards.FirstOrDefault(b => b.BoardId == entity.BoardId).ToBardBusiness();

                // If board is locked don't add entity to the DB
                if (!board.IsLocked)
                {
                    this.context.Tasks.Add(entity.ToTask());
                    this.context.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// Delete entity to the DB
        /// </summary>
        /// <param name="entity"></param>
        public bool Delete(TaskBusiness entity)
        {
            try
            {
                var task = this.context.Tasks.FirstOrDefault(t => t.TaskId == entity.TaskId);
                this.context.Remove(task);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return true;
            }
        }

        /// <summary>
        /// Get one task
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TaskBusiness Get(int id)
        {
            return this.context.Tasks.FirstOrDefault(t => t.TaskId == id).ToTaskBusiness();
        }

        /// <summary>
        /// Get all task to the board
        /// </summary>
        /// <param name="boardId">ID BOARD</param>
        /// <returns></returns>
        public IEnumerable<TaskBusiness> GetAllByBoard(int boardId)
        {
            return this.context.Tasks.Where(t => t.BoardId == boardId).ToTaskBusiness();
        }

        public IEnumerable<TaskBusiness> GetAll()
        {
            try
            {
                return this.context.Tasks.ToTaskBusiness();

            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Updtade entity to the DB
        /// </summary>
        /// <param name="entity"></param>
        public bool Update(TaskBusiness entity)
        {
            try
            {
                var task = this.context.Tasks.FirstOrDefault(t => t.TaskId == entity.TaskId);
                task.Description = entity.Description;
                task.EndDate = entity.EndDate;
                task.Intitule = entity.Intitule;
                task.Section = (SectionEnum)VerifySection(entity.Section, task.Section);
                this.context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        private SectionEnumBusiness VerifySection(SectionEnumBusiness section, SectionEnum dbTask)
        {
            if (dbTask == SectionEnum.TODO && section == SectionEnumBusiness.DOING)
                return section;
            if (dbTask == SectionEnum.DOING && section == SectionEnumBusiness.DONE)
                return section;

            return (SectionEnumBusiness)dbTask;
        }
    }
}
