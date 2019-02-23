using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;

// The following example shows how to use the ConfigurationManager 
// class in a console application.
//
// IMPORTANT: To compile this example, you must add to the project 
// a reference to the System.Configuration assembly.
//
namespace Samples.Aspnet
{
    #region Auxiliary Classes

    // Define a custom configuration element to be 
    // contained by the ConsoleSection. This element 
    // stores background and foreground colors that
    // the application applies to the console window.
    public class ConsoleConfigElement : ConfigurationElement
    {
        // Create the element.
        public ConsoleConfigElement()
        { }

        // Create the element.
        public ConsoleConfigElement(ConsoleColor fColor,
            ConsoleColor bColor)
        {
            ForegroundColor = fColor;
            BackgroundColor = bColor;
        }

        // Get or set the console background color.
        [ConfigurationProperty("background",
          DefaultValue = ConsoleColor.Black,
          IsRequired = false)]
        public ConsoleColor BackgroundColor
        {
            get
            {
                return (ConsoleColor)this["background"];
            }
            set
            {
                this["background"] = value;
            }
        }

        // Get or set the console foreground color.
        [ConfigurationProperty("foreground",
           DefaultValue = ConsoleColor.White,
           IsRequired = false)]
        public ConsoleColor ForegroundColor
        {
            get
            {
                return (ConsoleColor)this["foreground"];
            }
            set
            {
                this["foreground"] = value;
            }
        }
    }

    // Define a custom section that is used by the application
    // to create custom configuration sections at the specified 
    // level in the configuration hierarchy.
    // This enables the the user that has the proper access 
    // rights, to make changes to the configuration files.
    public class ConsoleSection : ConfigurationSection
    {
        // Create a configuration section.
        public ConsoleSection()
        { }

        // Set or get the ConsoleElement. 
        [ConfigurationProperty("consoleElement")]
        public ConsoleConfigElement ConsoleElement
        {
            get
            {
                return (
                  (ConsoleConfigElement)this["consoleElement"]);
            }
            set
            {
                this["consoleElement"] = value;
            }
        }
    }
    #endregion

    #region ConfigurationManager Interaction Class

    // The following code uses the ConfigurationManager class to 
    // perform the following tasks:
    // 1) Get the application roaming configuration file.
    // 2) Get the application configuration file.
    // 3) Access a specified configuration file through mapping.
    // 4) Access the machine configuration file through mapping. 
    // 5) Read a specified configuration section.
    // 6) Read the connectionStrings section.
    // 7) Read or write the appSettings section.
    public static class UsingConfigurationManager
    {
        // Get the roaming configuration file associated 
        // with the application.
        // Note.This function uses the OpenExeConfiguration(
        // ConfigurationUserLevel userLevel) method to 
        // get the configuration file.
        public static void GetRoamingConfiguration()
        {
            // Define the custom section to add to the
            // configuration file.
            string sectionName = "consoleSection";
            ConsoleSection cSection = null;

            // Get the roaming configuration 
            // that applies to the current user.
            Configuration roamingConfig =
              ConfigurationManager.OpenExeConfiguration(
               ConfigurationUserLevel.PerUserRoaming);

            // Map the roaming configuration file. This
            // enables the application to access 
            // the configuration file using the
            // System.Configuration.Configuration class
            ExeConfigurationFileMap configFileMap =
              new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename =
              roamingConfig.FilePath;

            // Get the mapped configuration file.
            Configuration config =
              ConfigurationManager.OpenMappedExeConfiguration(
                configFileMap, ConfigurationUserLevel.None);

            try
            {
                cSection =
                     (ConsoleSection)config.GetSection(
                       sectionName);

                if (cSection == null)
                {
                    // Create a custom configuration section.
                    cSection = new ConsoleSection();

                    // Define where in the configuration file 
                    // hierarchy the associated 
                    // configuration section can be declared.
                    cSection.SectionInformation.AllowExeDefinition =
                      ConfigurationAllowExeDefinition.MachineToLocalUser;

                    // Allow the configuration section to be 
                    // overridden by other configuration files.
                    cSection.SectionInformation.AllowOverride =
                      true;

                    // Force the section to be saved.
                    cSection.SectionInformation.ForceSave = true;

                    // Store console settings for roaming users.
                    cSection.ConsoleElement.BackgroundColor =
                        ConsoleColor.Blue;
                    cSection.ConsoleElement.ForegroundColor =
                        ConsoleColor.Yellow;

                    // Add configuration information to 
                    // the configuration file.
                    config.Sections.Add(sectionName, cSection);
                    config.Save(ConfigurationSaveMode.Modified);
                    // Force a reload of the changed section. This 
                    // makes the new values available for reading.
                    ConfigurationManager.RefreshSection(
                      sectionName);
                }
            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine("[Exception error: {0}]",
                    e.ToString());
            }

            // Set console properties using values
            // stored in the configuration file.
            Console.BackgroundColor =
              cSection.ConsoleElement.BackgroundColor;
            Console.ForegroundColor =
              cSection.ConsoleElement.ForegroundColor;
            // Apply the changes.
            Console.Clear();

            // Display feedback.
            Console.WriteLine();
            Console.WriteLine("Performed the following tasks:");
            Console.WriteLine(
              "Created roaming configuration file {0}",
              config.FilePath);
            Console.WriteLine("Created custom ConsoleSection.");
            Console.WriteLine(
              "Stored background (blue) and foreground (yellow) colors.");
            Console.WriteLine(
              "Added the section to the configuration file.");
            Console.WriteLine(
              "Read stored colors from the configuration file.");
            Console.WriteLine("Applied the colors to the console window.");
            Console.WriteLine();

        }

