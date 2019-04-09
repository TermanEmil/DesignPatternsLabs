using Lab2_Structural.People;

namespace Lab2_Structural.Media.MediaResources
{
    public class PersonAdaptedToMediaResource : IMediaResource
    {
        private readonly IPerson personAdaptee;

        public string Title => $"{personAdaptee.FirstName} {personAdaptee.LastName}";
        public string Description => personAdaptee.Biografy;
        public string CoverPhoto => personAdaptee.ProfilePicture;

        public PersonAdaptedToMediaResource(IPerson person)
        {
            personAdaptee = person;
        }
    }
}
