using System;
namespace Lab2_Structural.Media.MediaResources
{
    public class MusicMediaResource : IMediaResource
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverPhoto { get; set; }
    }
}
