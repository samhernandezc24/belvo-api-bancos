﻿using API.Belvo.Models;
using API.Belvo.ViewModels;
using API.Belvo.ViewModels.Reports;
using AutoMapper;

namespace API.Belvo.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            // MAPEO PARA DEVOLVER EL DATASOURCE_EXPRESSION
            #region
            CreateMap<Cuenta, CuentaViewModel>();
            #endregion

            // MAPEO PARA REPORTE
            #region
            CreateMap<CuentaViewModel, RepCuenta>();
            #endregion
        }
    }
}
