namespace Lab2_Structural.People
{
    public enum Gender
    {
        Male,
        Female,
        Helicopter
    }

    public interface IPerson
    {
        string FirstName { get; }
        string LastName { get; }
        string Biografy { get; }
        string ProfilePicture { get; set; }

        Gender Gender { get; }
    }
}
