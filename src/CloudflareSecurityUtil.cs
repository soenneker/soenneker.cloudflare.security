using Microsoft.Extensions.Logging;
using Soenneker.Cloudflare.OpenApiClient;
using Soenneker.Cloudflare.OpenApiClient.Models;
using Soenneker.Cloudflare.Security.Abstract;
using Soenneker.Cloudflare.Utils.Client.Abstract;
using Soenneker.Extensions.Task;
using Soenneker.Extensions.ValueTask;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Cloudflare.Security;

/// <inheritdoc cref="ICloudflareSecurityUtil"/>
public sealed class CloudflareSecurityUtil : ICloudflareSecurityUtil
{
    private readonly ICloudflareClientUtil _client;
    private readonly ILogger<CloudflareSecurityUtil> _logger;

    public CloudflareSecurityUtil(ICloudflareClientUtil client, ILogger<CloudflareSecurityUtil> logger)
    {
        _client = client;
        _logger = logger;
    }

    public async ValueTask<Zone_settings_get_single_setting_200> GetSecurityLevel(string zoneId, CancellationToken cancellationToken = default)
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

    public async ValueTask<Zone_settings_edit_single_setting_200> UpdateSecurityLevel(string zoneId, string level, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Updating security level settings for zone {ZoneId} to {Level}", zoneId, level);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new Zones_zone_settings_single_request
            {
                ZonesZoneSettingsSingleRequestMember2 = new Zones_zone_settings_single_requestMember2
                {
                    Value = new Zones_setting_value
                    {
                        ZonesSecurityLevelValue = Enum.Parse<Zones_security_level_value>(level)
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

    public async ValueTask<Zone_settings_get_single_setting_200> GetWaf(string zoneId, CancellationToken cancellationToken = default)
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

    public async ValueTask<Zone_settings_edit_single_setting_200> UpdateWaf(string zoneId, bool enabled, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Updating WAF settings for zone {ZoneId} to {Enabled}", zoneId, enabled);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new Zones_zone_settings_single_request
            {
                ZonesZoneSettingsSingleRequestMember2 = new Zones_zone_settings_single_requestMember2
                {
                    Value = new Zones_setting_value
                    {
                        ZonesWafValue = enabled ? Zones_waf_value.On : Zones_waf_value.Off
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

    public async ValueTask<Zone_settings_edit_single_setting_200> EnableWaf(string zoneId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Enabling WAF for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new Zones_zone_settings_single_request
            {
                ZonesZoneSettingsSingleRequestMember2 = new Zones_zone_settings_single_requestMember2
                {
                    Value = new Zones_setting_value
                    {
                        ZonesWafValue = Zones_waf_value.On
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

    public async ValueTask<Zone_settings_edit_single_setting_200> DisableWaf(string zoneId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Disabling WAF for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new Zones_zone_settings_single_request
            {
                ZonesZoneSettingsSingleRequestMember2 = new Zones_zone_settings_single_requestMember2
                {
                    Value = new Zones_setting_value
                    {
                        ZonesWafValue = Zones_waf_value.Off
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

    public async ValueTask<Zone_settings_get_single_setting_200> GetBrowserIntegrityCheck(string zoneId, CancellationToken cancellationToken = default)
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

    public async ValueTask<Zone_settings_edit_single_setting_200> UpdateBrowserIntegrityCheck(string zoneId, bool enabled, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Updating Browser Integrity Check settings for zone {ZoneId} to {Enabled}", zoneId, enabled);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new Zones_zone_settings_single_request
            {
                ZonesZoneSettingsSingleRequestMember2 = new Zones_zone_settings_single_requestMember2
                {
                    Value = new Zones_setting_value
                    {
                        ZonesBrowserCheckValue = enabled ? Zones_browser_check_value.On : Zones_browser_check_value.Off
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

    public async ValueTask<Zone_settings_get_single_setting_200> GetJavaScriptDetection(string zoneId, CancellationToken cancellationToken = default)
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


    public async ValueTask<Zone_settings_get_single_setting_200> GetAlwaysUseHttps(string zoneId, CancellationToken cancellationToken = default)
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

    public async ValueTask<Zone_settings_edit_single_setting_200> UpdateAlwaysUseHttps(string zoneId, bool enabled, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Updating Always Use HTTPS settings for zone {ZoneId} to {Enabled}", zoneId, enabled);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new Zones_zone_settings_single_request
            {
                ZonesZoneSettingsSingleRequestMember2 = new Zones_zone_settings_single_requestMember2
                {
                    Value = new Zones_setting_value
                    {
                        ZonesAlwaysUseHttpsValue = enabled ? Zones_always_use_https_value.On : Zones_always_use_https_value.Off
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

    public async ValueTask<Zone_settings_edit_single_setting_200> EnableAlwaysUseHttps(string zoneId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Enabling Always Use HTTPS for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new Zones_zone_settings_single_request
            {
                ZonesZoneSettingsSingleRequestMember2 = new Zones_zone_settings_single_requestMember2
                {
                    Value = new Zones_setting_value
                    {
                        ZonesAlwaysUseHttpsValue = Zones_always_use_https_value.On
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

    public async ValueTask<Zone_settings_edit_single_setting_200> DisableAlwaysUseHttps(string zoneId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Disabling Always Use HTTPS for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new Zones_zone_settings_single_request
            {
                ZonesZoneSettingsSingleRequestMember2 = new Zones_zone_settings_single_requestMember2
                {
                    Value = new Zones_setting_value
                    {
                        ZonesAlwaysUseHttpsValue = Zones_always_use_https_value.Off
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

    public async ValueTask<Zone_settings_get_single_setting_200> GetAutomaticHttpsRewrites(string zoneId, CancellationToken cancellationToken = default)
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

    public async ValueTask<Zone_settings_edit_single_setting_200> UpdateAutomaticHttpsRewrites(string zoneId, bool enabled, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Updating Automatic HTTPS Rewrites settings for zone {ZoneId} to {Enabled}", zoneId, enabled);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new Zones_zone_settings_single_request
            {
                ZonesZoneSettingsSingleRequestMember2 = new Zones_zone_settings_single_requestMember2
                {
                    Value = new Zones_setting_value
                    {
                        ZonesAutomaticHttpsRewritesValue = enabled ? Zones_automatic_https_rewrites_value.On : Zones_automatic_https_rewrites_value.Off
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

    public async ValueTask<Zone_settings_edit_single_setting_200> EnableAutomaticHttpsRewrites(string zoneId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Enabling Automatic HTTPS Rewrites for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new Zones_zone_settings_single_request
            {
                ZonesZoneSettingsSingleRequestMember2 = new Zones_zone_settings_single_requestMember2
                {
                    Value = new Zones_setting_value
                    {
                        ZonesAutomaticHttpsRewritesValue = Zones_automatic_https_rewrites_value.On
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

    public async ValueTask<Zone_settings_edit_single_setting_200> DisableAutomaticHttpsRewrites(string zoneId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Disabling Automatic HTTPS Rewrites for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new Zones_zone_settings_single_request
            {
                ZonesZoneSettingsSingleRequestMember2 = new Zones_zone_settings_single_requestMember2
                {
                    Value = new Zones_setting_value
                    {
                        ZonesAutomaticHttpsRewritesValue = Zones_automatic_https_rewrites_value.Off
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
