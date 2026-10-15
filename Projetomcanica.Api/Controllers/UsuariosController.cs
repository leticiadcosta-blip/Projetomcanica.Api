using Microsoft.AspNetCore.Mvc;
using projetomecanica.API.Data;
using Projetomecanica.Api.Models;



namespace projetomecanica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;

        }

        

    }
}