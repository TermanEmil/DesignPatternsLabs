using System;
using System.IO;

namespace Lab2_Structural.Media.MediaViews
{
    public class MediaViewLogger : IMediaView, IDisposable
    {
        private readonly IMediaView realView;
        private readonly string viewName;
        private readonly StreamWriter logFile;

        public MediaViewLogger(IMediaView realView, string viewName, string fileToLogTo)
        {
            this.realView = realView;
            this.viewName = viewName;
            this.logFile = new StreamWriter(fileToLogTo);
        }

        public void Dispose()
        {
            logFile.Close();
        }

        public void Render(IMediaResource resource)
        {
            realView.Render(resource);
            logFile.WriteLine($"[{viewName}]: Was rendered on {DateTime.Now.ToString("HH:mm:ss")}");
            logFile.Flush();
        }
    }
}
