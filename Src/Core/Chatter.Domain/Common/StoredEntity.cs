namespace Chatter.Domain.Common
{
    public abstract class StoredEntity<T>
    {
        public T Id { get; set; }
    }
}
