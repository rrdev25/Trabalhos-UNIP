using Xunit;
using SistemaChamados;

namespace SistemaChamados.Tests
{
    public class ChamadoTests
    {
        [Fact]
        public void Chamado_DeveInicializarComStatusAberto()
        {
            // Arrange
            string categoria = "Suporte Técnico";
            string descricao = "Erro ao iniciar o sistema";
            string anexo = "C:\\erros\\screenshot.png";

            // Act
            var chamado = new Chamado(categoria, descricao, anexo);

            // Assert
            Assert.Equal("Aberto", chamado.Status);
        }

        [Fact]
        public void Chamado_DeveArmazenarCorretamenteOsDados()
        {
            // Arrange
            string categoria = "Financeiro";
            string descricao = "Problema com nota fiscal";
            string anexo = "C:\\docs\\nota.pdf";

            // Act
            var chamado = new Chamado(categoria, descricao, anexo);

            // Assert
            Assert.Equal(categoria, chamado.Categoria);
            Assert.Equal(descricao, chamado.Descricao);
            Assert.Equal(anexo, chamado.Anexo);
        }
    }
}
