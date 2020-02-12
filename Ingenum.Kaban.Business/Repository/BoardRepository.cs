using Ingenum.Kaban.Business.Converter;
using Ingenum.Kaban.Business.Models;
using Ingenum.Kaban.Business.Models.Interface;
using Ingenum.Kanban.Data;
using Ingenum.Kanban.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ingenum.Kaban.Business.Repository
{
    public class BoardRepository : IRepository<BoardBusiness>
    {
        private IngenumKanbanContext context = null;

        public BoardRepository(IngenumKanbanContext pcc)
        {
            context = pcc;
        }

        public bool Add(BoardBusiness entity)
        {
            try
            {
                entity.IsLocked = false;
                this.context.Boards.Add(entity.ToBoard());
                this.context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(BoardBusiness entity)
        {
            try
            {
                this.context.Remove(entity.ToBoard());
                this.context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public BoardBusiness Get(int id)
        {
            try
            {
                return this.context.Boards.Include(t => t.Tasks).FirstOrDefault(b => b.BoardId == id).ToBardBusiness();
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public IEnumerable<BoardBusiness> GetAll()
        {
            try
            {
                //var tmp = await this.context.Boards.ToListAsync();
                //var list = tmp.ToBoardBusiness();
                //return list;
                return this.context.Boards.ToBoardBusiness();
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public bool Update(BoardBusiness entity)
        {
            try
            {
                var task = this.context.Boards.FirstOrDefault(b => b.BoardId == entity.BoardId);
                task.BoardName = entity.BoardName;
                task.IsLocked = entity.IsLocked;
                task.Username = entity.Username;

                this.context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;

            }
        }
    }
}
