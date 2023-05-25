namespace Domain;

public class GroupMember
{
    public Guid Id { get; set; }

    public Guid GroupId { get; set; }

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }

    public GroupMember(Guid id, Guid groupId, Guid userId, DateTime start, DateTime end)
    {
        Id = id;
        GroupId = groupId;
        Start = start;
        End = end;
        UserId = userId;
    }

    public static GroupMember Create(Guid id, Guid groupId, Guid userId, DateTime start, DateTime end)
        => new(id, groupId, userId, start, end);
}
