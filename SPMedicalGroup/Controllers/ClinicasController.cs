using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPMedicalGroup.DomainsContextDir;
using SPMedicalGroup.Interfaces;
using SPMedicalGroup.Repositories;

namespace SPMedicalGroup.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository ClinicaRepository {get; set;}

        public ClinicasController()
        {
            ClinicaRepository = new ClinicaRepository();
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Cadastrar(Clinica clinica)
        {
            try
            {
                ClinicaRepository.Cadastrar(clinica);
                return Ok(new { mensagem = "Clinica cadastrada com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro" + ex.Message });
                throw;
            }
        }
    }
}