

using EventMaker.Services.Interfaces;

namespace EventMaker.Services
{
    public class ImageConverter : IImageConverter
    {
        public byte[] ConvertFormFileToByte(IFormFile image)
        {
            byte[] imageData = null;

            using (var binaryReader = new BinaryReader(image.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)image.Length);
            }

            return imageData;
        }
    }
}
