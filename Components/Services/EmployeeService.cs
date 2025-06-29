using Microsoft.EntityFrameworkCore;

public class EmployeeService
{
    private readonly HRBuddyContext _context;

    public NewHours newHours = new();

    public EmployeeService(HRBuddyContext context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetEmployeesAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task AddEmployeeAsync(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
    }

    public async Task AddHoursAsync(int employeeId, double hours)
    {
        var employee = await _context.Employees.FindAsync(employeeId);
        if (employee != null)
        {
            employee.Hours += hours;
            await _context.SaveChangesAsync();
        }
    }

    public async Task ModifyEmployeeAsync(Employee employee)
    {
        Employee existing = await _context.Employees.FindAsync(employee.EmployeeId);

        if (existing is not null)
        {
            existing.FirstName = employee.FirstName;
            existing.LastName = employee.LastName;
            existing.Address = employee.Address;
            existing.Payrate = employee.Payrate;
            existing.Hours = employee.Hours;

            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteEmployeeAsync(Employee employee)
    {
        Employee existing = await _context.Employees.FindAsync(employee.EmployeeId);

        if (existing is not null)
        {
            _context.Employees.Remove(existing);
            await _context.SaveChangesAsync();
        }
    }

    public async Task ModifyHoursAsync(Employee employee)
    {
        Employee existing = await _context.Employees.FindAsync(employee.EmployeeId);

        if (existing is not null)
        {
            existing.Hours = employee.Hours;
            await _context.SaveChangesAsync();
        }
    }

    public async Task ZeroizeHoursAsync(Employee employee)
    {
        Employee existing = await _context.Employees.FindAsync(employee.EmployeeId);

        if (existing is not null)
        {
            existing.Hours = 0.0;
            await _context.SaveChangesAsync();
        }
    }
}
public class NewHours
{
    public double hours { get; set; }
    public int employeeId { get; set; }
}
