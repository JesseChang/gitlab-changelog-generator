using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;

namespace dotnet_gitlab_changelog_gen
{
    [Command(Description = "My global command line tool.")]
    class Program
    {
        // Return codes
        public const int EXCEPTION = 2;
        public const int ERROR = 1;
        public const int OK = 0;

        public async static Task<int> Main(string[] args) 
        {
            try
            {
                return await CommandLineApplication.ExecuteAsync<CommandLineOptions>(args);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine($"Unexpected error: {ex}");
                Console.ResetColor();
                return EXCEPTION;
            }
        }
    }
}
