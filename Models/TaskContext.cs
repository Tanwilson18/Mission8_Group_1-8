using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8_Group_1_8.Models
{
    public class TaskContext : DbContext
    {
        //constructor
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {

        }

        //Seeding Data
        public DbSet<TaskResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }
            );

            mb.Entity<TaskResponse>().HasData(

                new TaskResponse
                {
                    TaskId = 1,
                    Task = "Mission8",
                    DueDate = "Friday",
                    Quadrant = 2,
                    CategoryId = 2,
                    Completed = false,
                },
                new TaskResponse
                {
                    TaskId = 2,
                    Task = "IS404 Test",
                    DueDate = "Friday",
                    Quadrant = 1,
                    CategoryId = 2,
                    Completed = false,
                },
                new TaskResponse
                {
                    TaskId = 3,
                    Task = "Forecasting Assignment",
                    DueDate = "Friday",
                    Quadrant = 3,
                    CategoryId = 2,
                    Completed = false,
                },
                new TaskResponse
                {
                    TaskId = 4,
                    Task = "IS414 Test",
                    DueDate = "Thursday",
                    Quadrant = 4,
                    CategoryId = 2,
                    Completed = false,
                }
            );
        }
    }
}
