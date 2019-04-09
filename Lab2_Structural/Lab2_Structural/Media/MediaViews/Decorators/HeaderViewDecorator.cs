using System;
namespace Lab2_Structural.Media.MediaViews.Decorators
{
    public class HeaderViewDecorator : BaseMediaViewDecorator
    {
        public HeaderViewDecorator(IMediaView wrappee) : base(wrappee)
        {
        }

        public override void Render(IMediaResource resource)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("------------------     Start of media");
            Console.ResetColor();
            base.Render(resource);
        }
    }
}
