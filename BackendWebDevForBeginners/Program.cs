using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// register the rewriter middleware
app.UseRewriter(new RewriteOptions().AddRedirect("tasks/(.*)", "todos/$1"));

// register custom middleware, which logs the start and end of each request
// the middleware will be executed in the order they are registered
app.Use(async (context, next) =>
{
    Console.WriteLine($"[{context.Request.Method}] {context.Request.Path} {DateTime.UtcNow} Started.");
    await next();
    Console.WriteLine($"[{context.Request.Method}] {context.Request.Path} {DateTime.UtcNow} Finished.");
});

// Endpoints ---------------------------------------------------------------------------------------
// Endpoints are processed by the routing middleware

var todos = new List<Todo>();

app.MapPost("/todos", (Todo task) =>
{
    todos.Add(task);
    return TypedResults.Created($"/todos/{task.Id}", task);
})
.AddEndpointFilter(async (context, next) =>
{
    var todoArgument = context.GetArgument<Todo>(0);
    var errors = new Dictionary<string, string[]>();
    if (todoArgument.DueDate < DateTime.UtcNow)
    {
        errors.Add(nameof(Todo.DueDate), ["Due date must be in the future."]);
    }
    if (todoArgument.IsComplete)
    {
        errors.Add(nameof(Todo.IsComplete), ["Cannot add completed todo."]);
    }
    if (errors.Count > 0)
    {
        return Results.ValidationProblem(errors);
    }
    return await next(context);
});

app.MapGet("/todos", (ITodoService todoService) => todos);

app.MapGet("/todos/{id}", Results<Ok<Todo>, NotFound> (int id) =>
{
    var targetTodo = todos.SingleOrDefault(t => t.Id == id);
    return targetTodo is null
        ? TypedResults.NotFound()
        : TypedResults.Ok(targetTodo);
});

app.MapDelete("/todos/{id}", Results<NoContent, NotFound> (int id) =>
{
    var targetTodo = todos.SingleOrDefault(t => t.Id == id);
    if (targetTodo is null)
    {
        return TypedResults.NotFound();
    }
    todos.Remove(targetTodo);
    return TypedResults.NoContent();
});

app.Run();

// Entities ----------------------------------------------------------------------------------------

public record Todo(int Id, string Name, DateTime DueDate, bool IsComplete);

interface ITodoService
{
    IEnumerable<Todo> GetTodos();
    Todo? GetTodoById(int id);
    Todo AddTodo(Todo todo);
    void DeleteTodoById(int id);
}

public class InMemoryTodoService : ITodoService
{
    private readonly List<Todo> _todos = [];

    public IEnumerable<Todo> GetTodos()
    {
        return _todos;
    }

    public Todo? GetTodoById(int id)
    {
        return _todos.SingleOrDefault(t => t.Id == id);
    }

    public Todo AddTodo(Todo todo)
    {
        _todos.Add(todo);
        return todo;
    }

    public void DeleteTodoById(int id)
    {
        var todo = _todos.SingleOrDefault(t => t.Id == id);
        if (todo is not null)
        {
            _todos.Remove(todo);
        }
    }
}
