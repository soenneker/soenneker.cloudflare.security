using Microsoft.Extensions.Logging;
using Soenneker.Cloudflare.OpenApiClient;
using Soenneker.Cloudflare.OpenApiClient.Models;
using Soenneker.Cloudflare.Utils.Client.Abstract;
using Soenneker.Extensions.Task;
using Soenneker.Extensions.ValueTask;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Cloudflare.Security.Abstract;

/// <summary>
/// Utility for managing Cloudflare security settings
/// </summary>
public interface ICloudflareSecurityUtil
{
    /// <summary>
    /// Gets the security level settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone ID</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The security level settings</returns>
    ValueTask<ZoneSettingsGetSingleSetting200Response?> GetSecurityLevel(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the security level settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone ID</param>
    /// <param name="level">The security level</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The updated security level settings</returns>
    ValueTask<ZoneSettingsEditSingleSetting200Response?> UpdateSecurityLevel(string zoneId, string level, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the WAF settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone ID</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The WAF settings</returns>
    ValueTask<ZoneSettingsGetSingleSetting200Response?> GetWaf(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the WAF settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone ID</param>
    /// <param name="enabled">Whether WAF is enabled</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The updated WAF settings</returns>
    ValueTask<ZoneSettingsEditSingleSetting200Response?> UpdateWaf(string zoneId, bool enabled, CancellationToken cancellationToken = default);

    /// <summary>
    /// Enables WAF for a zone
    /// </summary>
    /// <param name="zoneId">The zone ID</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The updated WAF settings</returns>
    ValueTask<ZoneSettingsEditSingleSetting200Response?> EnableWaf(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Disables WAF for a zone
    /// </summary>
    /// <param name="zoneId">The zone ID</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The updated WAF settings</returns>
    ValueTask<ZoneSettingsEditSingleSetting200Response?> DisableWaf(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the Browser Integrity Check settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone ID</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The Browser Integrity Check settings</returns>
    ValueTask<ZoneSettingsGetSingleSetting200Response?> GetBrowserIntegrityCheck(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the Browser Integrity Check settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone ID</param>
    /// <param name="enabled">Whether Browser Integrity Check is enabled</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The updated Browser Integrity Check settings</returns>
    ValueTask<ZoneSettingsEditSingleSetting200Response?> UpdateBrowserIntegrityCheck(string zoneId, bool enabled, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the Always Use HTTPS settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone ID</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The Always Use HTTPS settings</returns>
    ValueTask<ZoneSettingsGetSingleSetting200Response?> GetAlwaysUseHttps(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the Always Use HTTPS settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone ID</param>
    /// <param name="enabled">Whether Always Use HTTPS is enabled</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The updated Always Use HTTPS settings</returns>
    ValueTask<ZoneSettingsEditSingleSetting200Response?> UpdateAlwaysUseHttps(string zoneId, bool enabled, CancellationToken cancellationToken = default);

    /// <summary>
    /// Enables Always Use HTTPS for a zone
    /// </summary>
    /// <param name="zoneId">The zone ID</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The updated Always Use HTTPS settings</returns>
    ValueTask<ZoneSettingsEditSingleSetting200Response?> EnableAlwaysUseHttps(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Disables Always Use HTTPS for a zone
    /// </summary>
    /// <param name="zoneId">The zone ID</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The updated Always Use HTTPS settings</returns>
    ValueTask<ZoneSettingsEditSingleSetting200Response?> DisableAlwaysUseHttps(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the JavaScript Detection settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone ID</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The JavaScript Detection settings</returns>
    ValueTask<ZoneSettingsGetSingleSetting200Response?> GetJavaScriptDetection(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets automatic https rewrites.
    /// </summary>
    /// <param name="zoneId">The zone id.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<ZoneSettingsGetSingleSetting200Response?> GetAutomaticHttpsRewrites(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Enables or disables Automatic HTTPS Rewrites for a zone.
    /// </summary>
    ValueTask<ZoneSettingsEditSingleSetting200Response?> UpdateAutomaticHttpsRewrites(string zoneId, bool enabled,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Enables Automatic HTTPS Rewrites for a zone.
    /// </summary>
    ValueTask<ZoneSettingsEditSingleSetting200Response?> EnableAutomaticHttpsRewrites(string zoneId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Disables Automatic HTTPS Rewrites for a zone.
    /// </summary>
    ValueTask<ZoneSettingsEditSingleSetting200Response?> DisableAutomaticHttpsRewrites(string zoneId,
        CancellationToken cancellationToken = default);
}
