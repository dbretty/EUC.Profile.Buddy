// <copyright file="IWindowsRegistry.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>
namespace EUC.Profile.Buddy.Common.Registry
{
    using EUC.Profile.Buddy.Common.Registry.Model;
    using Microsoft.Win32;

    /// <summary>
    /// Public Interface for the WindowsRegistry Class.
    /// </summary>
    public interface IWindowsRegistry
    {
        /// <summary>
        /// Gets a value from the registry.
        /// </summary>
        /// <param name="valueName">The value name to obtain.</param>
        /// <param name="valueKey">The key the value resides in.</param>
        /// <param name="registryHive">The registry root to query (HKLM, HKCU, HKCR).</param>
        /// <returns>A <see cref="object"/>.</returns>
        public object? GetRegistryValue(string valueName, string valueKey, RegistryHive registryHive);

        /// <summary>
        /// Gets a value from the registry (Async).
        /// </summary>
        /// <param name="valueName">The value name to obtain.</param>
        /// <param name="valueKey">The key the value resides in.</param>
        /// <param name="registryHive">The registry root to query (HKLM, HKCU, HKCR).</param>
        /// <returns>A <see cref="Task"/>.</returns>
        public Task<object?> GetRegistryValueAsync(string valueName, string valueKey, RegistryHive registryHive);

        /// <summary>
        /// Gets Registry Key.
        /// </summary>
        /// <param name="valueKey">The key the value resides in.</param>
        /// <param name="registryHive">The registry root to query (HKLM, HKCU, HKCR).</param>
        /// <returns>A <see cref="bool"/>.</returns>
        public bool GetRegistryKey(string valueKey, RegistryHive registryHive);

        /// <summary>
        /// Builds a registry Path, Key and Value list.
        /// </summary>
        /// <param name="rootPath">The root path to build the list from.</param>
        /// <param name="registryHive">The registry root to query (HKLM, HKCU, HKCR).</param>
        /// <returns>A <see cref="List"/>.</returns>
        public List<RegistryPathValue> GetRegistryPathValue(string[] rootPath, RegistryHive registryHive);

        /// <summary>
        /// Builds a registry Path, Key and Value list (Async).
        /// </summary>
        /// <param name="rootPath">The root path to build the list from.</param>
        /// <param name="registryHive">The registry root to query (HKLM, HKCU, HKCR).</param>
        /// <returns>A <see cref="Task"/>.</returns>
        public Task<List<RegistryPathValue>> GetRegistryPathValueAsync(string[] rootPath, RegistryHive registryHive);
    }
}