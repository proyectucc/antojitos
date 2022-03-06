using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SupermercadoAntojitos.Entities.Api.Test.Helpers
{
    public static class DataTransferObjectHelper
    {
        /// <summary>
        /// Metodo de extensión encargado de validar un View Model
        /// </summary>
        /// <typeparam name="TDto">Tipo de data transfer object a validar</typeparam>
        /// <param name="dto">ViewModel a Validar</param>
        /// <returns></returns>
        public static IList<ValidationResult> Validate<TDto>(this TDto dto) where TDto : class, new()
        {
            var results = new List<ValidationResult>();

            var validationContext = new ValidationContext(dto, null, null);

            Validator.TryValidateObject(dto, validationContext, results, true);

            if (dto is IValidatableObject)
                (dto as IValidatableObject).Validate(validationContext);

            return results;
        }
    }
}
