namespace EventMaker.Services.Interfaces
{
public interface IImageConverter
{
    byte[] ConvertFormFileToByte(IFormFile image);
}
}
