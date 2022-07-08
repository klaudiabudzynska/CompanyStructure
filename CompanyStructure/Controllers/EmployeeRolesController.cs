using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompanyStructure.Data;
using AutoMapper;
using CompanyStructure.Models.Role;

namespace CompanyStructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRolesController : ControllerBase
    {
        private readonly CompanyDBContext _context;
        private readonly IMapper _mapper;

        public EmployeeRolesController(CompanyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeRoleReadOnlyDto>>> GetEmployeeRoles()
        {
            var roles = await _context.EmployeeRoles.ToListAsync();
            var rolesDtos = _mapper.Map<IEnumerable<EmployeeRoleReadOnlyDto>>(roles);
            return Ok(rolesDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeRoleReadOnlyDto>> GetEmployeeRole(int id)
        {
            var role = await _context.EmployeeRoles.FindAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            var roleDto = _mapper.Map<EmployeeRoleReadOnlyDto>(role);

            return roleDto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditEmployeeRole(int id, EmployeeRoleUpdateDto roleDto)
        {
            if (id != roleDto.Id)
            {
                return BadRequest();
            }

            var role = await _context.EmployeeRoles.FindAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            _mapper.Map(roleDto, role);
            _context.Entry(role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
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
        public async Task<ActionResult<EmployeeRoleCreateDto>> CreateEmployeeRole(EmployeeRoleCreateDto roleDto)
        {

            var role = _mapper.Map<EmployeeRole>(roleDto);
            await _context.EmployeeRoles.AddAsync(role);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployeeRole), new { id = role.Id }, role);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeRole(int id)
        {
            var role = await _context.EmployeeRoles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            _context.EmployeeRoles.Remove(role);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoleExists(int id)
        {

            return (_context.EmployeeRoles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
