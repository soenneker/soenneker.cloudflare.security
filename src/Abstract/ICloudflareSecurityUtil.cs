using Soenneker.Cloudflare.OpenApiClient.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Cloudflare.Security.Abstract;

/// <summary>
/// A utility for managing Cloudflare Security settings
/// </summary>
public interface ICloudflareSecurityUtil
{
    /// <summary>
    /// Gets the security level settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone identifier</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The security level settings</returns>
    ValueTask<Zone_settings_get_single_setting_Response_200_application_json> GetSecurityLevel(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the security level settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone identifier</param>
    /// <param name="level">The security level (low, medium, high, under_attack)</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The updated security level settings</returns>
    ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> UpdateSecurityLevel(string zoneId, string level, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the WAF (Web Application Firewall) settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone identifier</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The WAF settings</returns>
    ValueTask<Zone_settings_get_single_setting_Response_200_application_json> GetWaf(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the WAF settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone identifier</param>
    /// <param name="enabled">Whether WAF should be enabled</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The updated WAF settings</returns>
    ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> UpdateWaf(string zoneId, bool enabled, CancellationToken cancellationToken = default);

    /// <summary>
    /// Enables WAF for a zone
    /// </summary>
    /// <param name="zoneId">The zone identifier</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The updated WAF settings</returns>
    ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> EnableWaf(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Disables WAF for a zone
    /// </summary>
    /// <param name="zoneId">The zone identifier</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The updated WAF settings</returns>
    ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> DisableWaf(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the Browser Integrity Check settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone identifier</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The Browser Integrity Check settings</returns>
    ValueTask<Zone_settings_get_single_setting_Response_200_application_json> GetBrowserIntegrityCheck(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the Browser Integrity Check settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone identifier</param>
    /// <param name="enabled">Whether Browser Integrity Check should be enabled</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The updated Browser Integrity Check settings</returns>
    ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> UpdateBrowserIntegrityCheck(string zoneId, bool enabled, CancellationToken cancellationToken = default);

    /// <summary>
    /// Enables Browser Integrity Check for a zone
    /// </summary>
    /// <param name="zoneId">The zone identifier</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The updated Browser Integrity Check settings</returns>
    ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> EnableBrowserIntegrityCheck(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Disables Browser Integrity Check for a zone
    /// </summary>
    /// <param name="zoneId">The zone identifier</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The updated Browser Integrity Check settings</returns>
    ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> DisableBrowserIntegrityCheck(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the JavaScript Detection settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone identifier</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The JavaScript Detection settings</returns>
    ValueTask<Zone_settings_get_single_setting_Response_200_application_json> GetJavaScriptDetection(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the JavaScript Detection settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone identifier</param>
    /// <param name="enabled">Whether JavaScript Detection should be enabled</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The updated JavaScript Detection settings</returns>
    ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> UpdateJavaScriptDetection(string zoneId, bool enabled, CancellationToken cancellationToken = default);

    /// <summary>
    /// Enables JavaScript Detection for a zone
    /// </summary>
    /// <param name="zoneId">The zone identifier</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The updated JavaScript Detection settings</returns>
    ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> EnableJavaScriptDetection(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Disables JavaScript Detection for a zone
    /// </summary>
    /// <param name="zoneId">The zone identifier</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The updated JavaScript Detection settings</returns>
    ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> DisableJavaScriptDetection(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the AI Labyrinth settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone identifier</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The AI Labyrinth settings</returns>
    ValueTask<Zone_settings_get_single_setting_Response_200_application_json> GetAiLabyrinth(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the AI Labyrinth settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone identifier</param>
    /// <param name="enabled">Whether AI Labyrinth should be enabled</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The updated AI Labyrinth settings</returns>
    ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> UpdateAiLabyrinth(string zoneId, bool enabled, CancellationToken cancellationToken = default);

    /// <summary>
    /// Enables AI Labyrinth for a zone
    /// </summary>
    /// <param name="zoneId">The zone identifier</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The updated AI Labyrinth settings</returns>
    ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> EnableAiLabyrinth(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Disables AI Labyrinth for a zone
    /// </summary>
    /// <param name="zoneId">The zone identifier</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The updated AI Labyrinth settings</returns>
    ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> DisableAiLabyrinth(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the Bot Fight Mode settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone identifier</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The Bot Fight Mode settings</returns>
    ValueTask<Zone_settings_get_single_setting_Response_200_application_json> GetBotFightMode(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the Bot Fight Mode settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone identifier</param>
    /// <param name="enabled">Whether Bot Fight Mode should be enabled</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The updated Bot Fight Mode settings</returns>
    ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> UpdateBotFightMode(string zoneId, bool enabled, CancellationToken cancellationToken = default);

    /// <summary>
    /// Enables Bot Fight Mode for a zone
    /// </summary>
    /// <param name="zoneId">The zone identifier</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The updated Bot Fight Mode settings</returns>
    ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> EnableBotFightMode(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Disables Bot Fight Mode for a zone
    /// </summary>
    /// <param name="zoneId">The zone identifier</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The updated Bot Fight Mode settings</returns>
    ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> DisableBotFightMode(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the Super Bot Fight Mode settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone identifier</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The Super Bot Fight Mode settings</returns>
    ValueTask<Zone_settings_get_single_setting_Response_200_application_json> GetSuperBotFightMode(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the Super Bot Fight Mode settings for a zone
    /// </summary>
    /// <param name="zoneId">The zone identifier</param>
    /// <param name="enabled">Whether Super Bot Fight Mode should be enabled</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The updated Super Bot Fight Mode settings</returns>
    ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> UpdateSuperBotFightMode(string zoneId, bool enabled, CancellationToken cancellationToken = default);

    /// <summary>
    /// Enables Super Bot Fight Mode for a zone
    /// </summary>
    /// <param name="zoneId">The zone identifier</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The updated Super Bot Fight Mode settings</returns>
    ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> EnableSuperBotFightMode(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Disables Super Bot Fight Mode for a zone
    /// </summary>
    /// <param name="zoneId">The zone identifier</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The updated Super Bot Fight Mode settings</returns>
    ValueTask<Zone_settings_edit_single_setting_Response_200_application_json> DisableSuperBotFightMode(string zoneId, CancellationToken cancellationToken = default);
}
