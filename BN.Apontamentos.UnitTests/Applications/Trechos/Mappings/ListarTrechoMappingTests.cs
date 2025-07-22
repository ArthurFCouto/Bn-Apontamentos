using BN.Apontamentos.Application.Trechos.Data;
using BN.Apontamentos.Application.Trechos.Mappings;
using BN.Apontamentos.Domain.Trechos.Entities;
using BN.Apontamentos.UnitTests.Extensions;
using FluentAssertions;
using Mapster;
using MapsterMapper;

namespace BN.Apontamentos.UnitTests.Applications.Trechos.Mappings
{
    public class ListarTrechoMappingTests
    {
        [Fact(DisplayName = "Deve mapear um objeto ListarTrechoEntity para ListarTrechoResponse corretamente")]
        public void ListarTrechoMapping_Mapping_Test()
        {
            // Arrange
            DateTime data = DateTime.Now;
            Mapper mapper = MapsterForUnitTests.GetMapper<ListarTrechoMapping>();
            ListarTrechoEntity entity = new()
            {
                Id_trecho = 1,
                No_circuito = 1,
                Nm_trecho = "DS01.C1.ITS2.EM1(R)",
                No_secao = 240,
                Nm_tag_bobina = "DS01-500-B1",
                Nm_origem = "DS01.ITS1",
                Id_origem = 1,
                Nm_destino = "DS01.ITS2",
                Id_destino = 2,
                Cd_fase = 'R',
                No_comprimento_fase = 270,
                Id_plano_de_corte = 1,
                No_comprimento_todas_fases = 810,
                Dt_data_inativacao = data,
            };

            ListarTrechoResponse expected = new()
            {
                IdTrecho = 1,
                Circuito = 1,
                IdPlanoDeCorte = 1,
                IdentificacaoCabo = "DS01.C1.ITS2.EM1(R)",
                Secao = 240,
                TagPrevisto = "DS01-500-B1",
                Origem = "DS01.ITS1",
                IdOrigem = 1,
                Destino = "DS01.ITS2",
                IdDestino = 2,
                Fase = 'R',
                ComprimentoFase = 270,
                ComprimentoTodasFases = 810,
                Ativo = false,
            };

            // Act
            ListarTrechoResponse response = TypeAdapter.Adapt<ListarTrechoResponse>(entity, mapper.Config);

            // Assert
            response.Should().BeEquivalentTo(expected);
        }
    }
}
