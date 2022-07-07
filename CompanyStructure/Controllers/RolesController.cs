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
    public class RolesController : ControllerBase
    {
        private readonly CompanyDBContext _context;
        private readonly IMapper _mapper;

        public RolesController(CompanyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleReadOnlyDto>>> GetRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            var rolesDtos = _mapper.Map<IEnumerable<RoleReadOnlyDto>>(roles);
            return Ok(rolesDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleReadOnlyDto>> GetRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            var roleDto = _mapper.Map<RoleReadOnlyDto>(role);

            return roleDto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, RoleUpdateDto roleDto)
        {
            if (id != roleDto.Id)
            {
                return BadRequest();
            }

            var role = await _context.Roles.FindAsync(id);

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
        public async Task<ActionResult<RoleCreateDto>> PostRole(RoleCreateDto roleDto)
        {

            var role = _mapper.Map<Role>(roleDto);
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRole), new { id = role.Id }, role);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoleExists(int id)
        {
            return (_context.Roles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
