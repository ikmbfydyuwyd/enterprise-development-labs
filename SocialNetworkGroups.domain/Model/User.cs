using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkGroups.domain.Model;

/// <summary>
/// Пользователь
/// </summary>

public class User
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    [Key]
    public required int UserId { get; set; }

    /// <summary>
    /// Фамилия пользователя
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// Отчество пользователя
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// Пол пользователя
    /// </summary>
    public string? Gender { get; set; }

    /// <summary>
    /// Дата рождения пользователя
    /// </summary>
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Дата регистрации пользователя
    /// </summary>
    public DateTime RegistrationDate { get; set; }

    /// <summary>
    /// Список групп, в которых участвует пользователь
    /// </summary>
    public virtual List<UserGroup>? UserGroups { get; set; }

    /// <summary>
    /// Число групп
    /// </summary>
    public int? GroupCount => UserGroups?.Count;

    /// <summary>
    /// Перегрузка метода, возвращающего строковое представление объекта
    /// </summary>
    /// <returns>ФИО пользователя</returns>
    public override string ToString() =>
        string.IsNullOrEmpty(Patronymic)
            ? $"{FirstName} {LastName}"
            : $"{LastName} {FirstName} {Patronymic}";
}

