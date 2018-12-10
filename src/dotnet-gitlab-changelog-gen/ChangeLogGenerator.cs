using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace dotnet_gitlab_changelog_gen
{
    public class ChangeLogGenerator
    {
        readonly string access_token;
        readonly string host;
        readonly string projectId;
        readonly string feature;
        readonly string bug;
        readonly string enhance;

        public ChangeLogGenerator(string AccessToken,
                                    string Host,
                                    string ProjectId,
                                    string Feature,
                                    string Bug,
                                    string Enhance)
        {
            access_token = AccessToken;

            host = string.IsNullOrEmpty(Host)? "https://gitlab.com":Host;
            host = (host.ToLower().Contains("http://") || host.ToLower().Contains("https://"))
                        ? host.ToLower() 
                        : "http://" + host;
            projectId = ProjectId;
            feature = string.IsNullOrEmpty(Feature)?"feature":Feature;
            bug = string.IsNullOrEmpty(Bug)?"bug":Bug;
            enhance = string.IsNullOrEmpty(Enhance)?"enhance":Enhance;
        }
        public async Task GenDocAsync()
        {
            var strDoc = await getGitlabIssuesAsync();
            await File.WriteAllTextAsync("CHANGELOG.md", strDoc);
        }
        async Task<string> getGitlabIssuesAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(host);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("PRIVATE-TOKEN", access_token);
            //we find all scope and closed issues
            Console.WriteLine("Contacting Gitlab instance...");
            HttpResponseMessage response = await client.GetAsync($"api/v4/projects/{projectId}/issues?scope=all&state=closed");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Contact Gitlab fail, pleae check your internet and access_token.");    
            }
            var strJson = await response.Content.ReadAsStringAsync();
            var issueData = JsonConvert.DeserializeObject<List<IssueModel>>(strJson);
            string result = "# Changelog\n\n";
            result += "This doc is generated by [gitlab-changelog-generator](https://github.com/JesseChang/gitlab-changelog-generator).\n";// + System.Environment.NewLine + System.Environment.NewLine;
            //we have 3 sections, feature, bug, enhance
            result += "\n## 🔥 Features\n\n";
            issueData.Where(i => i.labels.Contains(feature)).ToList().ForEach(i => 
            {
                result += "* " + i.title + " #" + i.iid + "\n";
            });
            result += "\n## 🐞 Bugs\n\n";
            issueData.Where(i => i.labels.Contains(bug)).ToList().ForEach(i => 
            {
                result += "* " + i.title + " #" + i.iid + "\n";
            });
            result += "\n## 🚀 Enhances\n\n";
            issueData.Where(i => i.labels.Contains(enhance)).ToList().ForEach(i => 
            {
                result += "* " + i.title + " #" + i.iid + "\n";
            });
            return result;
        }
    }
}