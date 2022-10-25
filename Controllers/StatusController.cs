using Checkpoint03API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CidadeAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;
        private readonly ILogger<StatusController> _logger;

        public StatusController(IStatusRepository statusRepository, ILogger<StatusController> logger)
        {
            _statusRepository = statusRepository;
            _logger = logger;
        }

        [HttpGet]
        public JsonResult ListarStatus()
        {
            _logger.LogInformation("Listando todos os status");
            return new JsonResult(_statusRepository.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<Status> ObterCidade(int id)
        {
            Status status = _statusRepository.ObterPorId(id);

            if(status == null)
            {
                _logger.LogWarning($"Status com o id [{id}] não existe");
                return NotFound();
            }
            return Ok(status);
        }

        [HttpPost]
        public ActionResult<Status> Cadastrar(Status status)
        {
            _statusRepository.Cadastrar(status);

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<Status> Atualizar(int id, Status status)
        {
            Status statusExistente = _statusRepository.ObterPorId(id);

            if (statusExistente == null)
            {
                return NotFound();
            }

            status.Id = id;

            _statusRepository.Atualizar(status);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Status> Remover(int id)
        {
            Status status = _statusRepository.ObterPorId(id);

            if (status == null)
            {
                return NotFound();
            }

            _statusRepository.Remover(status);

            return Ok();
        }
    }
}
