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

    public async ValueTask<Zone_settings_get_single_setting_Response_200_application_json> GetSecurityLevel(string zoneId, CancellationToken cancellationToken = default)
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

    public async ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> UpdateSecurityLevel(string zoneId, string level, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Updating security level settings for zone {ZoneId} to {Level}", zoneId, level);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new Zones_zone_settings_single_request
            {
                AdditionalData =
                {
                    ["value"] = level
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

    public async ValueTask<Zone_settings_get_single_setting_Response_200_application_json> GetWaf(string zoneId, CancellationToken cancellationToken = default)
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

    public async ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> UpdateWaf(string zoneId, bool enabled, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Updating WAF settings for zone {ZoneId} to {Enabled}", zoneId, enabled);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new Zones_zone_settings_single_request
            {
                AdditionalData =
                {
                    ["value"] = enabled ? "on" : "off"
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

    public async ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> EnableWaf(string zoneId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Enabling WAF for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new Zones_zone_settings_single_request
            {
                AdditionalData =
                {
                    ["value"] = "on"
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

    public async ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> DisableWaf(string zoneId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Disabling WAF for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new Zones_zone_settings_single_request
            {
                AdditionalData =
                {
                    ["value"] = "off"
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

    public async ValueTask<Zone_settings_get_single_setting_Response_200_application_json> GetBrowserIntegrityCheck(string zoneId, CancellationToken cancellationToken = default)
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

    public async ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> UpdateBrowserIntegrityCheck(string zoneId, bool enabled, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Updating Browser Integrity Check settings for zone {ZoneId} to {Enabled}", zoneId, enabled);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new Zones_zone_settings_single_request
            {
                AdditionalData =
                {
                    ["value"] = enabled ? "on" : "off"
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

    public async ValueTask<Zone_settings_get_single_setting_Response_200_application_json> GetJavaScriptDetection(string zoneId, CancellationToken cancellationToken = default)
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

    public async ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> UpdateJavaScriptDetection(string zoneId, bool enabled, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Updating JavaScript Detection settings for zone {ZoneId} to {Enabled}", zoneId, enabled);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new Zones_zone_settings_single_request
            {
                AdditionalData =
                {
                    ["value"] = enabled ? "on" : "off"
                }
            };
            return await client.Zones[zoneId].Settings["js_challenge"].PatchAsync(requestBody, cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating JavaScript Detection settings for zone {ZoneId}", zoneId);
            throw;
        }
    }

    public async ValueTask<Zone_settings_get_single_setting_Response_200_application_json> GetAiLabyrinth(string zoneId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Getting AI Labyrinth settings for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            return await client.Zones[zoneId].Settings["ai_labyrinth"].GetAsync(cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting AI Labyrinth settings for zone {ZoneId}", zoneId);
            throw;
        }
    }

    public async ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> UpdateAiLabyrinth(string zoneId, bool enabled, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Updating AI Labyrinth settings for zone {ZoneId} to {Enabled}", zoneId, enabled);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new Zones_zone_settings_single_request
            {
                AdditionalData =
                {
                    ["value"] = enabled ? "on" : "off"
                }
            };
            return await client.Zones[zoneId].Settings["ai_labyrinth"].PatchAsync(requestBody, cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating AI Labyrinth settings for zone {ZoneId}", zoneId);
            throw;
        }
    }

    public async ValueTask<Zone_settings_get_single_setting_Response_200_application_json> GetBotFightMode(string zoneId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Getting Bot Fight Mode settings for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            return await client.Zones[zoneId].Settings["bot_fight_mode"].GetAsync(cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting Bot Fight Mode settings for zone {ZoneId}", zoneId);
            throw;
        }
    }

    public async ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> UpdateBotFightMode(string zoneId, bool enabled, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Updating Bot Fight Mode settings for zone {ZoneId} to {Enabled}", zoneId, enabled);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new Zones_zone_settings_single_request
            {
                AdditionalData =
                {
                    ["value"] = enabled ? "on" : "off"
                }
            };
            return await client.Zones[zoneId].Settings["bot_fight_mode"].PatchAsync(requestBody, cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating Bot Fight Mode settings for zone {ZoneId}", zoneId);
            throw;
        }
    }

    public async ValueTask<Zone_settings_get_single_setting_Response_200_application_json> GetSuperBotFightMode(string zoneId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Getting Super Bot Fight Mode settings for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            return await client.Zones[zoneId].Settings["super_bot_fight_mode"].GetAsync(cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting Super Bot Fight Mode settings for zone {ZoneId}", zoneId);
            throw;
        }
    }

    public async ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> UpdateSuperBotFightMode(string zoneId, bool enabled, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Updating Super Bot Fight Mode settings for zone {ZoneId} to {Enabled}", zoneId, enabled);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new Zones_zone_settings_single_request
            {
                AdditionalData =
                {
                    ["value"] = enabled ? "on" : "off"
                }
            };
            return await client.Zones[zoneId].Settings["super_bot_fight_mode"].PatchAsync(requestBody, cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating Super Bot Fight Mode settings for zone {ZoneId}", zoneId);
            throw;
        }
    }
}
