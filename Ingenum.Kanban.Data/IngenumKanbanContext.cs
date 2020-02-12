using Ingenum.Kanban.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ingenum.Kanban.Data
{
    public class IngenumKanbanContext : DbContext
    {
        public DbSet<Board> Boards { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public IngenumKanbanContext(DbContextOptions<IngenumKanbanContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasOne(b => b.Board)
                    .WithMany(t => t.Tasks)
                    .HasForeignKey(t => t.BoardId)
                    .HasConstraintName("FK_Tasks_Boards_BoardId");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
