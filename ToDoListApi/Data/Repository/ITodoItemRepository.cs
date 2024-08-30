using ToDoListApi.Models;

namespace ToDoListApi.Data.Repository
{
    public interface ITodoItemRepository
    {
        Task AddTodoItem(TodoItem todoItem);
        Task DeleteTodoItem(int id);
        Task<TodoItem?> GetTodoItem(int id);
        Task<IEnumerable<TodoItem>> GetTodoItems();
        Task UpdateTodoItem(TodoItem todoItem);
    }
}
