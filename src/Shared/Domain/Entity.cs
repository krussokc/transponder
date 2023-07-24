namespace Company.Domain
{
    public interface IEntity
    {
        long Id { get; set; }
    }

    public class Entity : IEntity
    {
        public Entity() { }

        public Entity(int id)
        {
            Id = id;
        }

        public long Id { get; set; } = default!;
    }
}