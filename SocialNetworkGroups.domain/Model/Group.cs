using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkGroups.domain.Model;

/// <summary>
/// Группа
/// </summary>
public class Group
{
    /// <summary>
    /// Идентификатор группы
    /// </summary>
    [Key]
    public required int GroupId { get; set; }

    /// <summary>
    /// Название группы
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Описание группы
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Дата создания группы
    /// </summary>
    public DateTime CreationDate { get; set; }

    /// <summary>
    /// Автор группы
    /// </summary>
    public virtual User? Author { get; set; }

    /// <summary>
    /// Список записей пользователей в группе
    /// </summary>
    public virtual List<UserPost>? UserPosts { get; set; }

    /// <summary>
    /// Число записей
    /// </summary>
    public int? PostCount => UserPosts?.Count;

    /// <summary>
    /// Перегрузка метода, возвращающего строковое представление объекта
    /// </summary>
    /// <returns>Название группы</returns>
    public override string ToString() => Name ?? "Неизвестная группа";
}
