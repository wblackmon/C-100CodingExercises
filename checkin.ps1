param(
    [Parameter(Mandatory)]
    [string]$Message
)

dotnet build
if ($LASTEXITCODE -ne 0) {
    Write-Host 'Build failed. Check-in canceled.' -ForegroundColor Red
    exit $LASTEXITCODE
}

git pull
if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }

git add .
git commit -m $Message
if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }

git push