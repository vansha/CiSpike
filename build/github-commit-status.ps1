[CmdletBinding()]
param (
    [string]
    $auth_token = $Env:GITHUB_AUTH_TOKEN,
    
    [ValidateSet('failure', 'success')]
    [string]$buildState,

    [string]
    $revision,

    [string]
    $buildResultsUrl
)

$postData = @{
    state = $buildState
    target_url = $buildResultsUrl
}

$params = @{
    Uri = "https://api.github.com/repos/vansha/CiSpike/statuses/$revision";
    Method = 'POST';
    Headers = @{
        Authorization = "token $auth_token";
    }
    ContentType = 'application/json';
    Body = (ConvertTo-Json $postData -Compress)
}

$response = Invoke-RestMethod @params
$response