using Microsoft.AspNetCore.Mvc;
using System.Management;
namespace BatteryInfoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Battery : ControllerBase
    {
        
        // GET api/myFirstAPI/battery-status
        [HttpGet("battery-status")]
        public string GetBatteryStatus()
        {
            try
            {
                return GetBatteryInformation();
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        // Helper method to get battery information
        private string GetBatteryInformation()
        {
            try
            {
                var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Battery");

                foreach (var queryObj in searcher.Get())
                {
                    string status = queryObj["BatteryStatus"].ToString();
                    string chargeRemaining = queryObj["EstimatedChargeRemaining"].ToString();
                    return $"Battery status: {status}, Charge remaining: {chargeRemaining}%";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }

            return "Battery information not available.";
        }
    }
}
