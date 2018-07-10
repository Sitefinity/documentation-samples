// Documentation articles: https://docs.sitefinity.com/use-custom-video-thumbnail-generation

using System.IO;
using Telerik.Sitefinity.Modules.Libraries.Videos.Thumbnails;

namespace SitefinityWebApp.NRecoVideoConvertor
{
    public class CustomVideoThumbnailGenerator : VideoThumbnailGenerator, IVideoThumbnailGenerator
    {
        public override System.Drawing.Image CreateHtml5VideoThumbnails(Telerik.Sitefinity.Libraries.Model.Video video, System.IO.FileInfo videoFile, string imageFilePath)
        {
            System.Drawing.Image thumbnail = null;
            var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
            float? frameTime = 10;
            ffMpeg.GetVideoThumbnail(videoFile.FullName, imageFilePath, frameTime);
            using (FileStream imageStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
            {
                thumbnail = System.Drawing.Image.FromStream(imageStream);
            }
            return thumbnail;
        }
    }
}