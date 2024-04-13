using System;

namespace LegacyApp
{
    public class UserService
    {
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!UserValidator.ValidateName(firstName, lastName)) return false;
            if (!UserValidator.ValidateEmail(email)) return false;
            if (!UserValidator.ValidateAge(dateOfBirth)) return false;

            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            int creditLimitMultiplier = 1;
            switch (client.Type)
            {
                case "VeryImportantClient":
                    user.HasCreditLimit = false;
                    creditLimitMultiplier = 0;
                    break;
                case "ImportantClient":
                    creditLimitMultiplier = 2;
                    break;
                default:
                    user.HasCreditLimit = true;
                    break;
            }

            if (creditLimitMultiplier > 0)
            {
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    user.CreditLimit = creditLimit * creditLimitMultiplier;

                    if (UserValidator.IsCreditLimitTooLow(user.HasCreditLimit, user.CreditLimit)) return false;
                }
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
