using System;
using System.Linq;

namespace Lab2_Structural.Media.MediaViews
{
    public class ShortFormView : IMediaView
    {
        private const int maxTitleSize = 16;
        private const int maxDescriptionSize = 40;

        public void Render(IMediaResource resource)
        {
            RenderTitle(resource.Title);
            RenderDescription(resource.Description);
        }

        private void RenderTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(TrimToLength(title, maxTitleSize));
            Console.ResetColor();
        }

        private void RenderDescription(string description)
        {
            Console.WriteLine(TrimToLength(description, maxDescriptionSize));
        }

        private string TrimToLength(string str, int maxLength)
        {
            string output;

            if (str.Length > maxLength)
                output = string.Join("", str.Take(maxLength)) + "...";
            else
                output = str;

            return output;
        }
    }
}
