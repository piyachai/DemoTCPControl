using System;
using System.Collections.Generic;
using System.Text;


using Microsoft.Win32;

/// <summary>
/// Utility.
/// </summary>
public class AutoStart
{
    private const string RUN_LOCATION = @"Software\Microsoft\Windows\CurrentVersion\Run";

    /// <summary>
    /// Sets the autostart value for the assembly.
    /// </summary>
    /// <param name="keyName">Registry Key Name</param>
    /// <param name="assemblyLocation">Assembly location (e.g. Assembly.GetExecutingAssembly().Location)</param>
    public  void SetAutoStart(string keyName, string assemblyLocation)
    {
        RegistryKey key = Registry.CurrentUser.CreateSubKey(RUN_LOCATION);
        key.SetValue(keyName, assemblyLocation);
    }

    /// <summary>
    /// Returns whether auto start is enabled.
    /// </summary>
    /// <param name="keyName">Registry Key Name</param>
    /// <param name="assemblyLocation">Assembly location (e.g. Assembly.GetExecutingAssembly().Location)</param>
    public  bool IsAutoStartEnabled(string keyName, string assemblyLocation)
    {
        RegistryKey key = Registry.CurrentUser.OpenSubKey(RUN_LOCATION);
        if (key == null)
            return false;

        string value = (string)key.GetValue(keyName);
        if (value == null)
            return false;

        return (value == assemblyLocation);
    }

    /// <summary>
    /// Unsets the autostart value for the assembly.
    /// </summary>
    /// <param name="keyName">Registry Key Name</param>
    public  void UnSetAutoStart(string keyName)
    {
        RegistryKey key = Registry.CurrentUser.CreateSubKey(RUN_LOCATION);
        key.DeleteValue(keyName);
    }
}