        // Get the application configuration file.
        // Note. This function uses the 
        // OpenExeConfiguration(string)method 
        // to get the application configuration file. 
        public static void GetAppConfiguration()
        {
            // Get the application path needed to obtain
            // the application configuration file.
            string applicationName =
                Environment.GetCommandLineArgs()[0];


            if (!applicationName.Contains(".exe"))
                applicationName =
                  String.Concat(applicationName, ".exe");


            string exePath = System.IO.Path.Combine(
                Environment.CurrentDirectory, applicationName);

            // Get the configuration file. The file name has
            // this format appname.exe.config.
            System.Configuration.Configuration config =
              ConfigurationManager.OpenExeConfiguration(exePath);

            try
            {
                // Create a custom configuration section
                // having the same name used in the 
                // roaming configuration file.
                // This is possible because the configuration 
                // section can be overridden by other 
                // configuration files. 
                string sectionName = "consoleSection";
                ConsoleSection customSection = new ConsoleSection();

                if (config.Sections[sectionName] == null)
                {
                    // Store console settings.
                    customSection.ConsoleElement.BackgroundColor =
                        ConsoleColor.Black;
                    customSection.ConsoleElement.ForegroundColor =
                        ConsoleColor.White;

                    // Add configuration information to the
                    // configuration file.
                    config.Sections.Add(sectionName, customSection);
                    config.Save(ConfigurationSaveMode.Modified);
                    // Force a reload of the changed section.
                    // This makes the new values available for reading.
                    ConfigurationManager.RefreshSection(sectionName);
                }
                // Set console properties using values
                // stored in the configuration file.
                customSection =
                    (ConsoleSection)config.GetSection(sectionName);
                Console.BackgroundColor =
                    customSection.ConsoleElement.BackgroundColor;
                Console.ForegroundColor =
                    customSection.ConsoleElement.ForegroundColor;
                // Apply the changes.
                Console.Clear();
            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine("[Error exception: {0}]",
                    e.ToString());
            }

            // Display feedback.
            Console.WriteLine();
            Console.WriteLine("Performed the following tasks:");
            Console.WriteLine(
              "Created the application configuration file {0}",
              config.FilePath);
            Console.WriteLine("Created custom ConsoleSection.");
            Console.WriteLine(
              "Stored background (black) and foreground (white) colors.");
            Console.WriteLine(
              "Added the section to the configuration file.");
            Console.WriteLine(
              "Read stored colors from the configuration file.");
            Console.WriteLine("Applied the colors to the console window.");
            Console.WriteLine();
        }

        // Get the AppSettings section.        
        // This function uses the AppSettings property
        // to read the appSettings configuration 
        // section.
        public static void ReadAppSettings()
        {
            try
            {
                // Get the AppSettings section.
                NameValueCollection appSettings =
                   ConfigurationManager.AppSettings;

                // Get the AppSettings section elements.
                Console.WriteLine();
                Console.WriteLine("Performed the following tasks:");
                Console.WriteLine("Read application settings:");
                Console.WriteLine();

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("[ReadAppSettings: {0}]",
                    "AppSettings is empty Use GetSection command first.");
                }
                for (int i = 0; i < appSettings.Count; i++)
                {
                    Console.WriteLine("#{0} Key: {1} Value: {2}",
                      i, appSettings.GetKey(i), appSettings[i]);
                }
            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine("[ReadAppSettings: {0}]",
                    e.ToString());
            }
        }

