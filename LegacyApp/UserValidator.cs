using System;

namespace LegacyApp;

public class UserValidator
{
    internal static bool ValidateName(string firstName, string lastName)
    {
        if (string.IsNullOrEmpty(firstName)) return false;
        if (string.IsNullOrEmpty(lastName)) return false;
        return true;
    }

    internal static bool ValidateEmail(string email)
    {
        // if (!email.Contains("@") && !email.Contains("."))
        // Z I Prawa De Morgana: <==> !(email.Contains("@") || email.Contains("."))
        if (!email.Contains('@')) return false;
        if (!email.Contains('.')) return false;
        return true;
    }

    internal static bool ValidateAge(DateTime dateOfBirth)
    {
        var now = DateTime.Now;
        int age = now.Year - dateOfBirth.Year;
        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

        return (age >= 21);
    }

    internal static bool IsCreditLimitTooLow(bool hasCreditLimit, int creditLimit)
    {
        if (!hasCreditLimit) return false;
        if (creditLimit >= 500) return false;
        return true;
    }
}