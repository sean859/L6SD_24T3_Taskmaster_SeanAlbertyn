using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.MVVM.Models;

namespace Task.Service
{
    public class DatabaseService
    {
        SQLiteAsyncConnection db;

        public DatabaseService()
        {
            
        }

        async ValueTask Init()
        {
            if (db != null)
            {
                return;
            }

            SQLitePCL.Batteries_V2.Init();

            db = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);


            await db.CreateTableAsync<MyTask>();
            await db.CreateTableAsync<Category>();
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            await Init();
            return await db.Table<Category>().ToListAsync();
        }

        public async Task<List<MyTask>> GetTasksAsync()
        {
            await Init();
            return await db.Table<MyTask>().ToListAsync();
        }

        public async Task<int> SaveCategoryAsync(Category category)
        {
            await Init();

            if (category.Id != 0)
            {
                return await db.UpdateAsync(category);
            }
            else
            {
                return await db.InsertAsync(category);
            }
        }

        public async Task<int> SaveTaskAsync(MyTask task)
        {
            await Init();

            if (task.TaskId != 0)
            {
                return await db.UpdateAsync(task);
            }
            else
            {
                return await db.InsertAsync(task);
            }
        }

        public async Task<int> DeleteCategoryAsync(Category category)
        {
            await Init();
            return await db.DeleteAsync(category);
        }

        public async Task<int> DeleteCategoryAsync(MyTask task)
        {
            await Init();
            return await db.DeleteAsync(task);
        }
    }
}
