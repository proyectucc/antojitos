using SupermercadoAntojitos.Entities.Api.Test.Helpers;
using System;
using Xunit;

namespace SupermercadoAntojitos.Entities.Api.Test
{
    public class VentaTest
    {
        /// <summary>
        /// Prueba encargada de validar que los datos ingresados son correctos
        /// </summary>
        [Fact]
        public void Entity_Valid()
        {
            // Arrange
            var fechaActual = new DateTime();
            var entity = new Venta()
            {
                Id = 1,
                IdCliente = 1,
                ValorPagar = 1000,
                UnidadesPorProducto = 1,
                FechaVenta = fechaActual,
            };

            // Act
            var result = entity.Validate();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.Count);
            Assert.Equal(1, entity.Id);
            Assert.Equal(1, entity.IdCliente);
            Assert.Equal(1000, entity.ValorPagar);
            Assert.Equal(1, entity.UnidadesPorProducto);
        }

        /// <summary>
        /// Método encargado de validar el Data Notation asignado al valor a pagar
        /// </summary>
        /// <param name="valorPagar">propiedad a validar</param>
        [Theory]
        [InlineData(0)]
        public void ValorPagarIsNull_ExceptionOneValidation_Error(decimal valorPagar)
        {
            // Arrange
            var fechaActual = new DateTime();
            var entity = new Venta()
            {
                Id = 1,
                IdCliente = 1,
                ValorPagar = valorPagar,
                UnidadesPorProducto = 1,
                FechaVenta = fechaActual,
            };

            // Act
            var result = entity.Validate();

            // Assert
            Assert.Equal(1, result.Count);
            Assert.Equal("The ValorPagar field is required.", result[0].ErrorMessage);
        }

        /// <summary>
        /// Método encargado de validar el Data Notation asignado al IDCLiente
        /// </summary>
        /// <param name="idCliente">propiedad a validar</param>
        [Theory]
        [InlineData(0)]
        public void IdClienteIsNull_ExceptionOneValidation_Error(int idCliente)
        {
            // Arrange
            var fechaActual = new DateTime();
            var entity = new Venta()
            {
                Id = 1,
                IdCliente = idCliente,
                ValorPagar = 1,
                UnidadesPorProducto = 1,
                FechaVenta = fechaActual,
            };

            // Act
            var result = entity.Validate();

            // Assert
            Assert.Equal(1, result.Count);
            Assert.Equal("The IdCliente field is required.", result[0].ErrorMessage);
        }

        /// <summary>
        /// Método encargado de validar el Data Notation asignado al UnidadesPorProducto
        /// </summary>
        /// <param name="unidadesPorProducto">propiedad a validar</param>
        [Theory]
        [InlineData(0)]
        public void UnidadesPorProductoIsNull_ExceptionOneValidation_Error(decimal unidadesPorProducto)
        {
            // Arrange
            var fechaActual = new DateTime();
            var entity = new Venta()
            {
                Id = 1,
                IdCliente = 1,
                ValorPagar = 1,
                UnidadesPorProducto = unidadesPorProducto,
                FechaVenta = fechaActual,
            };

            // Act
            var result = entity.Validate();

            // Assert
            Assert.Equal(1, result.Count);
            Assert.Equal("The UnidadesPorProducto field is required.", result[0].ErrorMessage);
        }
    }
}
