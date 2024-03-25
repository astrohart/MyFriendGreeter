using Alphaleonis.Win32.Filesystem;
using Autofac;
using Core.Assemblies.Info;
using Core.Logging;
using Core.Logging.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MyFriendGreeter
{
    /// <summary>
    /// Defines the behaviors of the application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The entry point of the application.
        /// </summary>
        /// <param name="args">
        /// (Required.) Array of <see cref="T:System.String" /> entries,
        /// each of which is a command-line argument that has been passed to the
        /// application.
        /// </param>
        [STAThread]
        public static void Main(string[] args)
        {
            LogFileManager.InitializeLogging(
                muteConsole: false,
                infrastructureType: LoggingInfrastructureType.PostSharp,
                logFileName: Get.LogFilePath(),
                applicationName: Get.ApplicationProductName()
            );

            Console.Clear();

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "Program.Main: Instantiating DI container builder..."
            );

            var builder = new ContainerBuilder();

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "Program.Main: Registering greeting strategies..."
            );

            // Register greeting strategies
            builder.RegisterType<EnglishGreetingStrategy>()
                   .Keyed<IGreetingStrategy>(Language.English);
            builder.RegisterType<FrenchGreetingStrategy>()
                   .Keyed<IGreetingStrategy>(Language.French);
            builder.RegisterType<SpanishGreetingStrategy>()
                   .Keyed<IGreetingStrategy>(Language.Spanish);

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "Program.Main: Registering greeting strategy factory..."
            );

            builder.Register(
                       c =>
                       {
                           var context = c.Resolve<IComponentContext>();
                           return new GreetingStrategyFactory(
                               GetStrategyCreators(context)
                           );
                       }
                   )
                   .As<IGreetingStrategyFactory>();

            DebugUtils.WriteLine(
                DebugLevel.Info, "Program.Main: Reading configuration file..."
            );

            // Read friends and their languages from JSON configuration file
            var configFilePath = Path.Combine(
                Path.GetDirectoryName(
                    Assembly.GetExecutingAssembly()
                            .Location
                ), "friends.json"
            );
            var friends = ReadFriendsFromJson(configFilePath);

            if (friends != null && friends.Count > 0)
                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    $"Program.Main: *** SUCCESS *** {friends.Count} friend(s) read from file '{configFilePath}'."
                );

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "Program.Main: Registering the 'friends' variable in the DI container..."
            );

            builder.RegisterInstance(friends)
                   .As<IList<Friend>>();

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "Program.Main: Registering the greeting service..."
            );

            // Register the GreetingService
            builder.RegisterType<GreetingService>()
                   .AsSelf();

            DebugUtils.WriteLine(
                DebugLevel.Info,
                "Program.Main: Initializing the DI container..."
            );

            // Build the container
            using (var container = builder.Build())
            {
                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    "Program.Main: Beginning the lifetime scope..."
                );

                // Resolve and run the service
                using (var scope = container.BeginLifetimeScope())
                {
                    DebugUtils.WriteLine(
                        DebugLevel.Info,
                        "Program   .Main: Resolving greeting service..."
                    );

                    var greetingService = scope.Resolve<GreetingService>();

                    DebugUtils.WriteLine(
                        DebugLevel.Info, "Program.Main: Greeting my friends..."
                    );

                    greetingService.GreetFriends();
                }
            }

            DebugUtils.WriteLine(DebugLevel.Info, "Program.Main: *** DONE ***");

            Console.ReadKey();
        }

        private static IDictionary<Language, Func<IGreetingStrategy>>
            GetStrategyCreators(IComponentContext ctx)
        {
            var strategyCreators =
                new Dictionary<Language, Func<IGreetingStrategy>>
                {
                    [Language.English] =
                        () => ctx.ResolveKeyed<IGreetingStrategy>(
                            Language.English
                        ),
                    [Language.French] =
                        () => ctx.ResolveKeyed<IGreetingStrategy>(
                            Language.French
                        ),
                    [Language.Spanish] = ()
                        => ctx.ResolveKeyed<IGreetingStrategy>(
                            Language.Spanish
                        )
                };

            return strategyCreators;
        }

        private static IList<Friend> ReadFriendsFromJson(string filePath)
        {
            var result = new List<Friend>();

            try
            {
                if (string.IsNullOrWhiteSpace(filePath)) return result;
                if (!File.Exists(filePath)) return result;

                var friends =
                    ConvertFriends.FromJson(File.ReadAllText(filePath));
                if (friends == null) return result;
                if (friends.Count == 0) return result;

                result.AddRange(friends.Where(friend => friend != null));
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = new List<Friend>();
            }

            return result;
        }

        /// <summary>
        /// Exposes static methods to obtain data from various data sources.
        /// </summary>
        private static class Get
        {
            /// <summary>
            /// A <see cref="T:System.String" /> containing the final piece of the path of the
            /// log file.
            /// </summary>
            private static readonly string LOG_FILE_PATH_TERMINATOR =
                $@"{AssemblyCompany}\{AssemblyProduct}\Logs\{AssemblyTitle}_log.txt";

            /// <summary>
            /// Gets a <see cref="T:System.String" /> that contains the product name defined
            /// for this application.
            /// </summary>
            /// <remarks>
            /// This property is really an alias for the
            /// <see cref="P:xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.AssemblyCompany" />
            /// property.
            /// </remarks>
            private static string AssemblyCompany
                => AssemblyMetadata.AssemblyCompany;

            /// <summary>
            /// Gets a <see cref="T:System.String" /> that contains the product name defined
            /// for this application.
            /// </summary>
            /// <remarks>
            /// This property is really an alias for the
            /// <see cref="P:xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.ShortProductName" />
            /// property.
            /// </remarks>
            private static string AssemblyProduct
                => AssemblyMetadata.ShortProductName;

            /// <summary>
            /// Gets a <see cref="T:System.String" /> that contains the assembly title defined
            /// for this application.
            /// </summary>
            /// <remarks>
            /// This property is really an alias for the
            /// <see cref="P:xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.AssemblyTitle" />
            /// property --- except that all whitespace is replace with underscores.
            /// </remarks>
            private static string AssemblyTitle
                => AssemblyMetadata.AssemblyTitle.Replace(" ", "_");

            /// <summary>
            /// Gets a <see cref="T:System.String" /> that contains a user-friendly name for
            /// the software product of which this application or class library is a part.
            /// </summary>
            /// <returns>
            /// A <see cref="T:System.String" /> that contains a user-friendly name for the
            /// software product of which this application or class library is a part.
            /// </returns>
            public static string ApplicationProductName()
            {
                string result;

                try
                {
                    result = AssemblyProduct;
                }
                catch (Exception ex)
                {
                    // dump all the exception info to the log
                    DebugUtils.LogException(ex);

                    result = string.Empty;
                }

                return result;
            }

            /// <summary>
            /// Obtains a <see cref="T:System.String" /> that contains the fully-qualified
            /// pathname of the file that should be used for logging messages.
            /// </summary>
            /// <returns>
            /// A <see cref="T:System.String" /> that contains the fully-qualified pathname of
            /// the file that should be used for logging messages.
            /// </returns>
            public static string LogFilePath()
                => Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.CommonApplicationData
                    ), LOG_FILE_PATH_TERMINATOR
                );
        }
    }
}