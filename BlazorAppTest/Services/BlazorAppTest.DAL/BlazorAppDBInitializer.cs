using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlazorAppTest.DAL
{
    public class BlazorAppDBInitializer
    {
        private readonly BlazorAppDB _db;
        private readonly ILogger<BlazorAppDBInitializer> _Logger;

        public BlazorAppDBInitializer(BlazorAppDB db, ILogger<BlazorAppDBInitializer> Logger)
        {
            _db = db;
            _Logger = Logger;
        }

        public void Initialize()
        {
            using var logger_scope = _Logger.BeginScope("Инициализация БД");
            _Logger.LogInformation("Запуск процесса инициализации БД");

            var db = _db.Database;

            var migrations = db.GetPendingMigrations().ToArray();
            if (migrations.Length == 0)
                _Logger.LogInformation("БД находится в последней версии");
            else
            {
                _Logger.LogInformation("Выполняю миграции БД: [{0}]", string.Join(",", migrations));
                db.Migrate();
                _Logger.LogInformation("Миграции БД выполнены успешно");
            }

            var students = _db.Students;
            if (students.Any())
                _Logger.LogInformation("Студенты присутствуют в БД. Инициализация не требуется.");
            else
            {
                _Logger.LogInformation("В БД отсутствуют студенты. Добавляю...");
                students.AddRange(TestData.Students);
                _db.SaveChanges();
                _Logger.LogInformation("Студенты добавлены успешно");
            }
        }
    }
}