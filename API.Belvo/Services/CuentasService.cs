using System.Security.Claims;
using API.Belvo.Models;
using API.Belvo.Persistence;
using AutoMapper;
using Workcube.Interfaces;

namespace API.Belvo.Services
{
    public class CuentasService : IGlobal<Cuenta>
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public CuentasService(Context context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public Task Create(dynamic data, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        public async Task Create(dynamic data)
        {
            var objTransaction = _context.Database.BeginTransaction();

            Cuenta objModel = new Cuenta();

            objModel.IdCuenta = Guid.NewGuid().ToString();
        }

        public Task<dynamic> DataSource(dynamic data, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        public Task Delete(dynamic data, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        public Task<Cuenta> Find(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Cuenta> FindSelectorById(string id, string fields)
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