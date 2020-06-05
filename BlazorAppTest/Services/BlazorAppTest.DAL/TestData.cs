using System;
using System.Collections.Generic;
using BlazorAppTest.Domain.Entities;

namespace BlazorAppTest.DAL
{
    internal static class TestData
    {
        public static IEnumerable<Student> Students { get; } = new[]
        {
            new Student
            {
                Surname = "Иванов", Name = "Иван", Patronymic = "Иванович", 
                Birthday = DateTime.Now.Subtract(TimeSpan.FromDays(365 * 20)),
            },
            new Student
            {
                Surname = "Петров", Name = "Пётр", Patronymic = "Петрович",
                Birthday = DateTime.Now.Subtract(TimeSpan.FromDays(365 * 20)),
            },
            new Student
            {
                Surname = "Сидоров", Name = "Сидор", Patronymic = "Сидорович",
                Birthday = DateTime.Now.Subtract(TimeSpan.FromDays(365 * 20)),
            },
        };
    }
}