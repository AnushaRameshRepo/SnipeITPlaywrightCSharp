SnipeIt Playwright C# Automation

End to End  UI test fro asset creation in SnipeIt Asset management application

## Prerequisites

Install these before you start:

- [.NET SDK](https://dotnet.microsoft.com/download) (same major version as the `TargetFramework` in the `.csproj`, e.g. 8.0)
- [PowerShell (`pwsh`)](https://learn.microsoft.com/powershell/scripting/install/installing-powershell), needed to install the Playwright browsers
- [Git](https://git-scm.com/)
- Access to a Snipe-IT instance and a test account on it
- Optional: [VS Code](https://code.visualstudio.com/) with the **C# Dev Kit** extension

Check your setup:

```bash
dotnet --version
pwsh --version
git --version
```

## Setup

### 1. Clone the repo

```bash
git clone <your-repo-url>
cd SnipeIt
```

### 2. Restore packages and build

```bash
dotnet build
```

### 3. Install the Playwright browsers (one-off)

Adjust `net8.0` if your project targets a different framework version.

```bash
pwsh bin/Debug/net8.0/playwright.ps1 install
```

### 4. Configure credentials

Credentials are **not** stored in the repo. Create your own local config from the template:

```bash
cp appsettings.example.json appsettings.local.json
```

Then edit `appsettings.local.json` with your own test account:

```json
{
  "Credentials": {
    "Username": "your_username",
    "Password": "your_password"
  }
}
```

`appsettings.local.json` is listed in `.gitignore`. **Never commit it


SnipeIt/
├── Pages/                      # Page objects (locators + actions)
│   ├── LoginPage.cs
│   ├── PanelPage.cs
│   ├── AssetsPage.cs
│   ├── CreateAssetsPage.cs
│   └── AssetDetailsPage.cs
├── Tests/                      # Test classes
│   ├── BaseTest.cs           
│   └── CreateAssetTest.cs
├── appConfig.cs                # Reads appsettings files and environment variables
├── appsettings.example.json    # Template for credentials (committed)
└── appsettings.local.json      # Your credentials (NOT committed)


## Test artifact

Screenshot is setup for only failed test cases. 
