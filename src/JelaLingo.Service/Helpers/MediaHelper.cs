namespace JelaLingo.Service.Helpers;

public class MediaHelper
{
    public static string IMAGE = "Images";
    public static string VIDEO = "Videos";

    public static string MakeImageName(string filename, string filePath)
    {
        FileInfo fileInfo = new FileInfo(filename);
        string extension = fileInfo.Extension;
        string name = "";
        if (filePath == IMAGE)
            name = "IMG_" + Guid.NewGuid() + extension;
        else if (filePath == VIDEO)
            name = "VIDEO_" + Guid.NewGuid() + extension;
        return name;
    }
    public static string[] GetImageExtensions()
    {
        return new string[]
        {
            ".jpg", ".jpeg", ".png"
        };
    }

    public static string[] GetVideoExtensions()
    {
        return new string[]
        {
            ".mp4", ".avi"
        };
    }
}
