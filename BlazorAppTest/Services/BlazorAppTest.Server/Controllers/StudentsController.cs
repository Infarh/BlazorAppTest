using System.Linq;
using System.Threading.Tasks;
using BlazorAppTest.Domain.Entities;
using BlazorAppTest.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlazorAppTest.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentStore _StudentStore;
        private readonly ILogger<StudentsController> _Logger;

        public StudentsController(IStudentStore StudentStore, ILogger<StudentsController> Logger)
        {
            _StudentStore = StudentStore;
            _Logger = Logger;
        }

        [HttpGet]
        public async Task<ActionResult<Student[]>> Get()
        {
            _Logger.LogInformation("Запрос всех студентов");
            return await _StudentStore.Get().ToArrayAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Student>> Get(int Id)
        {
            _Logger.LogInformation("Запрос студента с идентификатором {0}", Id);
            var student = await _StudentStore.Get(Id);
            if (student != null) return student;
            _Logger.LogInformation("Студент с id:{0} не найден", Id);
            return NotFound();
        }

        [HttpGet("Surname:{Surname},Name:{Name}")]
        public async Task<ActionResult<Student>> Get(string Surname, string Name)
        {
            _Logger.LogInformation("Запрос студента Фамилия:{0} Имя:{1}", Surname, Name);
            var student = await _StudentStore.Get(Surname, Name);
            if (student != null) return student;
            _Logger.LogInformation("Студент с Фамилия:{0} Имя:{1} не найден", Surname, Name);
            return NotFound();
        }

        [HttpGet("Surname:{Surname},Name:{Name},Patronymic:{Patronymic}")]
        public async Task<ActionResult<Student>> Get(string Surname, string Name, string Patronymic)
        {
            _Logger.LogInformation("Запрос студента Фамилия:{0} Имя:{1} Отчество:{2}", Surname, Name, Patronymic);
            var student = await _StudentStore.Get(Surname, Name, Patronymic);
            if (student != null) return student;
            _Logger.LogInformation("Студент с Фамилия:{0} Имя:{1} Отчество:{2} не найден", Surname, Name, Patronymic);
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add([FromBody] Student Student)
        {
            _Logger.LogInformation("Добавление студента {0}", Student);
            var id = await _StudentStore.Add(Student);
            _Logger.LogInformation("Студент {0} добавлен", Student);
            return id;
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Update([FromBody] Student Student)
        {
            _Logger.LogInformation("Редактирование студента {0}", Student);
            var student_updated = await _StudentStore.Update(Student);
            _Logger.LogInformation("Редактирование студента {0} {1}", 
                Student, student_updated ? "выполнено успешно" : "не выполнено");

            return student_updated;
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<bool>> Delete(int Id)
        {
            _Logger.LogInformation("Удаление студента id:{0}", Id);
            var student_deleted = await _StudentStore.Delete(Id);
            _Logger.LogInformation("Удаление студента id:{0} {1}", Id, student_deleted ? "выполнено успешно" : "не выполнено");

            return student_deleted;
        }
    }
}
