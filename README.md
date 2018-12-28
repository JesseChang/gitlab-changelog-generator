# gitlab-changelog-generator

A simple tool to generate Gitlab CHANGELOG by issues, milestons, tags, and others.

This project is created for my team to help generate changelog. The original inspiration is [Samuel Michaud's blog](https://medium.com/@SamuelMichaud/generate-a-changelog-from-gitlabs-issue-tracker-9eced2610718) that describes how to generate changelog in chrome browser. And [Andrew Lock's blog](https://andrewlock.net/creating-a-net-core-global-cli-tool-for-squashing-images-with-the-tinypng-api/) and [Nate McMaster's blog](https://natemcmaster.com/blog/2018/05/12/dotnet-global-tools/) instruct very detailly on how to build **.Net Core global CLI tool** which I plan to integrate into my gitlab CI/CD process.

I do hope there will be more and more cross-platform tools in dotnetcore ecosystem for I'm a passionate dotnetcore developer.

# Current Status

This project is still at very begining stage and only generates closed issues into changelog doc. Since this is my side project I will try to update as often as possible.  

# Installation

.Net CLI

```shell
dotnet tool install --global dotnet-gitlab-changelog-gen --version 1.0.1
```

# Usage

``` shell
Usage:
> dotnet gitlab-changelog-gen [options]

Options:
  -t|--token <gitlab_access_token>     Your Gitlab Access Token
  -H|--host <gitlab_hostname>          You can set your gitlab instance host, default is <gitlab.com>
  -p|--project-id <gitlab_project_id>  Gitlab project id
  -f|--feature <feature_tag>           Feature tag name, default is <feature>
  -b|--bug <bug_tag>                   Bug tag name, default is <bug>
  -e|--enhance <enhance_tag>           Enhance tag name, default is <enhance>
  --page <page_number>                 Page number (default: 1)
  --perpage <per_page_number>          Number of items to list per page (default: 20, max: 100)
  -?|-h|--help                         Show help information

Example:
> dotnet gitlab-changelog-gen -t <access-token> -H gitlab.example.com -p 1 

```
