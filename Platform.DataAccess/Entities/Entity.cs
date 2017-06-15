namespace Platform.DataAccess.Entities
{
    public abstract class Entity
    {
        public byte[] RowVersion { get; set; }
    }
}
