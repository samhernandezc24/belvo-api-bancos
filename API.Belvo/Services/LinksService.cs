using System.Security.Claims;
using API.Belvo.Models;
using API.Belvo.Persistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Workcube.Interfaces;

namespace API.Belvo.Services
{
    public class LinksService : IGlobal<Link>
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public LinksService(Context context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public Task Create(dynamic data, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> DataSource(dynamic data, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        public Task Delete(dynamic data, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        public Task<Link> Find(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Link> FindSelectorById(string id, string fields)
        {
            throw new NotImplementedException();
        }

        // Devuelve una lista de objetos dinámicos que representan los "Links".
        public async Task<List<dynamic>> List()
        {
            return await _context.Links.Where(x => !x.Deleted).Select(x => new { x.IdExterno, x.Institucion, x.LinkEstatus } ).ToListAsync<dynamic>();
        }

        public Task<byte[]> Reporte(dynamic data)
        {
            throw new NotImplementedException();
        }

        public Task Update(dynamic data, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }
    }
}