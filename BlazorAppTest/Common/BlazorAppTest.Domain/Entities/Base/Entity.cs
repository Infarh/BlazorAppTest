using System;
using System.Collections.Generic;
using System.Text;
using BlazorAppTest.Domain.Entities.Base.Interfaces;

namespace BlazorAppTest.Domain.Entities.Base
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
