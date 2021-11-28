using System;
using System.Threading.Tasks;
using Blazor.Data.Impl;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace LoginComponent
{
    public partial class Login : ComponentBase
    {
        private string username;
        private string password;
        private string errorMessage;

        public async Task PerformLogin()
        {
            errorMessage = "";
            try
            {
                ((CustomAuthenticationStateProvider) AuthenticationStateProvider).ValidateLogin(username, password);
                username = "";
                password = "";
                NavigationManager.NavigateTo("/");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
        }

        public async Task PerformLogout()
        {
            errorMessage = "";
            username = "";
            password = "";
            try
            {
                ((CustomAuthenticationStateProvider) AuthenticationStateProvider).Logout();
                NavigationManager.NavigateTo("/");
            }
            catch (Exception e)
            {
            }
        }
    }
}