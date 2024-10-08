# ToDoListApi
### README.md for Todo List API

# Todo List API

This repository contains the source code for a simple Todo List API built with ASP.NET Core and Entity Framework Core, utilizing a MySQL database. The API allows users to manage todo items, including operations to create, read, update, and delete items. Each todo item includes properties for `title` and `description`.

## Features

- **Create Todo Items**: Add new items with a title and a description.
- **Read Todo Items**: Retrieve all todo items or a single item by its ID.
- **Update Todo Items**: Modify the details of an existing todo item.
- **Delete Todo Items**: Remove an existing todo item from the list.

## Setting Up the Development Environment

1. **Clone the repository**:

    ```bash
    git clone https://github.com/your-username/todo-list-api.git
    cd todo-list-api
    ```

2. **Setup the MySQL database**:

    - Ensure MySQL server is up and running.
    - Create a new MySQL database named `TodoListDb`.
    - Update the connection string in `appsettings.json` with your database credentials.

    ```json
    "ConnectionStrings": {
        "DefaultConnection": "server=localhost;database=TodoListDb;user=root;password=yourpassword;"
    }
    ```

3. **Apply EF Core migrations**:

    ```bash
    dotnet ef database update
    ```

    This command applies the migrations to your MySQL database and prepares it for use.

## Running the Application

1. **Navigate to the project directory** where `Program.cs` is located.

2. **Run the application**:

    ```bash
    dotnet run
    ```

    This command will start the API server.

## Q&A
### Was it easy to complete the task using AI? 
Yes.
### How long did task take you to complete?
Approximately 2 hours.
### Was the code ready to run after generation? What did you have to change to make it usable?
Most of the time the code was ready to run after generation, however i expierenced some problems with tests generation.
### Which challenges did you face during completion of the task?
There were no serious challanges.
### Which specific prompts you learned as a good practice to complete the task?
When using AI like GPT-4 for tasks such as coding and documentation, it's effective to provide specific, detailed prompts and context about the application. Additionally, breaking complex tasks into smaller subtasks and asking for examples where necessary can greatly enhance the quality and relevance of the outputs generated by the AI.

