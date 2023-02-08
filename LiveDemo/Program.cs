using LiveDemo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<DemoRepository>();
builder.Services.AddDbContext<PersonContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("PeopleDb");
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

app.MapPost("/savePerson", async (DemoRepository repo, Person person) =>
{
    await repo.AddPerson(person);
});

app.MapGet("/getPeople", (DemoRepository repo) => repo.GetAllPeople());

app.MapGet("/getPerson", (DemoRepository repo, Guid id) =>
{
    return repo.GetPerson(id);
});

app.MapPatch("/updateName", (DemoRepository repo, Guid id, string name) =>
{
    repo.UpdateName(id, name);
});

app.MapPatch("/updateAge", (DemoRepository repo, Guid id, int age) =>
{
    repo.UpdateAge(id, age);
});

app.MapDelete("/removePerson", (DemoRepository repo, Guid id) =>
{
    repo.DeletePerson(id);
});

app.Run();
