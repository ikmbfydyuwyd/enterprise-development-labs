using SocialNetworkGroups.domain.Model;

namespace SocialNetworkGroups.domain.Services;
/// <summary>
/// Наследник обобщенного интерфейса для пользователей с дополнительной функциональностью 
/// </summary>

public interface IUserRepository : IRepository<User, int>
{
    /// <summary>
    /// Метод для вывода 5 пользователей с наибольшим количеством созданных записей за указанный период
    /// </summary>
    /// <param name="startDate">Дата начала периода</param>
    /// <param name="endDate">Дата окончания периода</param>
    /// <returns>Список кортежей с ФИО пользователя и числом записей</returns>
    Task<IList<Tuple<string, int>>> GetTop5UsersByPostCount(DateTime startDate, DateTime endDate);
}
