﻿// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace Microsoft.Practices.EnterpriseLibrary.Common.TestSupport.Configuration
{
    public class ConfigurationSourceUpdatable : IConfigurationSource
    {
        Dictionary<string, ConfigurationSection> configurationsections = new Dictionary<string, ConfigurationSection>();
        #region IConfigurationSource Members

        public ConfigurationSection GetSection(string sectionName)
        {
            ConfigurationSection section;
            configurationsections.TryGetValue(sectionName, out section);
            return section;
        }

        public void Add(string sectionName, ConfigurationSection configurationSection)
        {
            configurationsections[sectionName] = configurationSection;
        }

        public void Remove(string sectionName)
        {
            configurationsections[sectionName] = null;
        }

        public void DoSourceChanged(IEnumerable<string> sectionNames)
        {
            if (SourceChanged != null)
            {
                SourceChanged(this, new ConfigurationSourceChangedEventArgs(this, sectionNames));
            }
        }

        public event EventHandler<ConfigurationSourceChangedEventArgs> SourceChanged;

        public void AddSectionChangeHandler(string sectionName, ConfigurationChangedEventHandler handler)
        {

        }

        public void RemoveSectionChangeHandler(string sectionName, ConfigurationChangedEventHandler handler)
        {

        }

        #endregion

        void IDisposable.Dispose()
        { }
    }
}
