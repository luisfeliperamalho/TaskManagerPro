namespace TaskManager.Application.Validations;

public static class CpfValidator
{
    public static bool IsValid(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            return false;

        cpf = new string(cpf.Where(char.IsDigit).ToArray());

        if (cpf.Length != 11 || cpf.Distinct().Count() == 1)
            return false;

        var tempCpf = cpf[..9];
        var digit = GetDigit(tempCpf);
        tempCpf += digit;
        digit += GetDigit(tempCpf);

        return cpf.EndsWith(digit);
    }

    private static string GetDigit(string cpf)
    {
        int[] multiplicador = cpf.Length == 9 ?
            new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 } :
            new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        int soma = 0;
        for (int i = 0; i < multiplicador.Length; i++)
            soma += int.Parse(cpf[i].ToString()) * multiplicador[i];

        int resto = soma % 11;
        if (resto < 2)
            return "0";

        return (11 - resto).ToString();
    }
}