        // Get the ConnectionStrings section.        
        // This function uses the ConnectionStrings 
        // property to read the connectionStrings
        // configuration section.
        public static void ReadConnectionStrings()
        {

            // Get the ConnectionStrings collection.
            ConnectionStringSettingsCollection connections =
                ConfigurationManager.ConnectionStrings;

            if (connections.Count != 0)
            {

                Console.WriteLine();
                Console.WriteLine("Performed the following tasks:");
                Console.WriteLine("Read connection strings:");
                Console.WriteLine();

                // Get the collection elements.
                foreach (ConnectionStringSettings connection in
                  connections)
                {
                    string name = connection.Name;
                    string provider = connection.ProviderName;
                    string connectionString = connection.ConnectionString;

                    Console.WriteLine("Name:               {0}",
                      name);
                    Console.WriteLine("Connection string:  {0}",
                      connectionString);
                    Console.WriteLine("Provider:            {0}",
                       provider);
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("No connection string is defined.");
                Console.WriteLine();
            }
        }


        // Create the AppSettings section.
        // The function uses the GetSection(string)method 
        // to access the configuration section. 
        // It also adds a new element to the section 
        // collection.
        public static void CreateAppSettings()
        {
            // Get the application configuration file.
            System.Configuration.Configuration config =
              ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            string sectionName = "appSettings";

            // Add an entry to appSettings.
            int appStgCnt =
                ConfigurationManager.AppSettings.Count;
            string newKey = "NewKey" + appStgCnt.ToString();

            string newValue = DateTime.Now.ToLongDateString() +
              " " + DateTime.Now.ToLongTimeString();

            config.AppSettings.Settings.Add(newKey, newValue);

            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified);

            // Force a reload of the changed section. This 
            // makes the new values available for reading.
            ConfigurationManager.RefreshSection(sectionName);

            // Get the AppSettings section.
            AppSettingsSection appSettingSection =
              (AppSettingsSection)config.GetSection(sectionName);

            // Display raw xml.
            Console.WriteLine();
            Console.WriteLine("Performed the following tasks:");
            Console.WriteLine("Created AppSettings section.");
            Console.WriteLine("Added new element to the section.");
            Console.WriteLine("Read the following settings:");
            Console.WriteLine();

            // Get the AppSettings XML.
            Console.WriteLine(
              appSettingSection.SectionInformation.GetRawXml());
        }

        // Access a configuration file using mapping.
        // This function uses the OpenMappedExeConfiguration 
        // method to access the roaming and the application
        // configuration files.   
        // It then uses the the custom ConsoleSection from
        // each file to console window colors.
        public static void MapExeConfiguration()
        {
            // Cotains the selected configuration.
            System.Configuration.Configuration config;

            // Get the roaming configuration file.
            Configuration roamingConfig =
             ConfigurationManager.OpenExeConfiguration(
              ConfigurationUserLevel.PerUserRoaming);

            // Get the application configuration file.
            Configuration appConfig =
             ConfigurationManager.OpenExeConfiguration(
              ConfigurationUserLevel.None);

            // To map the selected configuration file.
            ExeConfigurationFileMap configFileMap =
                new ExeConfigurationFileMap();

            // Map roaming configuration. This allows
            // access to the roaming configuration file.
            configFileMap.ExeConfigFilename =
              roamingConfig.FilePath;

            // Get the mapped configuration file
            config =
               ConfigurationManager.OpenMappedExeConfiguration(
                 configFileMap, ConfigurationUserLevel.None);

            string sectionName = "consoleSection";

            ConsoleSection customSection =
              (ConsoleSection)config.GetSection(sectionName);

            // Set console properties using the 
            // configuration values contained in the 
            // mapped configuration file.
            Console.BackgroundColor =
              customSection.ConsoleElement.BackgroundColor;
            Console.ForegroundColor =
              customSection.ConsoleElement.ForegroundColor;
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("Performed following tasks:");
            Console.WriteLine(
              "Mapped roaming configuration file: {0}",
              config.FilePath);
            Console.WriteLine(
              "Set console colors from stored configuration values.");
            Console.WriteLine();
            Console.Write(
              "Press Enter to switch to default colors.....");
            Console.ReadLine();

            // Map roaming configuration. This allows
            // access to the application configuration file.
            configFileMap.ExeConfigFilename =
              appConfig.FilePath;

            // Get the mapped configuration file
            config =
               ConfigurationManager.OpenMappedExeConfiguration(
                 configFileMap, ConfigurationUserLevel.None);

            customSection =
              (ConsoleSection)config.GetSection(sectionName);

            if (customSection == null)
            {
                customSection = new ConsoleSection();

                // Store console settings.
                customSection.ConsoleElement.BackgroundColor =
                    ConsoleColor.Black;
                customSection.ConsoleElement.ForegroundColor =
                    ConsoleColor.White;

                // Add configuration information to the
                // configuration file.
                config.Sections.Add(sectionName, customSection);
                config.Save(ConfigurationSaveMode.Modified);
                // Force a reload of the changed section.
                // This makes the new values available for reading.
                ConfigurationManager.RefreshSection(sectionName);
            }

            // Set console properties using the 
            // configuration values contained in the 
            // mapped configuration file.
            Console.BackgroundColor =
              customSection.ConsoleElement.BackgroundColor;
            Console.ForegroundColor =
              customSection.ConsoleElement.ForegroundColor;
            Console.Clear();

            Console.WriteLine(
              "Mapped application configuration file: {0}",
              config.FilePath);
            Console.WriteLine(
              "Set console colors from stored configuration values.");
            Console.WriteLine();

        }

