namespace SportInApp.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Sport { get; set; }  // فقط إذا كان الدور 'Player'
        public string ManagerEmail { get; set; }  // فقط إذا كان الدور 'Club'
    }
}
