namespace CarRentalSystem.Domain.Common
{
    public abstract class Entity<TId>
        where TId : struct
    {
        public TId Id { get; private set; } = default;

        public override bool Equals(object? obj)
        {
            if (!(obj is Entity<TId> otherObj))
            {
                return false;
            }

            if (ReferenceEquals(this, otherObj))
            {
                return true;
            }

            if (this.GetType() != otherObj.GetType())
            {
                return false;
            }

            if (this.Id.Equals(default) || otherObj.Id.Equals(default))
            {
                return false;
            }

            return this.Id.Equals(otherObj.Id);
        }

        public static bool operator ==(Entity<TId> first, Entity<TId> second)
        {
            if (first is null && second is null)
            {
                return true;
            }

            if (first is null || second is null)
            {
                return false;
            }

            return first.Equals(second);
        }

        public static bool operator !=(Entity<TId> first, Entity<TId> second) => !(first == second);

        public override int GetHashCode() => (this.GetType().ToString() + this.Id).GetHashCode();
    }
}
