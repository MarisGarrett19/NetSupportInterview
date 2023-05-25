namespace Domain;

public class Group
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public List<GroupMember> Members { get; set; }

    private Group(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public static Group Create(Guid id, string name)
        => new(id, name);
}
