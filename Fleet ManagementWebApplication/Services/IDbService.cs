namespace Fleet_ManagementWebApplication.Services
{
    public interface IDbService
    {
        Task<T> GetAsync<T>(string command, object parms);
        Task<IEnumerable<T>> GetAll<T>(string command);
        Task<IEnumerable<T>> GetAll<T>(string command, object parms);
        Task<int> EditData(string command, object parms);
    }
}
