using System.Security.Claims;
using API.Belvo.Models;
using API.Belvo.Persistence;
using AutoMapper;
using Workcube.Interfaces;

namespace API.Belvo.Services
{
    public class TransaccionesService : IGlobal<Transaccion>
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public TransaccionesService(Context context, IMapper mapper) 
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

        public Task<Transaccion> Find(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Transaccion> FindSelectorById(string id, string fields)
        {
            throw new NotImplementedException();
        }

        public Task<List<dynamic>> List()
        {
            throw new NotImplementedException();
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