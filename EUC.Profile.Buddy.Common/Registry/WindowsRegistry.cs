// <copyright file="WindowsRegistry.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>
namespace EUC.Profile.Buddy.Common.Registry
{
    using EUC.Profile.Buddy.Common.Logging;
    using EUC.Profile.Buddy.Common.Registry.Exceptions;
    using EUC.Profile.Buddy.Common.Registry.Model;
    using Microsoft.Win32;
    using System.Security;

    /// <summary>
    /// Class to read and write to the windows registry.
    /// </summary>
    public class WindowsRegistry : IWindowsRegistry
    {
        /// <summary>
        /// Private ILogger interface.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowsRegistry"/> class.
        /// </summary>
        /// <param name="logger">The logger to pass in.</param>
        public WindowsRegistry(ILogger logger)
        {
            this.logger = logger;
        }

        /// <inheritdoc/>
        public object? GetRegistryValue(string valueName, string valueKey, RegistryHive registryHive)
        {
            ArgumentException.ThrowIfNullOrEmpty(valueName, nameof(valueName));
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
                                return localValue;
                            }
                        }
                    }
                }
            }
        }

        /// <inheritdoc/>
        public async Task<object?> GetRegistryValueAsync(string valueName, string valueKey, RegistryHive registryHive)
        {
            ArgumentException.ThrowIfNullOrEmpty(valueName, nameof(valueName));
            ArgumentException.ThrowIfNullOrEmpty(valueKey, nameof(valueKey));
            ArgumentNullException.ThrowIfNull(registryHive, nameof(registryHive));

            return await Task.Run(() => this.GetRegistryValue(valueName, valueKey, registryHive));
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public List<RegistryPathValue> GetRegistryPathValue(string[] rootPath, RegistryHive registryHive)
        {
            ArgumentNullException.ThrowIfNull(rootPath, nameof(rootPath));
            ArgumentNullException.ThrowIfNull(registryHive, nameof(registryHive));

            using (RegistryKey? localKey = GetRegistryHive(registryHive))
            {
                if (localKey is null)
                {
                    throw new InvalidRootKeyException();
                }
                else
                {
                    var regPathValue = new List<RegistryPathValue>();
                    foreach (var key in rootPath)
                    {
                        RegistryKey? localFullKey = localKey.OpenSubKey(key, false);
                        if (localFullKey is not null)
                        {
                            foreach (string value in localFullKey.GetValueNames())
                            {
                                RegistryPathValue localValue = new RegistryPathValue();
                                localValue.Path = localFullKey.Name;
                                localValue.Key = value;
                                object? localValueDetail = localFullKey.GetValue(value);
                                localValue.Value = localValueDetail;
                                regPathValue.Add(localValue);
                            }
                        }
                    }

                    return regPathValue;
                }
            }
        }

        /// <inheritdoc/>
        public async Task<List<RegistryPathValue>> GetRegistryPathValueAsync(string[] rootPath, RegistryHive registryHive)
        {
            ArgumentNullException.ThrowIfNull(rootPath, nameof(rootPath));
            ArgumentNullException.ThrowIfNull(registryHive, nameof(registryHive));

            return await Task.Run(() => this.GetRegistryPathValue(rootPath, registryHive));
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
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