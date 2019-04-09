using Lab2_Structural.People;

namespace Lab2_Structural.Media.MediaResources
{
    public class PersonAdaptedToMediaResource : IMediaResource
    {
        private readonly IPerson _personAdaptee;

        public string Title => $"{_personAdaptee.FirstName} {_personAdaptee.LastName}";
        public string Description => _personAdaptee.Biografy;
        public string CoverPhoto => _personAdaptee.ProfilePicture;

        public PersonAdaptedToMediaResource(IPerson person)
        {
            _personAdaptee = person;
        }
    }
}
