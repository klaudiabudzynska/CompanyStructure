using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompanyStructure.Models;

namespace CompanyStructure.Controllers
{
    [Route("company/employee")]
    [ApiController]
    public class EmployeeItemsController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeeItemsController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            return _context.EmployeeItems != null ?
                        View(await _context.EmployeeItems.ToListAsync()) :
                        Problem("Entity set 'EmployeeContext.EmployeeItems'  is null.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(long? id)
        {
            if (id == null || _context.EmployeeItems == null)
            {
                return NotFound();
            }

            var employeeItem = await _context.EmployeeItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeItem == null)
            {
                return NotFound();
            }

            return View(employeeItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEmployee([Bind("Id,Name,Role")] EmployeeItem employeeItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeItem);
        }

        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEmployee(long id, [Bind("Id,Name,Role")] EmployeeItem employeeItem)
        {
            if (id != employeeItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeItemExists(employeeItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employeeItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(long? id)
        {
            if (id == null || _context.EmployeeItems == null)
            {
                return NotFound();
            }

            var employeeItem = await _context.EmployeeItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeItem == null)
            {
                return NotFound();
            }

            return View(employeeItem);
        }

        private bool EmployeeItemExists(long id)
        {
          return (_context.EmployeeItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
