﻿using Flurl;
using Flurl.Http;
using MauiSampleLogin.Inferfaces;
using MauiSampleLogin.Models;
using MauiSampleLogin.Models.CreateAccount;
using MauiSampleLogin.Helper;
using Newtonsoft.Json;
using Sentry;

namespace MauiSampleLogin.Services
{
    public class LoginService : ILoginService
    {
        public async Task<bool> CreateAccount(CreateAccountRequest createAccountRequest)
        {
            try 
            {
                var response = await Helper.Constants.BASE_URL
                .AppendPathSegment("/users")
                .PostJsonAsync(createAccountRequest);

                return response.ResponseMessage.IsSuccessStatusCode;
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
            
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            try
            {
                var response = await Helper.Constants.BASE_URL
                    .AppendPathSegment("/auth")
                    .WithTimeout(15)
                    .PostJsonAsync(loginRequest);

                if(response.ResponseMessage.IsSuccessStatusCode) 
                {
                    var content = await response.ResponseMessage.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<LoginResponse>(content);
                }
            }
            catch (FlurlHttpException ex) 
            {
                SentrySdk.CaptureException(ex);
            }
            return new LoginResponse();
        }
    }
}
