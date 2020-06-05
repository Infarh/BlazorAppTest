using System;
using BlazorAppTest.Domain.Entities.Base;

namespace BlazorAppTest.Domain.Entities
{
    public class Student : NamedEntity
    {
        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public DateTime Birthday { get; set; }
    }
}
