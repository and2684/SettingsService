namespace SettingsService.Data.Repositories.SettingsRepo
{
    public interface ISettingsRepo
    {
        Task<string?> GetSettingAsync(string key);
        Task SetSettingAsync(string key, string value);
        Task DeleteSettingAsync(string key);
    }
}
