// <copyright file="WindowsRegistry.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace EUC.Profile.Buddy.Common.Registry
{
    using System.Security;
    using EUC.Profile.Buddy.Common.Logging;
    using EUC.Profile.Buddy.Common.Registry.Exceptions;
    using Microsoft.Win32;

    /// <summary>
    /// Class to read and write to the windows registry.
    /// </summary>
    public class WindowsRegistry : IWindowsRegistry
    {
        private ILogger privateLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowsRegistry"/> class.
        /// </summary>
        /// <param name="logger">The Logger interface.</param>
        public WindowsRegistry(ILogger logger)
        {
            this.privateLogger = logger;
        }

        /// <summary>
        /// Gets a value from the registry.
        /// </summary>
        /// <param name="valueName">The value name to obtain.</param>
        /// <param name="valueKey">The key the value resides in.</param>
        /// <param name="registryHive">The registry root to query (HKLM, HKCU, HKCR).</param>
        /// <returns>A <see cref="object"/>.</returns>
        public object? GetRegistryValue(string valueName, string valueKey, RegistryHive registryHive)
        {
            ArgumentException.ThrowIfNullOrEmpty(valueName, nameof(valueName));
            ArgumentException.ThrowIfNullOrEmpty(valueKey, nameof(valueKey));
            if (!OperatingSystem.IsWindows())
            {
                throw new InvalidOperatingSystemException();
            }
            else
            {
                using (RegistryKey? localKey = GetRegistryHive(registryHive))
                {
                    if (localKey is null)
                    {
                        throw new InvalidRootKeyException();
                    }
                    else
                    {
                        RegistryKey? localFullKey = localKey.OpenSubKey(valueKey);
                        if (localFullKey is null)
                        {
                            throw new InvalidKeyException();
                        }
                        else
                        {
                            object? localValue = localFullKey.GetValue(valueName);
                            if (localValue is null)
                            {
                                throw new InvalidValueException();
                            }
                            else
                            {
                                this.privateLogger.LogAsync($"Registry value for {valueName} retrieved: {localValue}");
                                return localValue;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sets a value in the registry.
        /// </summary>
        /// <param name="valueName">The value name to obtain.</param>
        /// <param name="valueKey">The key the value resides in.</param>
        /// <param name="valueData">The value data to write.</param>
        /// <param name="registryHive">The registry root to query (HKLM, HKCU, HKCR).</param>
        /// <returns>A <see cref="bool"/>.</returns>
        public bool SetRegistryValue(string valueName, string valueKey, object valueData, RegistryHive registryHive)
        {
            ArgumentException.ThrowIfNullOrEmpty(valueName, nameof(valueName));
            ArgumentException.ThrowIfNullOrEmpty(valueKey, nameof(valueKey));
            ArgumentNullException.ThrowIfNull(valueData, nameof(valueData));
            ArgumentNullException.ThrowIfNull(registryHive, nameof(registryHive));

            if (!OperatingSystem.IsWindows())
            {
                throw new InvalidOperatingSystemException();
            }
            else
            {
                using (RegistryKey? localKey = GetRegistryHive(registryHive))
                {
                    if (localKey is null)
                    {
                        throw new InvalidRootKeyException();
                    }
                    else
                    {
                        try
                        {
                            RegistryKey? localFullKey = localKey.OpenSubKey(valueKey, true);
                            if (localFullKey is null)
                            {
                                throw new InvalidKeyException();
                            }
                            else
                            {
                                localFullKey.SetValue(valueName, valueData);
                                this.privateLogger.LogAsync($"Registry value set for {valueName}: {valueData}");
                                return true;
                            }
                        }
                        catch (SecurityException ex)
                        {
                            throw new SecurityException(ex.Message);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Creates a new Registry Key.
        /// </summary>
        /// <param name="valueKey">The key the value resides in.</param>
        /// <param name="registryHive">The registry root to query (HKLM, HKCU, HKCR).</param>
        /// <returns>A <see cref="bool"/> or NONE if successfull.</returns>
        public bool CreateRegistryKey(string valueKey, RegistryHive registryHive)
        {
            ArgumentException.ThrowIfNullOrEmpty(valueKey, nameof(valueKey));
            ArgumentNullException.ThrowIfNull(registryHive, nameof(registryHive));

            if (!OperatingSystem.IsWindows())
            {
                throw new InvalidOperatingSystemException();
            }
            else
            {
                using (RegistryKey? localKey = GetRegistryHive(registryHive))
                {
                    if (localKey is null)
                    {
                        throw new InvalidRootKeyException();
                    }
                    else
                    {
                        RegistryKey? localFullKey = localKey.OpenSubKey(valueKey, true);
                        if (localFullKey is null)
                        {
                            try
                            {
                                localKey.CreateSubKey(valueKey, true);
                                this.privateLogger.LogAsync($"Registry key created {valueKey}");
                                return true;
                            }
                            catch
                            {
                                throw new SecurityException();
                            }
                        }
                        else
                        {
                            throw new InvalidKeyException("Registry Key already exists");
                        }
                    }
                }
            }
        }

        public bool GetRegistryKey(string valueKey, RegistryHive registryHive)
        {
            ArgumentException.ThrowIfNullOrEmpty(valueKey, nameof(valueKey));
            ArgumentNullException.ThrowIfNull(registryHive, nameof(registryHive));

            if (!OperatingSystem.IsWindows())
            {
                throw new InvalidOperatingSystemException();
            }
            else
            {
                using (RegistryKey? localKey = GetRegistryHive(registryHive))
                {
                    if (localKey is null)
                    {
                        throw new InvalidRootKeyException();
                    }
                    else
                    {
                        RegistryKey? localFullKey = localKey.OpenSubKey(valueKey, false);
                        if (localFullKey is not null)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the root key for a registry action.
        /// </summary>
        /// <param name="registryHive">The base root key to action (HKLM, HKCU, HKCR). <see cref="RegistryHive"/>.</param>
        /// <returns>A <see cref="RegistryKey"/> or a null value.</returns>
        private static RegistryKey? GetRegistryHive(RegistryHive registryHive = RegistryHive.LocalMachine)
        {
            RegistryKey? localKey = null;

            if (OperatingSystem.IsWindows())
            {
                localKey = RegistryKey.OpenBaseKey(registryHive, RegistryView.Registry64);
            }

            return localKey;
        }
    }
}