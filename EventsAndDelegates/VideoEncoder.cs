using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class VideoEncoder
    {

        //1-Define a delegate
        //2-Define an event based on that delegate
        //3-Raise the event

        //Agreement between publisher and subscribers
        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);
        public event VideoEncodedEventHandler VideoEncoded;
        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video");
            Thread.Sleep(3000);
            OnVideoEncoded(video);
        }
        
        //This method is responsible of notifying all subscribers
        protected virtual void OnVideoEncoded(Video video)
        {
            if(VideoEncoded != null)
            {
                VideoEncoded(this, new VideoEventArgs() { Video = video});
            }
        }
    }
}
