using Microsoft.AspNetCore.Mvc;
using System.Management; // Required for accessing battery info

[Route("api/battery")]
[ApiController]
public class BatteryController : ControllerBase
{
    [HttpGet("status")]
    public IActionResult GetBatteryStatus()
    {
        try
        {
            // Create a new ManagementObjectSearcher to query battery status
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Battery");
            ManagementObjectCollection batteries = searcher.Get();

            // Default values
            int batteryLevel = -1;  // -1 means "Unknown"
            string powerSource = "Unknown";

            foreach (ManagementObject battery in batteries)
            {
                batteryLevel = Convert.ToInt32(battery["EstimatedChargeRemaining"]);
                powerSource = Convert.ToBoolean(battery["BatteryStatus"]) ? "Battery" : "Plugged In";
            }

            var batteryInfo = new
            {
                BatteryLevel = batteryLevel,
                PowerSource = powerSource
            };

            return Ok(batteryInfo);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error retrieving battery status: {ex.Message}");
        }
    }
}
