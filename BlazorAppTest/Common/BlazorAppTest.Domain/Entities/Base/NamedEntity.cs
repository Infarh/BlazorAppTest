using System.ComponentModel.DataAnnotations;
using BlazorAppTest.Domain.Entities.Base.Interfaces;

namespace BlazorAppTest.Domain.Entities.Base
{
    public abstract class NamedEntity : Entity, INamedEntity
    {
        [Required]
        public string Name { get; set; }
    }
}