using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Belvo.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    CuentaCollectedFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CuentaCreatedFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CuentaCategoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaSaldoTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaAgencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaNumero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaldoActual = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    SaldoDisponible = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CuentaMonedaCodigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaIdentificacionPublicaNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaIdentificacionPublicaValor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaLastAccessedFecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreditoLimite = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CreditoCollectedFecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreditoCuttingFecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditoNextPaymentFecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditoPagoMinimo = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CreditoSinPagoIntereses = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CreditoTasaInteres = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CreditoPagoMensual = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CreditoLastPaymentFecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditoUltimoPeriodoSaldo = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    PrestamoCollectedFecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrestamoImporteContrato = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    PrestamoPrincipal = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    PrestamoTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoDiaPago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoPrincipalPendientePago = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    PrestamoSaldoPendientePago = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    PrestamoPagoMensual = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    PrestamoTasaInteresJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoTarifaJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoNumeroPlazosTotal = table.Column<int>(type: "int", nullable: true),
                    PrestamoNumeroPlazosPendientes = table.Column<int>(type: "int", nullable: true),
                    PrestamoContractStartFecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoContractEndFecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoNumeroContrato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoDiaCorte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoCuttingFecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoLastPaymentFecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestamoSinPagoIntereses = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    FondosCollectedFecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FondosNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FondosTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FondosIdentificacionPublicaJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FondosSaldo = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    FondosPorcentaje = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CuentasPorCobrarValorActual = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CuentasPorCobrarValorDisponible = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CuentasPorCobrarValorAnticipado = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    CuentasPorCobrarCollectedFecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdProductoBancario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaIdentificacionInterna = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Institucion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModoAcceso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkEstatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TasaActualizacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastAccessedFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdExterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkCreatedFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdInstitucionUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlmacenamientoCredenciales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vencimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFetchHistorical = table.Column<bool>(type: "bit", nullable: false),
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
                    IdExterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountingFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCuenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCuentaProductoBancario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Monto = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    Saldo = table.Column<decimal>(type: "decimal(30,2)", nullable: true),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollectedFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransaccionCreatedFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MonedaCodigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificacionInterna = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransaccionEstatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCategoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValueFecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComercianteNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarjetaCreditoCuentaNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarjetaCreditoTotalCuentaAnterior = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarjetaCreditoCollectedFecha = table.Column<DateTime>(type: "datetime2", nullable: true),
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
