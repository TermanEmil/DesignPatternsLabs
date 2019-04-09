using System;
using System.Collections.Generic;
using System.Linq;
using Lab2_Structural.Media;
using Lab2_Structural.Media.MediaResources;
using Lab2_Structural.Media.MediaViews;
using Lab2_Structural.Media.MediaViews.Decorators;
using Lab2_Structural.People;
using Lab2_Structural.People.Filters;

namespace Lab2_Structural
{
    public class TheMagicClass
    {
        public void Demonstrate()
        {
            var mediaResources = GenerateSomeMediaResources();

            DemonstrateLongMediaView(mediaResources);
            Console.WriteLine("----------");
            DemonstrateShortMediaView(mediaResources);
        }

        private IEnumerable<IMediaResource> GenerateSomeMediaResources()
        {
            var peopleMedia = CreateSomePeople().Select(x => new PersonAdaptedToMediaResource(x));

            var book = new BookMediaResource
            {
                Title = "Clean Architecture",
                Description =
                    "A very nice book written by Uncle Bob (aka Rober C. Martin) " +
                    "about how to correctly write code",
                CoverPhoto = "/a/picture/of/a/galaxy.jpg"
            };

            var music = new MusicMediaResource
            {
                Title = "Get Schwifty",
                Description = "Wubbalubbadubdub!",
                CoverPhoto = "/Kalaxian/Crystals.jpg"
            };

            var mediaResources = new List<IMediaResource>
            {
                book,
                music
            };

            mediaResources.AddRange(peopleMedia);
            return mediaResources;
        }

        private IEnumerable<IPerson> CreateSomePeople()
        {
            var emil = new Author
            {
                FirstName = "Emil",
                LastName = "Terman",
                Biografy = "A student that will hopefully get a 10 at this laboratory work",
                ProfilePicture = "/some/cool/profile/picture.jpg"
            };

            var aDown = new Author
            {
                FirstName = "Extra",
                LastName = "Chromosome",
                Biografy = "Bugh. Bugh!",
                ProfilePicture = "bugh.png",
                Gender = Gender.Helicopter
            };

            var aGay = new Author
            {
                FirstName = "J. K.",
                LastName = "Rowling",
                Biografy = "Wrote harry potter. Now, little by little, everyone is becomming gay.",
                ProfilePicture = "/pic/of/harry/potter.png",
                Gender = Gender.Female
            };

            var people = new List<IPerson>
            {
                emil,
                aDown,
                aGay
            };

            var maleFilter = new GenderFilter(Gender.Male);
            return maleFilter.Filter(people);
        }

        private void DemonstrateLongMediaView(IEnumerable<IMediaResource> mediaResources)
        {
            var view = new HeaderViewDecorator(
                new FooterViewDecorator(
                    new LongFormView()));

            Console.WriteLine("Long form");
            foreach (var media in mediaResources)
            {
                view.Render(media);
                Console.WriteLine("\n\n");
            }
        }

        private void DemonstrateShortMediaView(IEnumerable<IMediaResource> mediaResources)
        {
            IMediaView view;

            view = new HeaderViewDecorator(new ShortFormView());
            view = new MediaViewLogger(view, "Short media view", "short_media_logs.txt");

            Console.WriteLine("Short form");
            foreach (var media in mediaResources)
            {
                view.Render(media);
                Console.WriteLine("\n\n");
            }
        }
    }
}