        // Access the machine configuration file using mapping.
        // The function uses the OpenMappedMachineConfiguration 
        // method to access the machine configuration. 
        public static void MapMachineConfiguration()
        {
            // Get the machine.config3 file.
            Configuration machineConfig =
              ConfigurationManager.OpenMachineConfiguration();
            // Get the machine.config file path.
            ConfigurationFileMap configFile =
              new ConfigurationFileMap(machineConfig.FilePath);

            // Map the application configuration file to the machine 
            // configuration file.
            Configuration config =
              ConfigurationManager.OpenMappedMachineConfiguration(
                configFile);

            // Get the AppSettings section.
            AppSettingsSection appSettingSection =
              (AppSettingsSection)config.GetSection("appSettings");
            appSettingSection.SectionInformation.AllowExeDefinition =
                ConfigurationAllowExeDefinition.MachineToRoamingUser;

            // Display the configuration file sections.
            ConfigurationSectionCollection sections =
              config.Sections;

            Console.WriteLine();
            Console.WriteLine("Using OpenMappedMachineConfiguration.");
            Console.WriteLine("Sections in machine.config:");

            // Get the sections in the machine.config.
            foreach (ConfigurationSection section in sections)
            {
                string name = section.SectionInformation.Name;
                Console.WriteLine("Name: {0}", name);
            }

        }
    }
    #endregion

    #region User Interaction Class

    // Obtain user's input and provide feedback.
    // This class contains the application Main() function.
    // It calls the ConfigurationManager methods based 
    // on the user's selection.
    class ApplicationMain
    {
        // Display user's menu.
        public static void DisplayUserMenu()
        {
            string applicationName =
               Environment.GetCommandLineArgs()[0] + ".exe";
            StringBuilder buffer = new StringBuilder();

            buffer.AppendLine();
            buffer.AppendLine("Application: " + applicationName);
            buffer.AppendLine("Please, make your selection.");
            buffer.AppendLine("Q,q  -- Exit the application.");
            buffer.Append("1    -- Set console window colors");
            buffer.AppendLine(" to blue and yellow");
            buffer.AppendLine("        from the roaming configuration.");
            buffer.AppendLine("2    -- Ceate appSettings section.");
            buffer.AppendLine("3    -- Read appSettings section.");
            buffer.AppendLine("        Values merged from application config.");
            buffer.Append("4    -- Set console window colors");
            buffer.AppendLine(" to black and white");
            buffer.AppendLine("        from the application configuration.");
            buffer.AppendLine("5    -- Read connectionStrings section.");
            buffer.AppendLine("        Values merged from machine.config.");
            buffer.AppendLine("6    -- Get specified configuration file.");
            buffer.Append("        Set console window colors");
            buffer.AppendLine(" from configured values.");
            buffer.AppendLine("7    -- Get machine.config file.");
            buffer.AppendLine();

            Console.Write(buffer.ToString());
        }

        // Obtain user's input and provide
        // feedback.
        static void Main(string[] args)
        {
            // Define user selection string.
            string selection = "";

            // Get the name of the application.
            string appName =
              Environment.GetCommandLineArgs()[0];

            while (selection.ToLower() != "q")
            {
                // Process user's input.
                switch (selection)
                {
                    case "1":
                        // Show how to use OpenExeConfiguration
                        // using the configuration user level.
                        UsingConfigurationManager.GetRoamingConfiguration();
                        break;

                    case "2":
                        // Show how to use GetSection.
                        UsingConfigurationManager.CreateAppSettings();
                        break;

                    case "3":
                        // Show how to use AppSettings.
                        UsingConfigurationManager.ReadAppSettings();
                        break;

                    case "4":
                        // Show how to use OpenExeConfiguration
                        // using the configuration file path.
                        UsingConfigurationManager.GetAppConfiguration();
                        break;

                    case "5":
                        // Show how to use ConnectionStrings.
                        UsingConfigurationManager.ReadConnectionStrings();
                        break;

                    case "6":
                        // Show how to use OpenMappedExeConfiguration.
                        UsingConfigurationManager.MapExeConfiguration();
                        break;

                    case "7":
                        // Show how to use OpenMappedMachineConfiguration.
                        UsingConfigurationManager.MapMachineConfiguration();
                        break;

                    default:
                        // DisplayUserMenu();
                        break;
                }
                DisplayUserMenu();
                Console.Write("> ");
                selection = Console.ReadLine();
            }
        }
    }
    #endregion
}
