using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;

namespace dotnet_gitlab_changelog_gen
{
     [Command(
          Name = "dotnet gitlab-changelog-gen",
          FullName = "dotnet-gitlab-changelog-gen",
          Description = "Uses the Gitlab API to generate changelog.md",
          ExtendedHelpText = Constants.ExtendedHelpText)]
    public class CommandLineOptions
    {
        [Required(ErrorMessage = "You must give gitlab access token to generate changelog.md")]
        [Option("-t|--token <gitlab_access_token>", CommandOptionType.SingleValue, Description = "Your Gitlab Access Token")]
        public string Token {get;}
        
        [Option("-H|--host <gitlab_hostname>", CommandOptionType.SingleValue, Description = "You can set your gitlab instance host, default is <gitlab.com>")]
        public string Host {get;}
        [Option("-p|--project-id <gitlab_project_id>", CommandOptionType.SingleValue, Description = "Gitlab project id")]
        public string ProjectId {get;}
        [Option("-f|--feature <feature_tag>", CommandOptionType.SingleValue, Description = "Feature tag name, default is <feature>")]
        public string Feature {get;}
        [Option("-b|--bug <bug_tag>", CommandOptionType.SingleValue, Description = "Bug tag name, default is <bug>")]
        public string Bug {get;}
        [Option("-e|--enhance <enhance_tag>", CommandOptionType.SingleValue, Description = "Enhance tag name, default is <enhance>")]
        public string Enhance {get;}

        public async Task<int> OnExecute(CommandLineApplication application, IConsole console)
        {
            if (!await setAccessToken(console))
            {
                return Program.ERROR;
            }
            //gen doc here
            var docGenner = new ChangeLogGenerator(Token,Host,ProjectId,Feature,Bug,Enhance);
            await docGenner.GenDocAsync();
            console.WriteLine("CHANGELOG.md has been generated.");
            return Program.OK;
        }

        async Task<bool> setAccessToken(IConsole console)
        {
            try
            {
                var token = string.IsNullOrEmpty(Token)
                    ? Environment.GetEnvironmentVariable("")
                    : Token;

                if (string.IsNullOrWhiteSpace(token))
                {
                    await console.Error.WriteAsync("Error: No Access Token provided");
                    return false;
                }
                console.WriteLine("Access Token has been set.");
                return true;

            }
            catch (Exception ex)
            {
                await console.Error.WriteAsync(ex.Message);
                return false;
            }

        }

    }
}