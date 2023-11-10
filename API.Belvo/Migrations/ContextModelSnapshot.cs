﻿// <auto-generated />
using System;
using API.Belvo.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Belvo.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Belvo.Models.Cuenta", b =>
                {
                    b.Property<string>("IdCuenta")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreadoFecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreditoCorteFecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("CreditoLimite")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<decimal?>("CreditoPagoMensual")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<decimal>("CreditoPagoMinimo")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<decimal?>("CreditoPagoSinInteres")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<string>("CreditoProximoPagoFecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreditoRecoleccionFecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("CreditoSaldoUltimoPeriodo")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<decimal?>("CreditoTasaInteres")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<string>("CreditoUltimoPagoFecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CuentaAgencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CuentaCategoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CuentaIdProductionBancario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CuentaIdentificacionInterna")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CuentaIdentificacionPublicaNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CuentaIdentificacionPublicaValor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CuentaMonedaCodigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CuentaNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CuentaNumero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CuentaTipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CuentaTipoSaldo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CuentaUltimoAccesoFecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("CuentasPorCobrarActual")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<decimal?>("CuentasPorCobrarAnticipado")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<decimal?>("CuentasPorCobrarDisponible")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<DateTime?>("CuentasPorCobrarRecoleccionFecha")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("FondosIdentificacionPublicaJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FondosNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("FondosPorcentaje")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<DateTime?>("FondosRecoleccionFecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("FondosSaldo")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<string>("FondosTipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdCreatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdExterno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstitucionCodigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstitucionNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstitucionTipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrestamoContratoFinFecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrestamoContratoInicioFecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrestamoCorteFecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrestamoDiaCorte")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrestamoDiaPago")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PrestamoMontoContrato")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<string>("PrestamoNumeroContrato")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrestamoNumeroCuotasPendientes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrestamoNumeroCuotasTotal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PrestamoPagoMensual")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<decimal?>("PrestamoPagoSinInteres")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<decimal?>("PrestamoPrincipal")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<decimal?>("PrestamoPrincipalPendientePago")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<DateTime>("PrestamoRecoleccionFecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("PrestamoSaldoPendientePago")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<string>("PrestamoTarifaJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrestamoTasaInteresNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrestamoTasaInteresTipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrestamoTasaInteresValor")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<string>("PrestamoTipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrestamoUltimoPagoFecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RecoleccionFecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("SaldoActual")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<decimal>("SaldoDisponible")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<DateTime>("UpdatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCuenta");

                    b.ToTable("Cuentas");
                });

            modelBuilder.Entity("API.Belvo.Models.Link", b =>
                {
                    b.Property<string>("IdLink")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AlmacenamientoCredenciales")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BuscarRecursos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreadoFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Estatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdCreatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdExterno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdLinkBelvo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUsuarioInstitucion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Institucion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModoAcceso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TasaActualizacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UltimoAccesoFecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vencimiento")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdLink");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("API.Belvo.Models.Transaccion", b =>
                {
                    b.Property<string>("IdTransaccion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ComercianteNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ContableFecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreadoFecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdCreatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdCuenta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdCuentaProductoBancario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdExterno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentificacionInterna")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MonedaCodigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RecoleccionFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<string>("SubCategoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TarjetaCreditoFacturaEstatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TarjetaCreditoFacturaMonto")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<string>("TarjetaCreditoFacturaNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TarjetaCreditoRecoleccionFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("TarjetaCreditoTotalFacturaAnterior")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValorFecha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTransaccion");

                    b.ToTable("Transacciones");
                });
#pragma warning restore 612, 618
        }
    }
}
