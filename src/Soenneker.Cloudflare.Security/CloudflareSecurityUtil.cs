using Microsoft.Extensions.Logging;
using Soenneker.Cloudflare.OpenApiClient;
using Soenneker.Cloudflare.OpenApiClient.Models;
using Soenneker.Cloudflare.Security.Abstract;
using Soenneker.Cloudflare.Utils.Client.Abstract;
using Soenneker.Extensions.String;
using Soenneker.Extensions.Task;
using Soenneker.Extensions.ValueTask;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Cloudflare.Security;

/// <inheritdoc cref="ICloudflareSecurityUtil" />
public sealed class CloudflareSecurityUtil : ICloudflareSecurityUtil
{
    private readonly ICloudflareClientUtil _client;
    private readonly ILogger<CloudflareSecurityUtil> _logger;

    public CloudflareSecurityUtil(ICloudflareClientUtil client, ILogger<CloudflareSecurityUtil> logger)
    {
        _client = client;
        _logger = logger;
    }

    public async ValueTask<ZoneSettingsGetSingleSetting200Response?> GetSecurityLevel(string zoneId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Getting security level settings for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            return await client.Zones[zoneId].Settings["security_level"].GetAsync(cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting security level settings for zone {ZoneId}", zoneId);
            throw;
        }
    }

    public async ValueTask<ZoneSettingsEditSingleSetting200Response?> UpdateSecurityLevel(string zoneId, string level, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Updating security level settings for zone {ZoneId} to {Level}", zoneId, level);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new ZonesZoneSettingsSingleRequest
            {
                ZonesZoneSettingsSingleRequestOneOf2 = new ZonesZoneSettingsSingleRequestOneOf2
                {
                    Value = new ZonesSettingValue
                    {
                        ZonesSecurityLevelValue = level.ToEnum<ZonesSecurityLevelValue>()
                    }
                }
            };
            return await client.Zones[zoneId].Settings["security_level"].PatchAsync(requestBody, cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating security level settings for zone {ZoneId}", zoneId);
            throw;
        }
    }

    public async ValueTask<ZoneSettingsGetSingleSetting200Response?> GetWaf(string zoneId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Getting WAF settings for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            return await client.Zones[zoneId].Settings["waf"].GetAsync(cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting WAF settings for zone {ZoneId}", zoneId);
            throw;
        }
    }

    public async ValueTask<ZoneSettingsEditSingleSetting200Response?> UpdateWaf(string zoneId, bool enabled, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Updating WAF settings for zone {ZoneId} to {Enabled}", zoneId, enabled);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new ZonesZoneSettingsSingleRequest
            {
                ZonesZoneSettingsSingleRequestOneOf2 = new ZonesZoneSettingsSingleRequestOneOf2
                {
                    Value = new ZonesSettingValue
                    {
                        ZonesWafValue = enabled ? ZonesWafValue.On : ZonesWafValue.Off
                    }
                }
            };
            return await client.Zones[zoneId].Settings["waf"].PatchAsync(requestBody, cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating WAF settings for zone {ZoneId}", zoneId);
            throw;
        }
    }

    public async ValueTask<ZoneSettingsEditSingleSetting200Response?> EnableWaf(string zoneId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Enabling WAF for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new ZonesZoneSettingsSingleRequest
            {
                ZonesZoneSettingsSingleRequestOneOf2 = new ZonesZoneSettingsSingleRequestOneOf2
                {
                    Value = new ZonesSettingValue
                    {
                        ZonesWafValue = ZonesWafValue.On
                    }
                }
            };
            return await client.Zones[zoneId].Settings["waf"].PatchAsync(requestBody, cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error enabling WAF for zone {ZoneId}", zoneId);
            throw;
        }
    }

    public async ValueTask<ZoneSettingsEditSingleSetting200Response?> DisableWaf(string zoneId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Disabling WAF for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new ZonesZoneSettingsSingleRequest
            {
                ZonesZoneSettingsSingleRequestOneOf2 = new ZonesZoneSettingsSingleRequestOneOf2
                {
                    Value = new ZonesSettingValue
                    {
                        ZonesWafValue = ZonesWafValue.Off
                    }
                }
            };
            return await client.Zones[zoneId].Settings["waf"].PatchAsync(requestBody, cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error disabling WAF for zone {ZoneId}", zoneId);
            throw;
        }
    }

    public async ValueTask<ZoneSettingsGetSingleSetting200Response?> GetBrowserIntegrityCheck(string zoneId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Getting Browser Integrity Check settings for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            return await client.Zones[zoneId].Settings["browser_check"].GetAsync(cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting Browser Integrity Check settings for zone {ZoneId}", zoneId);
            throw;
        }
    }

    public async ValueTask<ZoneSettingsEditSingleSetting200Response?> UpdateBrowserIntegrityCheck(string zoneId, bool enabled, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Updating Browser Integrity Check settings for zone {ZoneId} to {Enabled}", zoneId, enabled);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new ZonesZoneSettingsSingleRequest
            {
                ZonesZoneSettingsSingleRequestOneOf2 = new ZonesZoneSettingsSingleRequestOneOf2
                {
                    Value = new ZonesSettingValue
                    {
                        ZonesBrowserCheckValue = enabled ? ZonesBrowserCheckValue.On : ZonesBrowserCheckValue.Off
                    }
                }
            };
            return await client.Zones[zoneId].Settings["browser_check"].PatchAsync(requestBody, cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating Browser Integrity Check settings for zone {ZoneId}", zoneId);
            throw;
        }
    }

    public async ValueTask<ZoneSettingsGetSingleSetting200Response?> GetJavaScriptDetection(string zoneId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Getting JavaScript Detection settings for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            return await client.Zones[zoneId].Settings["js_challenge"].GetAsync(cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting JavaScript Detection settings for zone {ZoneId}", zoneId);
            throw;
        }
    }


