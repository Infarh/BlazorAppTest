using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BlazorAppTest.Domain.Entities;

namespace BlazorAppTest.Interfaces
{
    public interface IStudentStore
    {
        IAsyncEnumerable<Student> Get(CancellationToken Cancel = default);

        Task<Student> Get(int Id, CancellationToken Cancel = default);

        Task<Student> Get(string Surname, string Name, string Patronymic = null, CancellationToken Cancel = default);

        Task<int> Add(Student student, CancellationToken Cancel = default);

        Task<bool> Update(Student student, CancellationToken Cancel = default);

        Task<bool> Delete(int Id, CancellationToken Cancel = default);
    }
}
