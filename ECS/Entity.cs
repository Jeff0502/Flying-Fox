namespace FlyingFox.ECS
{
    public readonly struct Entity
    {
        // An id that shows which component relates to which "object"
        public readonly uint Id;

        public Entity(uint id) => Id = id;

        public static implicit operator Entity(uint id) => new Entity(id);

        public override int GetHashCode() => Id.GetHashCode();
    }
}