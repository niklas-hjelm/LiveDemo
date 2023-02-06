var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Hello Niklas!");

var myName = "Pelle";
app.MapGet("/myName", () => $"My name is: {myName}!" );
app.MapPost("/myName/{newName}", (string newName) => myName = newName);

var names = new List<string>(){"Niklas", "Thilde", "Vidar"};

app.MapGet("/names", () => names);
app.MapPost("/names/{newName}", (string newName) => names.Add(newName));


app.Run();
