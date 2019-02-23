using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Library.Converter;

namespace Library.Configuration
{
    public class DSettings
    {
        public DSettings()
        {

        }
        public DSettings(int tbn1, int tbn2, int tbn3)
        {
            this.textBoxNotificacao1 = tbn1;
            this.textBoxNotificacao2 = tbn2;
            this.textBoxNotificacao3 = tbn3;
        }

        public int textBoxNotificacao1;
        public int textBoxNotificacao2;
        public int textBoxNotificacao3;
    }


    public static class DAppSettings
    {
        public static void Save(DSettings dsettings)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings.Clear();
            config.AppSettings.Settings.Add("prazoComparecimentoNotificacao1", dsettings.textBoxNotificacao1.ToString());
            config.AppSettings.Settings.Add("prazoComparecimentoNotificacao2", dsettings.textBoxNotificacao2.ToString());
            config.AppSettings.Settings.Add("prazoComparecimentoNotificacao3", dsettings.textBoxNotificacao3.ToString());

            config.Save(ConfigurationSaveMode.Modified);
        }

        public static void Load(DSettings dsettings)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            string sectionName = "appSettings";

            ConfigurationManager.RefreshSection(sectionName);

            AppSettingsSection appSettingSection = (AppSettingsSection)config.GetSection(sectionName);

            if (appSettingSection.Settings["prazoComparecimentoNotificacao1"] == null)
            {
                DSettings ds = new DSettings(0, 0, 0);
                Save(ds);
            }

            ConfigurationManager.RefreshSection(sectionName);
            appSettingSection = (AppSettingsSection)config.GetSection(sectionName);

            dsettings.textBoxNotificacao1 = appSettingSection.Settings["prazoComparecimentoNotificacao1"].Value.ConvertToInt();
            dsettings.textBoxNotificacao2 = appSettingSection.Settings["prazoComparecimentoNotificacao2"].Value.ConvertToInt();
            dsettings.textBoxNotificacao3 = appSettingSection.Settings["prazoComparecimentoNotificacao3"].Value.ConvertToInt();

        }


    }
}
