[![](https://img.shields.io/nuget/v/soenneker.cloudflare.security.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.cloudflare.security/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.cloudflare.security/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.cloudflare.security/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.cloudflare.security.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.cloudflare.security/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.cloudflare.security/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.cloudflare.security/actions/workflows/codeql.yml)

# Soenneker.Cloudflare.Security

Reads and changes selected Cloudflare zone security and HTTPS settings through a dependency-injected utility.

## Installation

```bash
dotnet add package Soenneker.Cloudflare.Security
```

## Configuration

```json
{
  "Cloudflare": {
    "ApiKey": "your-api-token"
  }
}
```

The token needs permission to read and edit zone settings for the target zone.

## Registration

```csharp
using Soenneker.Cloudflare.Security.Registrars;

services.AddCloudflareSecurityUtilAsScoped();
```

Singleton registration is available with `AddCloudflareSecurityUtilAsSingleton()`.

## Usage

```csharp
using Soenneker.Cloudflare.Security.Abstract;

await security.EnableWaf(zoneId, cancellationToken);
await security.UpdateBrowserIntegrityCheck(zoneId, enabled: true, cancellationToken);
await security.EnableAlwaysUseHttps(zoneId, cancellationToken);
await security.EnableAutomaticHttpsRewrites(zoneId, cancellationToken);
```

The utility wraps these zone settings:

- Security Level (`security_level`)
- WAF (`waf`)
- Browser Integrity Check (`browser_check`)
- JavaScript challenge (`js_challenge`, read only)
- Always Use HTTPS (`always_use_https`)
- Automatic HTTPS Rewrites (`automatic_https_rewrites`)

`UpdateSecurityLevel` parses the supplied string as the generated `ZonesSecurityLevelValue` enum. The value is case-sensitive; accepted names are `Off`, `Essentially_off`, `Low`, `Medium`, `High`, and `Under_attack`.

Changing these values takes effect at zone scope and can alter request handling or redirects for production traffic. Read the existing setting when appropriate, apply one deliberate change at a time, and handle generated Cloudflare API exceptions. Response envelopes are nullable because the generated client permits an empty response body.
