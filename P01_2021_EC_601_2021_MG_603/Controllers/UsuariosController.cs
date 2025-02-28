using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using P01_2021_EC_601_2021_MG_603.Models; 

namespace P01_2021_EC_601_2021_MG_603.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly parqueoContext _context;

        public UsuarioController(parqueoContext context)
        {
            _context = context;
        }


        // Registrar un nuevo usuario
        [HttpPost("registrar")]
        public IActionResult RegistrarUsuario([FromBody] Usuario usuario)
        {
            if (_context.Usuarios.Any(u => u.Correo == usuario.Correo))
            {
                return BadRequest("El correo ya está registrado.");
            }

            usuario.Contrasena = EncriptarContrasena(usuario.Contrasena);
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return Ok(new { mensaje = "Usuario registrado correctamente." });
        }

        // Validar credenciales de usuario
        [HttpPost("validar")]
        public IActionResult ValidarCredenciales([FromBody] Credenciales credenciales)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Correo == credenciales.Correo);

            if (usuario == null || !VerificarContrasena(credenciales.Contrasena, usuario.Contrasena))
            {
                return Unauthorized("Credenciales inválidas.");
            }

            return Ok(new { mensaje = "Credenciales válidas.", usuarioId = usuario.UsuarioId });
        }

        // Obtener todos los usuarios
        [HttpGet]
        public IActionResult ObtenerUsuarios()
        {
            var usuarios = _context.Usuarios.ToList();
            return Ok(usuarios);
        }

        // Método para encriptar la contraseña
        private string EncriptarContrasena(string contrasena)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(contrasena));
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        // Verificar la contraseña
        private bool VerificarContrasena(string contrasenaIngresada, string contrasenaEncriptada)
        {
            string contrasenaIngresadaEncriptada = EncriptarContrasena(contrasenaIngresada);
            return contrasenaIngresadaEncriptada == contrasenaEncriptada;
        }
    }
}
