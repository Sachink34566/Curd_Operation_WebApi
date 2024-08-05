using Microsoft.EntityFrameworkCore;

namespace Curd_Dot_Net_Api.Data
{
    public class EmployeeRes
    {
        public readonly DpappCon _Dpappcon;

        public EmployeeRes(DpappCon dpappcon)
        {
            _Dpappcon = dpappcon;
        }
        public async Task AddEmployee(Employee employee)
        {
            await _Dpappcon.Set<Employee>().AddAsync(employee);
            await _Dpappcon.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllEmployee()
        {
            return await _Dpappcon.Employees.ToListAsync();

        }

        public async Task<Employee> GetById(int id)
        {
            return await _Dpappcon.Employees.FindAsync(id);
        }

        public async Task UpdateEmployee(int id, Employee model)
        {
            var employeee = await _Dpappcon.Employees.FindAsync(id);
            if (employeee == null)
            {
                throw new Exception("Employee not found");
            }

            employeee.Name = model.Name;
            employeee.Email = model.Email;
            employeee.Phone = model.Phone;
            employeee.Age = model.Age;
            employeee.Salary = model.Salary;

            await _Dpappcon.SaveChangesAsync();
        }
        public async Task DeleteEmployee(int id)
        {
            var employeee=await _Dpappcon.Employees.FindAsync(id);
            if(employeee == null)
            {
                throw new Exception("Employee not fount");
            }
            _Dpappcon.Employees.Remove(employeee);
            await _Dpappcon.SaveChangesAsync();
        }
    }
}
