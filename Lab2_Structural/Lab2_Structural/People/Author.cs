namespace Lab2_Structural.People
{
    public class Author : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biografy { get; set; }
        public string ProfilePicture { get; set; }

        public Gender Gender { get; set; } = Gender.Male;
    }
}
