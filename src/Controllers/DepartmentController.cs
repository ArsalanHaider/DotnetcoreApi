using Api.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(DepartmentStatic.GetAllDepartments());
        }

        [HttpGet(template:"{code}")]
        public async Task<IActionResult> GetA(string code)
        {
            return Ok(DepartmentStatic.GetADepartments(code));
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Department department)
        {
            return Ok(DepartmentStatic.InsertDepartment(department));
        }

        [HttpPut(template: "{code}")]
        public async Task<IActionResult> Update(string code, Department department)
        {
            return Ok(DepartmentStatic.UpdateDepartments(code, department));
        }

        [HttpDelete(template: "{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            return Ok(DepartmentStatic.DeleteDepartments(code));
        }
    }

    public static class DepartmentStatic
    {

        private static List<Department> AllDepartments { get; set; } = new List<Department>();
        public static Department InsertDepartment(Department department)
        {
            AllDepartments.Add(department);
            return department;
        }

        public static List<Department> GetAllDepartments()
        {
            return AllDepartments;
        }

        public static Department GetADepartments(string code)
        {
            var Deparment  = AllDepartments.Where(x=>x.Code == code).FirstOrDefault();
            return Deparment;
        }
        public static Department UpdateDepartments(string code, Department department)
        {
            Department result = new Department();
            foreach (var item in AllDepartments)
            {
                if (code == item.Code)
                {
                    result.Name = department.Name;
                }
            }
            return result;
        }
        public static Department DeleteDepartments(string code)
        {
            var department = AllDepartments.FirstOrDefault(x => x.Code == code);
            AllDepartments = AllDepartments.Where(x => x.Code != department.Code).ToList();
            return department;
        }

    }
}
