using System.ComponentModel.DataAnnotations;

public class Person
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}