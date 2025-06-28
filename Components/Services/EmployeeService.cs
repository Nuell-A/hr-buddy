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
}
public class NewHours
{
    public double hours { get; set; }
    public int employeeId { get; set; }
}
