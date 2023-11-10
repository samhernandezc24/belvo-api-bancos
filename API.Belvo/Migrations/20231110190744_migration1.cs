﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Belvo.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    IdCuenta = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdExterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstitucionNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstitucionTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstitucionCodigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecoleccionFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CuentaNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaAgencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaNumero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaldoActual = table.Column<decimal>(type: "decimal(30,2)", nullable: false),
                    SaldoDisponible = table.Column<decimal>(type: "decimal(30,2)", nullable: false),
                    CuentaCategoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaMonedaCodigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoTarifaJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoPrincipal = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    PrestamoDiaCorte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoCorteFecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoRecoleccionFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrestamoTasaInteresNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoTasaInteresTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoTasaInteresValor = table.Column<decimal>(type: "decimal(30,2)", nullable: false),
                    PrestamoMontoContrato = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    PrestamoNumeroContrato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoContratoInicioFecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoContratoFinFecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoPagoMensual = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    PrestamoDiaPago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoUltimoPagoFecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoSaldoPendientePago = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    PrestamoPrincipalPendientePago = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    PrestamoNumeroCuotasTotal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoNumeroCuotasPendientes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoPagoSinInteres = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CreditoRecoleccionFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreditoLimite = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CreditoCorteFecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditoTasaInteres = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CreditoPagoMinimo = table.Column<decimal>(type: "decimal(30,2)", nullable: false),
                    CreditoPagoMensual = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CreditoUltimoPagoFecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditoProximoPagoFecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditoSaldoUltimoPeriodo = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CreditoPagoSinInteres = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CuentaTipoSaldo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaIdProductionBancario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaUltimoAccesoFecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CuentaIdentificacionInterna = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaIdentificacionPublicaNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaIdentificacionPublicaValor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FondosRecoleccionFecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FondosNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FondosTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FondosIdentificacionPublicaJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FondosSaldo = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    FondosPorcentaje = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CuentasPorCobrarActual = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CuentasPorCobrarDisponible = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CuentasPorCobrarAnticipado = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CuentasPorCobrarRecoleccionFecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdCreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.IdCuenta);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    IdLink = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdLinkBelvo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Institucion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModoAcceso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TasaActualizacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltimoAccesoFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdExterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreadoFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioInstitucion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlmacenamientoCredenciales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vencimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuscarRecursos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.IdLink);
                });

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    IdTransaccion = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdCuenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdExterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCuentaProductoBancario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecoleccionFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCategoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComercianteNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Monto = table.Column<decimal>(type: "decimal(30,2)", nullable: false),
                    Estatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Saldo = table.Column<decimal>(type: "decimal(30,2)", nullable: false),
                    MonedaCodigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorFecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContableFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdentificacionInterna = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarjetaCreditoRecoleccionFecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TarjetaCreditoFacturaNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarjetaCreditoFacturaEstatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarjetaCreditoFacturaMonto = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    TarjetaCreditoTotalFacturaAnterior = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.IdTransaccion);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Transacciones");
        }
    }
}