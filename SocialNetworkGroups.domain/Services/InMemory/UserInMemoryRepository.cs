using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkGroups.domain.Data;
using SocialNetworkGroups.domain.Model;


namespace SocialNetworkGroups.domain.Services.InMemory;
// <summary>
/// Имплементация репозитория для пользователей, которая хранит коллекцию в оперативной памяти 
/// </summary>
public class UserInMemoryRepository
{
    private List<User> users;
    private List<Group> groups;
    private List<UserPost> userPosts;
    private List<UserGroup> userGroups;

    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    public UserInMemoryRepository()
    {
        users = DataSeeder.Users;
        groups = DataSeeder.Groups;
        userPosts = DataSeeder.UserPosts;
        userGroups = DataSeeder.UserGroups;

        // Связываем записи с пользователями и группами
        foreach (var post in userPosts)
        {
            post.Author = users.FirstOrDefault(u => u.Id == post.Author.Id);
            post.Group = groups.FirstOrDefault(g => g.Id == post.Group.Id);
        }

        // Связываем пользователей с группами
        foreach (var userGroup in userGroups)
        {
            userGroup.User = users.FirstOrDefault(u => u.Id == userGroup.User.Id);
            userGroup.Group = groups.FirstOrDefault(g => g.Id == userGroup.Group.Id);
        }
    }

    /// <inheritdoc/>
    public Task<User> Add(User entity)
    {
        users.Add(entity);
        return Task.FromResult(entity);
    }

    /// <inheritdoc/>
    public async Task<bool> Delete(int key)
    {
        var user = await Get(key);
        if (user != null)
        {
            users.Remove(user);
            return true;
        }
        return false;
    }

    /// <inheritdoc/>
    public async Task<User> Update(User entity)
    {
        await Delete(entity.Id);
        await Add(entity);
        return entity;
    }

    /// <inheritdoc/>
    public Task<User?> Get(int key) =>
        Task.FromResult(users.FirstOrDefault(u => u.Id == key));

    /// <inheritdoc/>
    public Task<IList<User>> GetAll() =>
        Task.FromResult((IList<User>)users);

    /// <inheritdoc/>
    public async Task<IList<Tuple<string, int>>> GetTop5UsersByPostCount(DateTime startDate, DateTime endDate)
    {
        var topUsers = userPosts
            .Where(up => up.CreationDate >= startDate && up.CreationDate <= endDate)
            .GroupBy(up => up.Author)
            .Select(g => new
            {
                User = g.Key,
                PostCount = g.Count()
            })
            .OrderByDescending(x => x.PostCount)
            .Take(5)
            .ToList();

        return await Task.FromResult(topUsers
            .Select(u => new Tuple<string, int>(u.User.LastName, u.PostCount))
            .ToList());
    }
}
