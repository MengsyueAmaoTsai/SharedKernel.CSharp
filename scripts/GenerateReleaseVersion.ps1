[CmdletBinding()]
param (
    [Parameter(Mandatory = $true, HelpMessage = "The source branch name (e.g. release/1.2.3).")]
    [ValidateNotNullOrEmpty()]
    [string]$BranchName
)

Write-Host "Generating release version from branch name: $BranchName"

if ($BranchName -match '^release/(\d+\.\d+\.\d+)$') {
    $version = $matches[1]
    Write-Host "Generated release version: $version" -ForegroundColor Green
    Write-Output $version
}
else {
    Write-Error "Branch name '$BranchName' does not match pattern 'release/x.y.z'."
    exit 1
}
