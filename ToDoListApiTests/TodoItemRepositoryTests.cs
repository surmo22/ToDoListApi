using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApi.Data;
using ToDoListApi.Data.Repository;
using ToDoListApi.Models;
using Xunit;

namespace ToDoListApiTests
{
    public class TodoItemRepositoryTests
    {
        private readonly Mock<TodoContext> _contextMock;
        private readonly TodoItemRepository _repository;
        private readonly Mock<DbSet<TodoItem>> _mockSet;

        public TodoItemRepositoryTests()
        {
            _contextMock = new Mock<TodoContext>();
            _mockSet = new Mock<DbSet<TodoItem>>();
            _repository = new TodoItemRepository(_contextMock.Object);
            _contextMock.Setup(m => m.TodoItems).Returns(_mockSet.Object);
        }

        [Fact]
        public async Task AddTodoItem_ShouldAddTodoItemToContext()
        {
            // Arrange
            var todoItem = new TodoItem { Id = 1, Title = "Task 1", Description = "description" };

            // Act
            await _repository.AddTodoItem(todoItem);

            // Assert
            _contextMock.Verify(c => c.TodoItems.Add(todoItem), Times.Once);
            _contextMock.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }

        [Fact]
        public async Task GetTodoItem_ReturnsItem()
        {
            // Arrange
            var todoItem = new TodoItem { Id = 1, Title = "Test Todo", Description = "xD"};
            _mockSet.Setup(m => m.FindAsync(1)).ReturnsAsync(todoItem);

            // Act
            var result = await _repository.GetTodoItem(1);

            // Assert
            Assert.Equal(todoItem, result);
        }

        [Fact]
        public async Task DeleteTodoItem_WithExistingId_ShouldRemoveTodoItemFromContext()
        {
            // Arrange
            var todoItem = new TodoItem { Id = 1, Title = "Task 1", Description = "description" };
            _contextMock.Setup(c => c.TodoItems.FindAsync(1)).ReturnsAsync(todoItem);

            // Act
            await _repository.DeleteTodoItem(1);

            // Assert
            _contextMock.Verify(c => c.TodoItems.Remove(todoItem), Times.Once);
            _contextMock.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }

        [Fact]
        public async Task DeleteTodoItem_WithNonExistingId_ShouldNotRemoveTodoItemFromContext()
        {
            // Arrange
            _contextMock.Setup(c => c.TodoItems.FindAsync(1)).ReturnsAsync((TodoItem)null);

            // Act
            await _repository.DeleteTodoItem(1);

            // Assert
            _contextMock.Verify(c => c.TodoItems.Remove(It.IsAny<TodoItem>()), Times.Never);
            _contextMock.Verify(c => c.SaveChangesAsync(default), Times.Never);
        }

        [Fact]
        public async Task GetTodoItem_WithExistingId_ShouldReturnTodoItem()
        {
            // Arrange
            var todoItem = new TodoItem { Id = 1, Title = "Task 1", Description = "description" };
            _contextMock.Setup(c => c.TodoItems.FindAsync(1)).ReturnsAsync(todoItem);

            // Act
            var result = await _repository.GetTodoItem(1);

            // Assert
            Assert.Equal(todoItem, result);
        }

        [Fact]
        public async Task GetTodoItem_WithNonExistingId_ShouldReturnNull()
        {
            // Arrange
            _contextMock.Setup(c => c.TodoItems.FindAsync(1)).ReturnsAsync((TodoItem)null);

            // Act
            var result = await _repository.GetTodoItem(1);

            // Assert
            Assert.Null(result);
        }
    }
}
