using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkGroups.domain.Model;

/// <summary>
/// Связь между пользователем и группой с указанием роли
/// </summary>
public class UserGroup
{
    /// <summary>
    /// Идентификатор связи
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public required int UserId { get; set; }

    /// <summary>
    /// Навигейшен пользователя
    /// </summary>
    public virtual User? User { get; set; }

    /// <summary>
    /// Идентификатор группы
    /// </summary>
    public required int GroupId { get; set; }

    /// <summary>
    /// Навигейшен группы
    /// </summary>
    public virtual Group? Group { get; set; }

    /// <summary>
    /// Роль пользователя в группе
    /// </summary>
    public UserRole Role { get; set; }

    /// <summary>
    /// Перегрузка метода, возвращающего строковое представление объекта
    /// </summary>
    /// <returns>Строка с информацией о пользователе и его роли в группе</returns>
    public override string ToString() => $"{User?.ToString()} - {Role}";

    /// <summary>
    /// Роли пользователя в группе
    /// </summary>
    public enum UserRole
    {
        Administrator,
        Moderator,
        CoAuthor,
        Reader
    }
}
