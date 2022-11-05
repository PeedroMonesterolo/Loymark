using AutoMapper;
using Loymark.Core.Entities;
using Loymark.Core.Interfaces;
using Loymark.WEBAPI.Controllers;
using Loymark.WEBAPI.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WEBAPI.Helpers.Errors;

namespace Loymark.WEBAPI
{
    public class UsuarioController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UsuarioController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/<UsuariosController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Usuario>>> Get()
        {
            var resultado = await _unitOfWork.Usuarios.GetAllAsync();
            return Ok(resultado);
        }

        // GET api/Usuarios/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UsuarioDto>> Get(int id)
        {
            var usuario = await _unitOfWork.Usuarios.GetByIdAsync(id);
            if (usuario == null)
                return NotFound(new ApiResponse(404, "El Usuario solicitado no existe"));

            return _mapper.Map<UsuarioDto>(usuario);
        }

        // POST api/Usuarios
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Usuario>> Post([FromBody] AddUsuarioDto usuarioDto)
        {
            var existeUsuario = _unitOfWork.Usuarios.ExistingUser(usuarioDto.Email).Result.ToList().Count;
            if (existeUsuario > 0)
                return NotFound(new ApiResponse(404, "El Email ya se encuentra registrado"));
            var usuario = _mapper.Map<Usuario>(usuarioDto);

            // GUARDO NUEVO USUARIO
            _unitOfWork.Usuarios.Add(usuario);
            await _unitOfWork.SaveAsync();
            if (usuario == null)
                return BadRequest(new ApiResponse(400));

            // GUARDO ACTIVIDAD DE NUEVO USUARIO
            _unitOfWork.Actividades.Add(new Actividad()
            {
                Actividad1 = "Creación de Usuario",
                IdUsuario = usuario.Id,
                CreateDate = DateTime.Now
            });
            await _unitOfWork.SaveAsync();

            return CreatedAtAction(nameof(Post), new { id = usuario.Id }, usuarioDto);
        }

        // PUT api/Usuarios/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AddUsuarioDto>> Put(int id, [FromBody] UsuarioDto usuarioDto)
        {
            if (usuarioDto == null)
                return NotFound(new ApiResponse(404, "El usuario solicitado no existe"));

            // Valido si existe el usuario en la base de datos
            var usuarioDb = await _unitOfWork.Usuarios.GetByIdAsync(id);
            if (usuarioDb == null)
                return NotFound(new ApiResponse(404, "El usuario solicitado no existe"));

            var usuario = _mapper.Map<Usuario>(usuarioDto);

            // ACTUALIZO USUARIO
            _unitOfWork.Usuarios.Update(usuario);
            await _unitOfWork.SaveAsync();
            if (usuario == null)
                return BadRequest(new ApiResponse(400));

            // GUARDO ACTIVIDAD DE NUEVO USUARIO
            _unitOfWork.Actividades.Add(new Actividad()
            {
                Actividad1 = "Actualización de Usuario",
                IdUsuario = usuario.Id,
                CreateDate = DateTime.Now
            });
            await _unitOfWork.SaveAsync();

            return CreatedAtAction(nameof(Post), new { id = usuario.Id }, usuarioDto);
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _unitOfWork.Usuarios.GetByIdAsync(id);
            if (usuario == null)
                return NotFound();

            var actividad = await _unitOfWork.Actividades.GetActividadesPorUsuario(usuario.Id);

            // Elimino actividades
            if (actividad != null)
            {
                _unitOfWork.Actividades.RemoveRange(actividad);
                await _unitOfWork.SaveAsync();
            }

            _unitOfWork.Usuarios.Remove(usuario);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
