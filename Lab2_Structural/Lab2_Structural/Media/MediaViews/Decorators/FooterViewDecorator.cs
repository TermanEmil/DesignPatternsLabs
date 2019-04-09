using System;
namespace Lab2_Structural.Media.MediaViews.Decorators
{
    public class FooterViewDecorator : BaseMediaViewDecorator
    {
        public FooterViewDecorator(IMediaView wrappee) : base(wrappee)
        {
        }

        public override void Render(IMediaResource resource)
        {
            base.Render(resource);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("------------------     End of media");
            Console.ResetColor();
        }
    }
}
