using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkGroups.domain.Model;

// <summary>
/// Запись пользователя в группе
/// </summary>
public class UserPost
{
    /// <summary>
    /// Идентификатор записи
    /// </summary>
    [Key]
    public required int PostId { get; set; }

    /// <summary>
    /// Заголовок записи
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Описание записи
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Дата создания записи
    /// </summary>
    public DateTime CreationDate { get; set; }

    /// <summary>
    /// Автор записи
    /// </summary>
    public virtual User? Author { get; set; }

    /// <summary>
    /// Группа, к которой принадлежит запись
    /// </summary>
    public virtual Group? Group { get; set; }

    /// <summary>
    /// Перегрузка метода, возвращающего строковое представление объекта
    /// </summary>
    /// <returns>Заголовок записи</returns>
    public override string ToString() => Title ?? "Без заголовка";
}
