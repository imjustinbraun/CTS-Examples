using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4;
using T4.API;

namespace CTSMultiUserErr
{
    public static class Program
    {
        private static T4.API.Host? _host;
        private static UserList? _ctsUsers;

        public static void Main(string[] args)
        {
            Console.WriteLine(System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString());

            Console.WriteLine("Connecting to CTS...");

            try
            {
                Console.WriteLine(
                    $"Logging in with Credentials:\n User: {creds.BBTest1.UserID}\n Firm: {creds.BBTest1.Firm}\n Password: {creds.BBTest1.Password}"
                );
                _host = new(
                    APIServerType.Simulator,
                    "T4Example",
                    "112A04B0-5AAF-42F4-994E-FA7CB959C60B",
                    creds.BBTest1.Firm,
                    creds.BBTest1.UserID,
                    creds.BBTest1.Password
                );
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error connecting to CTS: {e.Message}");
                return;
            }
            _ctsUsers = _host.Users;
            _host.LoginResponse += _host_LoginResponse;

        }

        private static void _host_LoginResponse(LoginResponseEventArgs e)
        {
            T4.API.User ctsUser = e.User;
            Console.WriteLine($"User: {ctsUser.Username} {ctsUser.UserID}");

            switch (e.Result)
            {
                case LoginResult.Success:
                    Console.WriteLine($"Login Successful with User: {ctsUser.Username}");
                    tryAnother();
                    break;
                case LoginResult.LoggedInElsewhere:
                    Console.WriteLine("Logged in elsewhere");
                    break;
                case LoginResult.Logout:
                    Console.WriteLine("Logged out");
                    break;
                case LoginResult.ApplicationNotValid:
                    Console.WriteLine("Application not valid");
                    break;
                case LoginResult.UserExists:
                    Console.WriteLine("User exists");
                    break;
                case LoginResult.FIXSessionError:
                    Console.WriteLine("FIX Session Error");
                    break;
                case LoginResult.AdditionalUsersNotAllowed:
                    Console.WriteLine("Additional Users not allowed");
                    break;
                case LoginResult.APIMessageBacklog:
                    Console.WriteLine("API Message Backlog");
                    break;
                case LoginResult.LockedOut:
                    Console.WriteLine("Locked Out");
                    break;
                case LoginResult.PasswordExpired:
                    Console.WriteLine("Password Expired");
                    break;
                case LoginResult.UnexpectedDisconnect:
                    Console.WriteLine($"Disconnect Resason: {e.Result}");
                    break;
                case LoginResult.FirmNotAllowed:
                    Console.WriteLine("Firm not allowed");
                    break;
                default:
                    Console.WriteLine($"Unknown Disconnect Reason: {e.Result}");
                    break;
            }
        }

        private static void tryAnother()
        {
            Console.WriteLine("Trying another login");
            _ctsUsers!.LoginUser(creds.BBTest2.UserID, creds.BBTest2.Password, _host_LoginResponse);
        }
    }
}