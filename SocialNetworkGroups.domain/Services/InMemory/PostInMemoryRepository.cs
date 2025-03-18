using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkGroups.domain.Data;
using SocialNetworkGroups.domain.Model;

namespace SocialNetworkGroups.domain.Services.InMemory;
// <summary>
/// Имплементация репозитория для записей пользователей, которая хранит коллекцию в оперативной памяти 
/// </summary>
public class UserPostInMemoryRepository : IRepository<UserPost, int>
{
    public List<UserPost> userPosts;

    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    public UserPostInMemoryRepository()
    {
        userPosts = DataSeeder.UserPosts;
    }

    /// <inheritdoc/>
    public Task<UserPost> Add(UserPost entity)
    {
        try
        {
            userPosts.Add(entity);
        }
        catch
        {
            return null!;
        }
        return Task.FromResult(entity);
    }

    /// <inheritdoc/>
    public async Task<bool> Delete(int key)
    {
        try
        {
            var userPost = await Get(key);
            if (userPost != null)
                userPosts.Remove(userPost);
        }
        catch
        {
            return false;
        }
        return true;
    }

    /// <inheritdoc/>
    public Task<UserPost?> Get(int key) =>
        Task.FromResult(userPosts.FirstOrDefault(item => item.Id == key));

    /// <inheritdoc/>
    public Task<IList<UserPost>> GetAll() =>
        Task.FromResult((IList<UserPost>)userPosts);

    /// <inheritdoc/>
    public async Task<UserPost> Update(UserPost entity)
    {
        try
        {
            await Delete(entity.Id);
            await Add(entity);
        }
        catch
        {
            return null!;
        }
        return entity;
    }
}