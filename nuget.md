# gitlab-changelog-generator

A simple tool to generate Gitlab CHANGELOG by issues, milestons, tags, and others.

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
> gitlab-changelog-gen -t <access-token> -H gitlab.example.com -p 1 

```
