var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Hello Niklas!");

var myName = "Pelle";
app.MapGet("/myName", () => $"My name is: {myName}!" );
app.MapPost("/myName/{newName}", (string newName) => myName = newName);

var names = new List<string>(){"Niklas", "Thilde", "Vidar"};

app.MapGet("/names", () => names);
app.MapPost("/names/{newName}", (string newName) => names.Add(newName));

var people = new Dictionary<Guid, Person>();

app.MapPost("/savePerson", (Person person) =>
{
    people.Add(Guid.NewGuid(), person);
});

app.MapGet("/getPeople", () => people);


app.Run();

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}