using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNetCoreBox.Data;
using ApiNetCoreBox.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiNetCoreBox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StackController : ControllerBase
    {
        private readonly IRepository _repo;

        public StackController(IRepository repo)
        {
            _repo = repo;
        }

        // DELETE: api/Technical/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var stack = await _repo.GetStackById(id);
                if (stack != null)
                {
                    _repo.Delete(stack);

                    if (await _repo.SaveChangeAsync())
                        return Ok("Deletado com Sucesso");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest($"Não Deletado!");
        }
    }
}