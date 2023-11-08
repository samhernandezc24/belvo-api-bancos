﻿// <auto-generated />
using System;
using API.Belvo.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Belvo.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20231107054143_migration1")]
    partial class migration1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("CreatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreditoCollectedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreditoCuttingFecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreditoLastPaymentFecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("CreditoLimite")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<string>("CreditoNextPaymentFecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("CreditoPagoMensual")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<decimal?>("CreditoPagoMinimo")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<decimal?>("CreditoSinPagoIntereses")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<decimal?>("CreditoTasaInteres")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<decimal?>("CreditoUltimoPeriodoSaldo")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<string>("CuentaAgencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CuentaCategoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CuentaCollectedFecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CuentaCreatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("CuentaIdentificacionInterna")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CuentaIdentificacionPublicaNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CuentaIdentificacionPublicaValor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CuentaLastAccessedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("CuentaMonedaCodigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CuentaNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CuentaNumero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CuentaSaldoTipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CuentaTipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CuentasPorCobrarCollectedFecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("CuentasPorCobrarValorActual")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<decimal?>("CuentasPorCobrarValorAnticipado")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<decimal?>("CuentasPorCobrarValorDisponible")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FondosCollectedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("FondosIdentificacionPublicaJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FondosNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("FondosPorcentaje")
                        .HasColumnType("decimal(30, 2)");

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

                    b.Property<string>("IdProductoBancario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstitucionCodigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstitucionNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstitucionTipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PrestamoCollectedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("PrestamoContractEndFecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrestamoContractStartFecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrestamoCuttingFecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrestamoDiaCorte")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrestamoDiaPago")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PrestamoImporteContrato")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<string>("PrestamoLastPaymentFecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrestamoNumeroContrato")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PrestamoNumeroPlazosPendientes")
                        .HasColumnType("int");

                    b.Property<int?>("PrestamoNumeroPlazosTotal")
                        .HasColumnType("int");

                    b.Property<decimal?>("PrestamoPagoMensual")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<decimal?>("PrestamoPrincipal")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<decimal?>("PrestamoPrincipalPendientePago")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<decimal?>("PrestamoSaldoPendientePago")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<decimal?>("PrestamoSinPagoIntereses")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<string>("PrestamoTarifaJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrestamoTasaInteresJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrestamoTipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("SaldoActual")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<decimal?>("SaldoDisponible")
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

                    b.Property<string>("CreadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("IdCreatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdExternalBelvo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdExterno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdInstitucionUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Institucion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFetchHistorical")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastAccessedFecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LinkCreatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("LinkEstatusName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModoAcceso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TasaActualizacion")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<DateTime>("AccountingFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CollectedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("ComercianteNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdCreatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdCuenta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdCuentaProductoBancario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdExterno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentificacionInterna")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MonedaCodigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Monto")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Saldo")
                        .HasColumnType("decimal(30, 2)");

                    b.Property<string>("SubCategoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TarjetaCreditoCollectedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("TarjetaCreditoCuentaNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TarjetaCreditoTotalCuentaAnterior")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransaccionCreatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransaccionEstatusName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValueFecha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTransaccion");

                    b.ToTable("Transacciones");
                });
#pragma warning restore 612, 618
        }
    }
}