using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Made by gpt
namespace RemindMeApp
{
    using Microsoft.Win32;
    using System;

    public static class ThemeHelper
    {
        public static bool IsDarkMode()
        {
            const string registryKey = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
            const string appsUseLightTheme = "AppsUseLightTheme";

            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(registryKey))
                {
                    if (key != null)
                    {
                        object value = key.GetValue(appsUseLightTheme);
                        if (value != null && value is int)
                        {
                            // 0 means dark mode, 1 means light mode
                            return (int)value == 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions if needed (e.g., security issues, missing registry key)
                Console.WriteLine($"Error reading registry: {ex.Message}");
            }

            // Default to light mode if the setting is not found or an error occurred
            return false;
        }
    }

}
