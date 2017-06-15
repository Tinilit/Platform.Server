namespace Platform.DataAccess.Entities
{
    public class UserCommunication : Entity
    {
        public int Id { get; set; }
        public string CommunicationType { get; set; }
        public bool OptIn { get; set; }
        public User User { get; set; }
    }
}
