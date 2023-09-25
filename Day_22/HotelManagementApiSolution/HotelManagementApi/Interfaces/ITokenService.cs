namespace HotelManagementApi.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(string username,string role);
    }
}
