[CmdletBinding()]
param ()

Write-Host "Fetching latest release version from remote release branches..."

git fetch --all --quiet
$branches = git branch -r | Where-Object { $_ -match 'origin/release/\d+\.\d+\.\d+' }

if (-not $branches) {
    Write-Error "No release branches found."
    exit 1
}

$versions = $branches | ForEach-Object {
    if ($_ -match 'origin/release/(\d+\.\d+\.\d+)') {
        [PSCustomObject]@{
            BranchName = $_.Trim()
            Version    = [System.Version]$matches[1]
        }
    }
}

$latest = $versions |
Sort-Object -Property Version -Descending |
Select-Object -First 1

if ($null -eq $latest) {
    Write-Error "Failed to parse any valid release version from branches."
    exit 1
}

$versionStr = $latest.Version.ToString()
Write-Host "Latest release version: $versionStr" -ForegroundColor Green
Write-Output $versionStr
