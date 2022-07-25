namespace ApirestNet.Dtos
{
    // Objetos que transportan informacion
    public class CustomerDto
    {
        private long _id;
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