    public async ValueTask<ZoneSettingsGetSingleSetting200Response?> GetAlwaysUseHttps(string zoneId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Getting Always Use HTTPS settings for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            return await client.Zones[zoneId].Settings["always_use_https"].GetAsync(cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting Always Use HTTPS settings for zone {ZoneId}", zoneId);
            throw;
        }
    }

    public async ValueTask<ZoneSettingsEditSingleSetting200Response?> UpdateAlwaysUseHttps(string zoneId, bool enabled, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Updating Always Use HTTPS settings for zone {ZoneId} to {Enabled}", zoneId, enabled);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new ZonesZoneSettingsSingleRequest
            {
                ZonesZoneSettingsSingleRequestOneOf2 = new ZonesZoneSettingsSingleRequestOneOf2
                {
                    Value = new ZonesSettingValue
                    {
                        ZonesAlwaysUseHttpsValue = enabled ? ZonesAlwaysUseHttpsValue.On : ZonesAlwaysUseHttpsValue.Off
                    }
                }
            };

            return await client.Zones[zoneId].Settings["always_use_https"].PatchAsync(requestBody, cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating Always Use HTTPS settings for zone {ZoneId}", zoneId);
            throw;
        }
    }

    public async ValueTask<ZoneSettingsEditSingleSetting200Response?> EnableAlwaysUseHttps(string zoneId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Enabling Always Use HTTPS for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new ZonesZoneSettingsSingleRequest
            {
                ZonesZoneSettingsSingleRequestOneOf2 = new ZonesZoneSettingsSingleRequestOneOf2
                {
                    Value = new ZonesSettingValue
                    {
                        ZonesAlwaysUseHttpsValue = ZonesAlwaysUseHttpsValue.On
                    }
                }
            };

            return await client.Zones[zoneId].Settings["always_use_https"].PatchAsync(requestBody, cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error enabling Always Use HTTPS for zone {ZoneId}", zoneId);
            throw;
        }
    }

    public async ValueTask<ZoneSettingsEditSingleSetting200Response?> DisableAlwaysUseHttps(string zoneId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Disabling Always Use HTTPS for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new ZonesZoneSettingsSingleRequest
            {
                ZonesZoneSettingsSingleRequestOneOf2 = new ZonesZoneSettingsSingleRequestOneOf2
                {
                    Value = new ZonesSettingValue
                    {
                        ZonesAlwaysUseHttpsValue = ZonesAlwaysUseHttpsValue.Off
                    }
                }
            };

            return await client.Zones[zoneId].Settings["always_use_https"].PatchAsync(requestBody, cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error disabling Always Use HTTPS for zone {ZoneId}", zoneId);
            throw;
        }
    }

    public async ValueTask<ZoneSettingsGetSingleSetting200Response?> GetAutomaticHttpsRewrites(string zoneId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Getting Automatic HTTPS Rewrites settings for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            return await client.Zones[zoneId].Settings["automatic_https_rewrites"].GetAsync(cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting Automatic HTTPS Rewrites settings for zone {ZoneId}", zoneId);
            throw;
        }
    }

    public async ValueTask<ZoneSettingsEditSingleSetting200Response?> UpdateAutomaticHttpsRewrites(string zoneId, bool enabled, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Updating Automatic HTTPS Rewrites settings for zone {ZoneId} to {Enabled}", zoneId, enabled);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new ZonesZoneSettingsSingleRequest
            {
                ZonesZoneSettingsSingleRequestOneOf2 = new ZonesZoneSettingsSingleRequestOneOf2
                {
                    Value = new ZonesSettingValue
                    {
                        ZonesAutomaticHttpsRewritesValue = enabled ? ZonesAutomaticHttpsRewritesValue.On : ZonesAutomaticHttpsRewritesValue.Off
                    }
                }
            };

            return await client.Zones[zoneId].Settings["automatic_https_rewrites"].PatchAsync(requestBody, cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating Automatic HTTPS Rewrites settings for zone {ZoneId}", zoneId);
            throw;
        }
    }

    public async ValueTask<ZoneSettingsEditSingleSetting200Response?> EnableAutomaticHttpsRewrites(string zoneId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Enabling Automatic HTTPS Rewrites for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new ZonesZoneSettingsSingleRequest
            {
                ZonesZoneSettingsSingleRequestOneOf2 = new ZonesZoneSettingsSingleRequestOneOf2
                {
                    Value = new ZonesSettingValue
                    {
                        ZonesAutomaticHttpsRewritesValue = ZonesAutomaticHttpsRewritesValue.On
                    }
                }
            };

            return await client.Zones[zoneId].Settings["automatic_https_rewrites"].PatchAsync(requestBody, cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error enabling Automatic HTTPS Rewrites for zone {ZoneId}", zoneId);
            throw;
        }
    }

    public async ValueTask<ZoneSettingsEditSingleSetting200Response?> DisableAutomaticHttpsRewrites(string zoneId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Disabling Automatic HTTPS Rewrites for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new ZonesZoneSettingsSingleRequest
            {
                ZonesZoneSettingsSingleRequestOneOf2 = new ZonesZoneSettingsSingleRequestOneOf2
                {
                    Value = new ZonesSettingValue
                    {
                        ZonesAutomaticHttpsRewritesValue = ZonesAutomaticHttpsRewritesValue.Off
                    }
                }
            };

            return await client.Zones[zoneId].Settings["automatic_https_rewrites"].PatchAsync(requestBody, cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error disabling Automatic HTTPS Rewrites for zone {ZoneId}", zoneId);
            throw;
        }
    }
}
