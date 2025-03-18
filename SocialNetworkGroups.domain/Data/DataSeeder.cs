using SocialNetworkGroups.domain.Model;

namespace SocialNetworkGroups.domain.Data;
/// <summary>
/// Класс для заполнения коллекций данными
/// </summary>
public static class DataSeeder
{
    /// <summary>
    /// Коллекция пользователей, использующаяся для первичного наполнения базы данных (и инмемори репозиториев)
    /// </summary>
    public static readonly List<User> Users =
        new()
        {
            new()
            {
                UserId = 1,
                FirstName = "Иван",
                LastName = "Иванов",
                Gender = "Мужской",
                DateOfBirth = new DateTime(1990, 1, 1),
                RegistrationDate = new DateTime(2023, 1, 1)
            },
            new()
            {
                UserId = 2,
                FirstName = "Мария",
                LastName =  "Петрова",
                Gender = "Женский",
                DateOfBirth = new DateTime(1992, 5, 15),
                RegistrationDate = new DateTime(2023, 2, 1)
            },
            new()
            {
                UserId = 3,
                FirstName = "Сергей",
                LastName =  "Сидоров",
                Gender = "Мужской",
                DateOfBirth = new DateTime(1988, 3, 20),
                RegistrationDate = new DateTime(2023, 3, 1)
            },
            new()
            {
                UserId = 4,
                FirstName = "Анна",
                LastName = "Сидорова",
                Gender = "Женский",
                DateOfBirth = new DateTime(1995, 7, 30),
                RegistrationDate = new DateTime(2023, 4, 1)
            },
            new()
            {
                UserId = 5,
                FirstName = "Дмитрий",
                LastName =  "Кузнецов",
                Gender = "Мужской",
                DateOfBirth = new DateTime(1985, 12, 10),
                RegistrationDate = new DateTime(2023, 5, 1)
            }
        };

    /// <summary>
    /// Коллекция групп, использующаяся для первичного наполнения базы данных (и инмемори репозиториев)
    /// </summary>
    public static readonly List<Group> Groups =
        new()
        {
            new()
            {
                GroupId = 1,
                Name = "Программисты",
                Description = "Группа для обсуждения программирования",
                CreationDate = new DateTime(2023, 1, 1),
                Author = Users[0] // Автор группы - Иван Иванов
            },
            new()
            {
                GroupId = 2,
                Name = "Дизайнеры",
                Description = "Группа для обсуждения дизайна",
                CreationDate = new DateTime(2023, 2, 1),
                Author = Users[1] // Автор группы - Мария Петрова
            },
            new()
            {
                GroupId = 3,
                Name = "Менеджеры",
                Description = "Группа для обсуждения управления проектами",
                CreationDate = new DateTime(2023, 3, 1),
                Author = Users[2] // Автор группы - Сергей Сидоров
            }
        };

    /// <summary>
    /// Коллекция записей пользователей, использующаяся для первичного наполнения базы данных (и инмемори репозиториев)
    /// </summary>
    public static readonly List<UserPost> UserPosts =
        new()
        {
            new()
            {
                PostId = 1,
                Title = "Первый пост о программировании",
                Description = "Описание первого поста",
                CreationDate = new DateTime(2023, 1, 10),
                Author = Users[0], // Автор поста - Иван Иванов
                Group = Groups[0] // Группа - Программисты
            },
            new()
            {
                PostId = 2,
                Title = "Первый пост о дизайне",
                Description = "Описание первого поста",
                CreationDate = new DateTime(2023, 2, 15),
                Author = Users[4], // Автор поста - Анна Сидорова
                Group = Groups[1] // Группа - Дизайнеры
            },
            new()
            {
                PostId = 3,
                Title = "Второй пост о программировании",
                Description = "Описание первого поста",
                CreationDate = new DateTime(2023, 3, 20),
                Author = Users[2], // Автор поста - Сергей Сидоров
                Group = Groups[2] // Группа - Менеджмент
            },
            new()
            {
                PostId = 2,
                Title = "Второй пост о дизайне",
                Description = "Описание второго поста",
                CreationDate = new DateTime(2023, 2, 16),
                Author = Users[4], // Автор поста - Анна Сидорова
                Group = Groups[1] // Группа - Дизайнеры
            },
            new()
            {
                PostId = 2,
                Title = "Третий пост о дизайне",
                Description = "Описание третьего поста",
                CreationDate = new DateTime(2023, 2, 17),
                Author = Users[4], // Автор поста - Анна Сидорова
                Group = Groups[1] // Группа - Дизайнеры
            }
        };
    /// <summary>
    /// Коллекция связей между пользователями и группами, использующаяся для первичного наполнения базы данных (и инмемори репозиториев)
    /// </summary>
    public static readonly List<UserGroup> UserGroups =
        new()
        {
            new()
            {
                UserId = 1,
                GroupId = 1,
                Id = 2,
                User = Users[4], // Анна Сидорова
                Group = Groups[1], // Дизайнеры
                Role = UserGroup.UserRole.Administrator, // Роль - Администратор
            },
            new()
            {
                UserId = 2,
                GroupId = 2,
                Id = 3,
                User = Users[2], // Сергей Сидоров
                Group = Groups[0], // Программисты
                Role = UserGroup.UserRole.CoAuthor // Роль - Соавтор
            },
            new()
            {
                UserId = 3,
                GroupId = 3,
                Id = 4,
                User = Users[4], // Анна Сидорова
                Group = Groups[1], // Дизайнеры
                Role = UserGroup.UserRole.Administrator // Роль - Администратор
            },
            new()
            {
                UserId = 4,
                GroupId = 4,
                Id = 5,
                User = Users[4], // Анна Сидорова
                Group = Groups[1], // Дизайнеры
                Role = UserGroup.UserRole.Administrator // Роль - Администратор
            },
            new()
            {
                UserId = 5,
                GroupId = 2,
                Id = 6,
                User = Users[4], // Анна Сидорова
                Group = Groups[1], // Дизайнеры
                Role = UserRole.Administrator // Роль - Администратор
            }
        };
}