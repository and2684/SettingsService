using Microsoft.AspNetCore.Mvc;
using SettingsService.Data.Repositories.SettingsRepo;

namespace SettingsService.Controllers
{
    [Route("api/settings")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingsRepo _settingsRepo;

        public SettingsController(ISettingsRepo settingsRepo)
        {
            _settingsRepo = settingsRepo;
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> GetSetting(string key)
        {
            var value = await _settingsRepo.GetSettingAsync(key);
            if (value == null)
                return NotFound();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> SetSetting([FromBody] SettingDto setting)
        {
            if (setting == null)
                return BadRequest();

            await _settingsRepo.SetSettingAsync(setting.Key, setting.Value);
            return NoContent();
        }

        [HttpDelete("{key}")]
        public async Task<IActionResult> DeleteSetting(string key)
        {
            await _settingsRepo.DeleteSettingAsync(key);
            return NoContent();
        }
    }
}