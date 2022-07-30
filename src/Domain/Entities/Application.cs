namespace Domain.Entities;

public class Application : BaseEntity
{
    private Application()
    {
        // required by EF
    }

    public Application(string name) : this()
    {
        Name = name;
    }

    public string Name { get; set; } = null!;
}
