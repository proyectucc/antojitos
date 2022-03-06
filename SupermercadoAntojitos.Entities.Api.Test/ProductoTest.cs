using SupermercadoAntojitos.Entities.Api.Test.Helpers;
using Xunit;

namespace SupermercadoAntojitos.Entities.Api.Test
{
    /// <summary>
    /// Pruebas unitarias realizadas a la entidad
    /// </summary>
    public class ProductoTest
    {
        /// <summary>
        /// Prueba encargada de validar que los datos ingresados son correctos
        /// </summary>
        [Fact]
        public void Entity_Valid()
        {
            // Arrange
            var entity = new Producto()
            {
                Id = 1,
                IdVenta = 1,
                NombreProducto = nameof(Producto.NombreProducto),
                Descripcion = nameof(Producto.Descripcion),
                UnidadesExistentes = 12,
                ValorProducto = 1000,
            };

            // Act
            var result = entity.Validate();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.Count);
            Assert.Equal(1, entity.Id);
            Assert.Equal(1, entity.IdVenta);
            Assert.Equal(nameof(Producto.NombreProducto), entity.NombreProducto);
            Assert.Equal(nameof(Producto.Descripcion), entity.Descripcion);
            Assert.Equal(12, entity.UnidadesExistentes);
            Assert.Equal(1000, entity.ValorProducto);
        }

        /// <summary>
        /// Método encargado de validar el Data Notation asignado a los NombreProducto
        /// </summary>
        /// <param name="nombreProducto">propiedad a validar</param>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void NombreProductoIsNull_ExceptionOneValidation_Error(string nombreProducto)
        {
            // Arrange
            var entity = new Producto()
            {
                Id = 1,
                IdVenta = 1,
                NombreProducto = nombreProducto,
                Descripcion = nameof(Producto.Descripcion),
                UnidadesExistentes = 12,
                ValorProducto = 1000,
            };

            // Act
            var result = entity.Validate();

            // Assert
            Assert.Equal(1, result.Count);
            Assert.Equal("The NombreProducto field is required.", result[0].ErrorMessage);
        }

        /// <summary>
        /// Método encargado de validar la excepción cuando el NombreProducto excede los 64 caracteres
        /// </summary>
        [Fact]
        public void NombreProductoExceeds64Chareacters_ExpectError()
        {
            // Arrange
            var entity = new Producto()
            {
                Id = 1,
                IdVenta = 1,
                NombreProducto = new string('*', 65),
                Descripcion = nameof(Producto.Descripcion),
                UnidadesExistentes = 12,
                ValorProducto = 1000,
            };

            // Act
            var result = entity.Validate();

            // Assert
            Assert.Equal(1, result.Count);
            Assert.Equal("The NombreProducto field not is valid.", result[0].ErrorMessage);
        }

        /// <summary>
        /// Método encargado de validar la excepción cuando el Descripcion excede los 64 caracteres
        /// </summary>
        [Fact]
        public void DescripcionExceeds64Chareacters_ExpectError()
        {
            // Arrange
            var entity = new Producto()
            {
                Id = 1,
                IdVenta = 1,
                NombreProducto = nameof(Producto.NombreProducto),
                Descripcion = new string('*', 513),
                UnidadesExistentes = 12,
                ValorProducto = 1000,
            };

            // Act
            var result = entity.Validate();

            // Assert
            Assert.Equal(1, result.Count);
            Assert.Equal("The Descripcion field not is valid.", result[0].ErrorMessage);
        }
    }
}
