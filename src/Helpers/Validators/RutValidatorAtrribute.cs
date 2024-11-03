using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Api_Taller.src.Helpers.Validators
{
    public class RutValidatorAtrribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string rut = value.ToString();
            if (string.IsNullOrEmpty(rut))
            {
                return new ValidationResult("El Rut es obligatorio");
            }
            if (!Regex.IsMatch(rut, @"^\d{7,8}-[0-9kK]$"))
            {
                return new ValidationResult("El Rut no tiene un formato válido");
            }
            return ValidationResult.Success;
        }

        private bool IsValidRut(string rut)
        {
            if (rut == null) return false;

            string[] parts = rut.Split('-');
            if (parts.Length != 2) return false;

            if (!int.TryParse(parts[0], out int rutNumber)) return false;

            char digitoVerificador = parts[1].ToLowerInvariant()[0];

            int[] coefficients = { 2, 3, 4, 5, 6, 7 };
            int sum = 0;
            int index = 0;

            while (rutNumber != 0)
            {
                sum += rutNumber % 10 * coefficients[index];
                rutNumber /= 10;
                index = (index + 1) % 6;
            }

            int result = 11 - (sum % 11);
            char verificador = result == 10 ? 'k' : result.ToString()[0];

            return verificador == digitoVerificador;
        }

    }
}