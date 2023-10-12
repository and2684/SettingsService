using StackExchange.Redis;
namespace SettingsService.Data.Repositories.SettingsRepo
{

    public class SettingsRepo : ISettingsRepo
    {
        private readonly RedisSetupService _redisSetupService;
        private readonly IDatabase _redisDatabase;

        public SettingsRepo(RedisSetupService redisSetupService)
        {
            _redisSetupService = redisSetupService;
            _redisDatabase = _redisSetupService.InitializeRedisSettings("settingsdb");
        }

        public async Task<string?> GetSettingAsync(string key)
        {
            return await _redisDatabase.StringGetAsync(key);
        }

        public async Task SetSettingAsync(string key, string value)
        {
            await _redisDatabase.StringSetAsync(key, value);
        }

        public async Task DeleteSettingAsync(string key)
        {
            await _redisDatabase.KeyDeleteAsync(key);
        }
    }
}
