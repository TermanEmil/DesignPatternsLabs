namespace Lab2_Structural.Media.MediaViews.Decorators
{
    public abstract class BaseMediaViewDecorator : IMediaView
    {
        private readonly IMediaView wrappee;

        protected BaseMediaViewDecorator(IMediaView wrappee)
        {
            this.wrappee = wrappee;
        }

        public virtual void Render(IMediaResource resource)
        {
            wrappee.Render(resource);
        }
    }
}
