namespace BLL.Services.Base;

public interface ICrud<T, TDTO>
    where T : class
    where TDTO : class
{
    Task<T> GetAsync(int id);
    Task<List<T>> GetAllAsync();
    Task DeleteAsync(int id);
    Task<T> UpdateByIdAsync(int id, TDTO model);
    Task<T> AddAsync(TDTO model);
}
