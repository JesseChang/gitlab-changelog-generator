using System;
using System.Collections.Generic;

namespace dotnet_gitlab_changelog_gen
{
    public class IssueModel
    {
        public int iid {get;set;}
        public string title {get;set;}
        public string description {get;set;}
        public string state {get;set;}
        public DateTime created_at {get;set;}
        public DateTime updated_at {get;set;}
        public DateTime closed_at {get;set;}
        public List<string> labels {get;set;}
        public string web_url {get;set;}
        

    }
}