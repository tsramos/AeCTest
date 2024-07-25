using AecTest.Core.Contracts.Repository;
using AecTest.Core.Entities;
using AecTest.Service;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

public class AddressServiceTests
{
    private readonly Mock<IAddressRepository> _mockAddressRepository;
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly Mock<ILogger<AddressService>> _mockLogger;
    private readonly AddressService _addressService;

    public AddressServiceTests()
    {
        _mockAddressRepository = new Mock<IAddressRepository>();
        _mockUserRepository = new Mock<IUserRepository>();
        _mockLogger = new Mock<ILogger<AddressService>>();
        _addressService = new AddressService(
            _mockUserRepository.Object,
            _mockAddressRepository.Object,
            _mockLogger.Object
        );
    }

    [Fact]
    public async Task Create_ShouldCreateAddressAndLog()
    {
        // Arrange
        var endereco = new Endereco { Logradouro = "Rua Teste", Numero = "123", Bairro = "Bairro Teste", Cidade = "Cidade Teste", Uf = "UF" };
        var loginId = "userLoginId";
        var usuarioId = Guid.NewGuid();
        _mockUserRepository.Setup(repo => repo.FindByLoginIdAsync(loginId)).ReturnsAsync(usuarioId);
        _mockAddressRepository.Setup(repo => repo.Create(endereco)).Returns(Task.CompletedTask);

        // Act
        await _addressService.Create(endereco, loginId);

        // Assert
        _mockAddressRepository.Verify(repo => repo.Create(endereco), Times.Once);

        _mockLogger.Verify(
            logger => logger.Log(
                It.Is<LogLevel>(level => level == LogLevel.Information),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((state, _) => state.ToString()!.Contains($"Endereço criado com sucesso para o usuário {usuarioId}")),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception, string>>((state, exception) => true)
            ),
            Times.Once
        );
    }

    [Fact]
    public void Delete_ShouldDeleteAddressAndLog()
    {
        // Arrange
        var endereco = new Endereco { Id = Guid.NewGuid() };

        // Act
        _addressService.Delete(endereco);

        // Assert
        _mockAddressRepository.Verify(repo => repo.Delete(endereco), Times.Once);

        _mockLogger.Verify(
            logger => logger.Log(
                It.Is<LogLevel>(level => level == LogLevel.Information),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((state, _) => state.ToString()!.Contains("Endereço deletado com sucesso.")),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception, string>>((state, exception) => true)
            ),
            Times.Once
        );
    }

    [Fact]
    public async Task GetAll_ShouldReturnAllAddressesForUser()
    {
        // Arrange
        var loginId = "userLoginId";
        var usuarioId = Guid.NewGuid();
        var enderecos = new List<Endereco>
        {
            new Endereco { Logradouro = "Rua Teste", Numero = "123", Bairro = "Bairro Teste", Cidade = "Cidade Teste", Uf = "UF", UsuarioId = usuarioId }
        };
        _mockUserRepository.Setup(repo => repo.FindByLoginIdAsync(loginId)).ReturnsAsync(usuarioId);
        _mockAddressRepository.Setup(repo => repo.GetAll()).Returns(enderecos.AsQueryable());

        // Act
        var result = await _addressService.GetAll(loginId);

        // Assert
        Assert.Single(result);
        Assert.Equal(enderecos.First().Logradouro, result.First().Logradouro);       
        
    }

    [Fact]
    public async Task Update_ShouldUpdateAddressAndLog()
    {
        // Arrange
        var endereco = new Endereco { Id = Guid.NewGuid(), Logradouro = "Rua Atualizada" };
        _mockAddressRepository.Setup(repo => repo.UpdateAsync(endereco)).Returns(Task.CompletedTask);

        // Act
        await _addressService.Update(endereco);

        // Assert
        _mockAddressRepository.Verify(repo => repo.UpdateAsync(endereco), Times.Once);

        _mockLogger.Verify(
            logger => logger.Log(
                It.Is<LogLevel>(level => level == LogLevel.Information),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((state, _) => state.ToString()!.Contains($"Endereço atualizado com sucesso para o usuário {endereco.UsuarioId}")),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception, string>>((state, exception) => true)
            ),
            Times.Once
        );
    }

    [Fact]
    public async Task ExportCsv_ShouldReturnCorrectStream()
    {
        // Arrange
        var loginId = "userLoginId";
        var usuarioId = Guid.NewGuid();
        var enderecos = new List<Endereco>
    {
        new Endereco
        {
            Logradouro = "Rua Teste",
            Numero = "123",
            Complemento = "Complemento Teste",
            Bairro = "Bairro Teste",
            Cidade = "Cidade Teste",
            Uf = "UF",
            UsuarioId = usuarioId 
        }
    };

        _mockUserRepository.Setup(repo => repo.FindByLoginIdAsync(loginId)).ReturnsAsync(usuarioId);
        _mockAddressRepository.Setup(repo => repo.GetAll()).Returns(enderecos.AsQueryable());

        // Act
        var stream = await _addressService.ExportCsv(loginId);
                
        using (var reader = new StreamReader(stream))
        {
            var csvContent = await reader.ReadToEndAsync();
                    
            var expectedCsvContent = "Logradouro;Numero;Complemento;Bairro;Cidade;Estado\n" +
                                             "Rua Teste;123;Complemento Teste;Bairro Teste;Cidade Teste;UF";

            var normalizedCsvContent = csvContent.Replace("\r\n", "\n").Replace("\r", "\n");
            var normalizedExpectedCsvContent = expectedCsvContent.Replace("\r\n", "\n").Replace("\r", "\n");

            Assert.Equal(normalizedExpectedCsvContent, normalizedCsvContent.Trim());
        }
    }
}
