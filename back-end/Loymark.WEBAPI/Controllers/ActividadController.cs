using AutoMapper;
using Loymark.Core.Entities;
using Loymark.Core.Interfaces;
using Loymark.WEBAPI.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Loymark.WEBAPI.Controllers
{
    public class ActividadController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ActividadController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/<ActividadController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ActividadDto>>> Get()
        {
            var resultado = await _unitOfWork.Actividades.GetActividades();
            var listadoActividades = _mapper.Map<List<ActividadDto>>(resultado);
            return Ok(listadoActividades);
        }

        // GET api/<ActividadController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Actividad>> Get(int id)
        {
            var resultado = await _unitOfWork.Actividades.GetByIdUsuarioAsync(id);
            var listadoActividades = _mapper.Map<ActividadDto>(resultado);
            return Ok(listadoActividades);
        }
    }
}
