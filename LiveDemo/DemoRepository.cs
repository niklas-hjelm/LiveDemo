namespace LiveDemo;

public class DemoRepository
{
    private readonly PersonContext _people;

    public DemoRepository(PersonContext storage)
    {
        _people = storage;
    }

    public async Task AddPerson(Person person)
    {
        await _people.People.AddAsync(person);
        await _people.SaveChangesAsync();
    }

    public IEnumerable<Person> GetAllPeople()
    {
        return _people.People;
    }

    public Person GetPerson(Guid id)
    {
        var exists = _people.People.FirstOrDefault(p => p.Id.Equals(id));
        if (exists is null)
        {
            return new Person();
        }

        return exists;
    }

    public void UpdateName(Guid id, string name)
    {
        var person = _people.People.FirstOrDefault(p => p.Id.Equals(id));
        person.Name = name;
        _people.SaveChanges();
    }

    public void UpdateAge(Guid id, int age)
    {
        var person = _people.People.FirstOrDefault(p => p.Id.Equals(id));
        person.Age = age;
        _people.SaveChanges();
    }

    public void DeletePerson(Guid id)
    {
        var person = _people.People.FirstOrDefault(p => p.Id.Equals(id));
        _people.People.Remove(person);
        _people.SaveChanges();
    }
}