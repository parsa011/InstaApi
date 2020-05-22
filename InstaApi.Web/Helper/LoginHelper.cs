using System;
using System.IO;
using System.Threading.Tasks;
using InstagramApiSharp.API;
using InstagramApiSharp.API.Builder;
using InstagramApiSharp.Classes;
using InstagramApiSharp.Logger;

namespace InstaApi.Web.Helper
{
    public class LoginHelper
    {
        public static async Task Login(string userName, string passWord)
        {
            var userSession = new UserSessionData
            {
                UserName = userName,
                Password = passWord
            };

            var _instaApi = InstaApiBuilder.CreateBuilder()
                .SetUser(userSession)
                .UseLogger(new DebugLogger(LogLevel.Exceptions))
                .Build();
            const string stateFile = "state.bin";
            if (File.Exists(stateFile))
            {
                await using var fs = File.OpenRead(stateFile);
                _instaApi.LoadStateDataFromString(new StreamReader(fs).ReadToEnd());
            }

            if (!_instaApi.IsUserAuthenticated)
            {
                var logInResult = await _instaApi.LoginAsync();
                if (!logInResult.Succeeded)
                {
                    return;
                }
            }
            var state = _instaApi.GetStateDataAsString();
            await using var fileStream = File.Create(stateFile);
            fileStream.Close();
            await fileStream.DisposeAsync();
            File.WriteAllText(fileStream.Name, state);
        }

        public static async Task<IInstaApi> GetApi()
        {
            var instaApi = InstaApiBuilder.CreateBuilder()
                .SetUser(UserSessionData.Empty)
                .UseLogger(new DebugLogger(LogLevel.Exceptions))
                .Build();
            const string stateFile = "state.bin";
            if (File.Exists(stateFile))
            {
                using (var fs = File.OpenRead(stateFile))
                {
                    instaApi.LoadStateDataFromString(new StreamReader(fs).ReadToEnd());
                }
            }
            else
            {
                return null;
            }

            if (!instaApi.IsUserAuthenticated)
            {
                var logInResult = await instaApi.LoginAsync();
                if (!logInResult.Succeeded)
                {
                    return instaApi;
                }
            }

            return instaApi;

        }
    }
}