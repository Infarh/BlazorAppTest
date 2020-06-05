using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlazorAppTest.DAL;
using BlazorAppTest.Domain.Entities;
using BlazorAppTest.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppTest.Services
{
    public class StudentsManager : IStudentManager
    {
        private readonly BlazorAppDB _db;

        public StudentsManager(BlazorAppDB db) => _db = db;

        public IAsyncEnumerable<Student> Get(CancellationToken Cancel = default) => _db.Students;

        public Task<Student> GetById(int Id, CancellationToken Cancel = default) => _db.Students.FirstOrDefaultAsync(s => s.Id == Id, Cancel);

        public Task<Student> GetByName(string Surname, string Name, string Patronymic = null, CancellationToken Cancel = default) =>
            string.IsNullOrEmpty(Patronymic)
                ? _db.Students.FirstOrDefaultAsync(s => s.Surname == Surname && s.Name == Name, Cancel)
                : _db.Students.FirstOrDefaultAsync(s => s.Surname == Surname && s.Name == Name && s.Patronymic == Patronymic, Cancel);

        public async Task<int> Add(Student student, CancellationToken Cancel = default)
        {
            await _db.Students.AddAsync(student, Cancel);
            await _db.SaveChangesAsync(Cancel);
            return student.Id;
        }

        public async Task<bool> Update(Student student, CancellationToken Cancel = default)
        {
            if (!await _db.Students.AnyAsync(s => s.Id == student.Id, Cancel)) return false;
            _db.Entry(student).State = EntityState.Modified;
            await _db.SaveChangesAsync(Cancel);
            return true;
        }

        public async Task<bool> Delete(int Id, CancellationToken Cancel = default)
        {
            var student = await _db.Students.Select(s => new Student {Id = s.Id}).FirstOrDefaultAsync(s => s.Id == Id, Cancel);
            if (student is null) return false;
            _db.Entry(student).State = EntityState.Deleted;
            return true;
        }
    }
}
