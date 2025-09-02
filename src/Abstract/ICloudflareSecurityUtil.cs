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
    ValueTask<Zone_settings_get_single_setting_200?> GetSecurityLevel(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the security level settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone ID</param>
    /// <param name="level">The security level</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The updated security level settings</returns>
    ValueTask<Zone_settings_edit_single_setting_200?> UpdateSecurityLevel(string zoneId, string level, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the WAF settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone ID</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The WAF settings</returns>
    ValueTask<Zone_settings_get_single_setting_200?> GetWaf(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the WAF settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone ID</param>
    /// <param name="enabled">Whether WAF is enabled</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The updated WAF settings</returns>
    ValueTask<Zone_settings_edit_single_setting_200?> UpdateWaf(string zoneId, bool enabled, CancellationToken cancellationToken = default);

    /// <summary>
    /// Enables WAF for a zone
    /// </summary>
    /// <param name="zoneId">The zone ID</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The updated WAF settings</returns>
    ValueTask<Zone_settings_edit_single_setting_200?> EnableWaf(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Disables WAF for a zone
    /// </summary>
    /// <param name="zoneId">The zone ID</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The updated WAF settings</returns>
    ValueTask<Zone_settings_edit_single_setting_200?> DisableWaf(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the Browser Integrity Check settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone ID</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The Browser Integrity Check settings</returns>
    ValueTask<Zone_settings_get_single_setting_200?> GetBrowserIntegrityCheck(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the Browser Integrity Check settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone ID</param>
    /// <param name="enabled">Whether Browser Integrity Check is enabled</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The updated Browser Integrity Check settings</returns>
    ValueTask<Zone_settings_edit_single_setting_200?> UpdateBrowserIntegrityCheck(string zoneId, bool enabled, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the Always Use HTTPS settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone ID</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The Always Use HTTPS settings</returns>
    ValueTask<Zone_settings_get_single_setting_200?> GetAlwaysUseHttps(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the Always Use HTTPS settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone ID</param>
    /// <param name="enabled">Whether Always Use HTTPS is enabled</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The updated Always Use HTTPS settings</returns>
    ValueTask<Zone_settings_edit_single_setting_200?> UpdateAlwaysUseHttps(string zoneId, bool enabled, CancellationToken cancellationToken = default);

    /// <summary>
    /// Enables Always Use HTTPS for a zone
    /// </summary>
    /// <param name="zoneId">The zone ID</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The updated Always Use HTTPS settings</returns>
    ValueTask<Zone_settings_edit_single_setting_200?> EnableAlwaysUseHttps(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Disables Always Use HTTPS for a zone
    /// </summary>
    /// <param name="zoneId">The zone ID</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The updated Always Use HTTPS settings</returns>
    ValueTask<Zone_settings_edit_single_setting_200?> DisableAlwaysUseHttps(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the JavaScript Detection settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone ID</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The JavaScript Detection settings</returns>
    ValueTask<Zone_settings_get_single_setting_200?> GetJavaScriptDetection(string zoneId, CancellationToken cancellationToken = default);

    ValueTask<Zone_settings_get_single_setting_200?> GetAutomaticHttpsRewrites(string zoneId, CancellationToken cancellationToken = default);

}
