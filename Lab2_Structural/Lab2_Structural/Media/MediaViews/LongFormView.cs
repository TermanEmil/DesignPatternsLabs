using System;

namespace Lab2_Structural.Media.MediaViews
{
    public class LongFormView : IMediaView
    {
        public void Render(IMediaResource resource)
        {
            RenderTitle(resource.Title);
            RenderImage(resource.CoverPhoto);
            RenderDescription(resource.Description);
        }

        private void RenderTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(title);
            Console.ResetColor();
        }

        private void RenderImage(string img)
        {
            Console.WriteLine(@"------------------ Img ------------------");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(img);
            Console.ResetColor();

            Console.WriteLine(@"-----------------------------------------");
        }

        private void RenderDescription(string description)
        {
            Console.WriteLine("Description:");
            Console.WriteLine($"\t{description}");
        }
    }
}
