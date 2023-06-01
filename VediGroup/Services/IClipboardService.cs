namespace VediGroup.Services
{
    public interface IClipboardService
    {
        Task CopyToClipboard(string text);
    }
}
