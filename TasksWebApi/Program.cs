using TasksWebApi;
using TasksWebApi.Middlewares;
using TasksWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<TaskContext>(builder.Configuration.GetConnectionString("dbConnection"));
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITasksService, TasksService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseWelcomePage();

app.UseTimeMiddleware();

app.MapControllers();

app.Run();
