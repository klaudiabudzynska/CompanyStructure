﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompanyStructure.Data;
using CompanyStructure.Models.Employee;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;

namespace CompanyStructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly CompanyDBContext _context;
        private readonly IMapper _mapper;

        public EmployeesController(CompanyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<EmployeeReadOnlyDto>>> GetEmployees()
        {
            var employeeDtos = await _context.Employees
                .Include(q => q.Role)
                .ProjectTo<EmployeeReadOnlyDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return Ok(employeeDtos);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<EmployeeReadOnlyDto>> GetEmployee(int id)
        {
            var employeeDto = await _context.Employees
                .Include(q => q.Role)
                .ProjectTo<EmployeeReadOnlyDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (employeeDto == null)
            {
                return NotFound();
            }

            return Ok(employeeDto);
        }

        [HttpGet("{id}/supervisor")]
        [Authorize]
        public async Task<ActionResult<EmployeeReadOnlyDto>> GetEmployeeSupervisor(int id)
        {
            var employeeDto = await _context.Employees
                .Include(q => q.Role)
                .ProjectTo<EmployeeReadOnlyDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (employeeDto == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(GetEmployee), new { id = employeeDto.SupervisorId });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditEmployee(int id, EmployeeUpdateDto employeeDto)
        {
            if (id != employeeDto.Id)
            {
                return BadRequest();
            }

            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            _mapper.Map(employeeDto, employee);
            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<EmployeeCreateDto>> CreateEmployee(EmployeeCreateDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
