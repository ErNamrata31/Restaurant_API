namespace RestaurantAPI.Services
{
    public interface IQRCodeService
    {
        byte[] GenerateQrCode(string url);
    }
}
