using Flunt.Validations;

using MauiSampleLogin.Models.CreateAccount;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSampleLogin.Contracts.CreateAccount
{
    public class CreateAccountContract : Contract<CreateAccountRequest>
    {
        public CreateAccountContract(CreateAccountRequest createAccount) 
        {
            Requires()
                .IsNotNullOrEmpty(createAccount.Name, nameof(createAccount.Name), "Name is invalid.");

            Requires()
                .IsEmail(createAccount.Email, nameof(createAccount.Email), "E-mail is invalid.")
                .IsNotNullOrEmpty(createAccount.Email, nameof(createAccount.Email), "E-mail is invalid.");

            Requires()
                .IsNotNullOrEmpty(createAccount.Password, nameof(createAccount.Password), "Password is invalid.");
        }
    }
}
