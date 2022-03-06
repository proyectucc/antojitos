
using SupermercadoAntojitos.Entities.Api.Test.Helpers;
using SupermercadoAntojitos.Entitiess.Api;
using System;
using Xunit;

namespace SupermercadoAntojitos.Entities.Api.Test
{
    /// <summary>
    /// Pruebas unitarias realizadas a la entidad
    /// </summary>
    public class ClienteTest
    {
        /// <summary>
        /// Prueba encargada de validar que los datos ingresados son correctos
        /// </summary>
        [Fact]
        public void Entity_Valid()
        {
            var fechaActual = new DateTime();
            // Arrange
            var entity = new Cliente()
            {
                Id = 1,
                Nombres = nameof(Cliente.Nombres),
                DocumentoIdentidad = 123,
                FechaCreacion = fechaActual,
            };

            // Act
            var result = entity.Validate();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.Count);
            Assert.Equal(1, entity.Id);
            Assert.Equal(nameof(Cliente.Nombres), entity.Nombres);
            Assert.Equal(123, entity.DocumentoIdentidad);
        }

        /// <summary>
        /// Método encargado de validar el Data Notation asignado a los nombres
        /// </summary>
        /// <param name="nombres">propiedad a validar</param>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void NombresIsNull_ExceptionOneValidation_Error(string nombres)
        {
            var fechaActual = new DateTime();
            // Arrange
            var entity = new Cliente()
            {
                Id = 1,
                Nombres = nombres,
                DocumentoIdentidad = 123,
                FechaCreacion = fechaActual,
            };

            // Act
            var result = entity.Validate();

            // Assert
            Assert.Equal(1, result.Count);
            Assert.Equal("The Nombres field is required.", result[0].ErrorMessage);
        }

        /// <summary>
        /// Método encargado de validar la excepción cuando el nombre excede los 64 caracteres
        /// </summary>
        [Fact]
        public void NombresExceeds64Chareacters_ExpectError()
        {
            // Arrange
            var fechaActual = new DateTime();
            var entity = new Cliente()
            {
                Id = 1,
                Nombres = new string('*', 65),
                DocumentoIdentidad = 123,
                FechaCreacion = fechaActual,
            };

            // Act
            var result = entity.Validate();

            // Assert
            Assert.Equal(1, result.Count);
            Assert.Equal("The Nombres field is required.", result[0].ErrorMessage);
        }
    }
}
