using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListApi.Controllers;
using ToDoListApi.Data.Repository;
using ToDoListApi.Models;
using Xunit;

namespace ToDoListApiTests
{
    public class TodoItemsControllerTests
    {
        private readonly Mock<ITodoItemRepository> _repositoryMock;
        private readonly TodoItemsController _controller;

        public TodoItemsControllerTests()
        {
            _repositoryMock = new Mock<ITodoItemRepository>();
            _controller = new TodoItemsController(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetTodoItems_ReturnsOkResult()
        {
            // Arrange
            var todoItems = new List<TodoItem>()
                {
                    new TodoItem { Id = 1, Title = "Task 1", Description = "description" },
                    new TodoItem { Id = 2, Title = "Task 2", Description = "description" }
                };
            _repositoryMock.Setup(repo => repo.GetTodoItems()).ReturnsAsync(todoItems);

            // Act
            var result = await _controller.GetTodoItems();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetTodoItems_ReturnsAllTodoItems()
        {
            // Arrange
            var todoItems = new List<TodoItem>()
                {
                    new TodoItem { Id = 1, Title = "Task 1", Description = "description" },
                    new TodoItem { Id = 2, Title = "Task 2", Description = "description" }
                };
            _repositoryMock.Setup(repo => repo.GetTodoItems()).ReturnsAsync(todoItems);

            // Act
            var result = await _controller.GetTodoItems() as OkObjectResult;
            var items = result.Value as List<TodoItem>;

            // Assert
            Assert.Equal(todoItems.Count, items.Count);
            Assert.Equal(todoItems, items);
        }

        [Fact]
        public async Task GetTodoItem_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var todoItem = new TodoItem { Id = 1, Title = "Task 1", Description = "description" };
            _repositoryMock.Setup(repo => repo.GetTodoItem(1)).ReturnsAsync(todoItem);

            // Act
            var result = await _controller.GetTodoItem(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetTodoItem_WithValidId_ReturnsTodoItem()
        {
            // Arrange
            var todoItem = new TodoItem { Id = 1, Title = "Task 1", Description = "description" };
            _repositoryMock.Setup(repo => repo.GetTodoItem(1)).ReturnsAsync(todoItem);

            // Act
            var result = await _controller.GetTodoItem(1) as OkObjectResult;
            var item = result.Value as TodoItem;

            // Assert
            Assert.Equal(todoItem.Id, item.Id);
            Assert.Equal(todoItem.Title, item.Title);
            Assert.Equal(todoItem.Description, item.Description);
        }

        [Fact]
        public async Task GetTodoItem_WithInvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            _repositoryMock.Setup(repo => repo.GetTodoItem(1)).ReturnsAsync((TodoItem)null);

            // Act
            var result = await _controller.GetTodoItem(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task PostTodoItem_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var todoItem = new TodoItem { Id = 1, Title = "Task 1", Description = "description" };

            // Act
            var result = await _controller.PostTodoItem(todoItem);

            // Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public async Task PostTodoItem_ReturnsTodoItem()
        {
            // Arrange
            var todoItem = new TodoItem { Id = 1, Title = "Task 1", Description = "description" };

            // Act
            var result = await _controller.PostTodoItem(todoItem) as CreatedAtActionResult;
            var item = result.Value as TodoItem;

            // Assert
            Assert.Equal(todoItem.Id, item.Id);
            Assert.Equal(todoItem.Title, item.Title);
            Assert.Equal(todoItem.Description, item.Description);
        }

        [Fact]
        public async Task PutTodoItem_ReturnsNoContentResult()
        {
            // Arrange
            var todoItem = new TodoItem { Id = 1, Title = "Task 1", Description = "description" };

            // Act
            var result = await _controller.PutTodoItem(1, todoItem);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteTodoItem_WithValidId_ReturnsNoContentResult()
        {
            // Arrange
            var todoItem = new TodoItem { Id = 1, Title = "Task 1", Description = "description" };
            _repositoryMock.Setup(repo => repo.GetTodoItem(1)).ReturnsAsync(todoItem);

            // Act
            var result = await _controller.DeleteTodoItem(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteTodoItem_WithInvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            _repositoryMock.Setup(repo => repo.GetTodoItem(1)).ReturnsAsync((TodoItem)null);

            // Act
            var result = await _controller.DeleteTodoItem(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
