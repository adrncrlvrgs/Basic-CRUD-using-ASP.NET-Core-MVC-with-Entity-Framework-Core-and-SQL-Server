using BasicCrud_Vargas_Adrian.Data;
using BasicCrud_Vargas_Adrian.Models;
using BasicCrud_Vargas_Adrian.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud_Vargas_Adrian.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly BasicCrud _basicCrud;
        public EmployeesController(BasicCrud _basicCrud)
        {
            this._basicCrud = _basicCrud;
        }
        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var employees = await _basicCrud.Employees.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {

            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Lastname = addEmployeeRequest.Lastname,
                Firstname = addEmployeeRequest.Firstname,
                Middlename = addEmployeeRequest.Middlename,
                Gender = addEmployeeRequest.Gender,
                Age = addEmployeeRequest.Age,
                Email = addEmployeeRequest.Email,
                ContactNum = addEmployeeRequest.ContactNum,
                Address = addEmployeeRequest.Address

            };

            await _basicCrud.Employees.AddAsync(employee);
            await _basicCrud.SaveChangesAsync();
            return RedirectToAction("Add");

        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var employee = await _basicCrud.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee != null)
            {
                var viewModel = new UpdateEmployeeViewModel()
                {
                    Id = employee.Id,
                    Lastname = employee.Lastname,
                    Firstname = employee.Firstname,
                    Middlename = employee.Middlename,
                    Gender = employee.Gender,
                    Age = employee.Age,
                    Email = employee.Email,
                    ContactNum = employee.ContactNum,
                    Address = employee.Address
                };

                return await Task.Run(() => View("View", viewModel));
            }


            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateEmployeeViewModel viewModel)
        {

            var employee = await _basicCrud.Employees.FindAsync(viewModel.Id);

            if (employee != null)
            {
                employee.Firstname = viewModel.Firstname;
                employee.Middlename = viewModel.Middlename;
                employee.Lastname = viewModel.Lastname;
                employee.Gender = viewModel.Gender;
                employee.Age = viewModel.Age;
                employee.Email = viewModel.Email;
                employee.ContactNum = viewModel.ContactNum;
                employee.Address = viewModel.Address;

                await _basicCrud.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployeeViewModel viewModel)
        {
            var employee = await _basicCrud.Employees.FindAsync(viewModel.Id);

            if (employee != null)
            {
                _basicCrud.Employees.Remove(employee);
                await _basicCrud.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
