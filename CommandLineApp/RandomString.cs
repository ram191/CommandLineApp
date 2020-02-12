//using System;
//using CommandLineApp;
//using McMaster.Extensions.CommandLineUtils;

//namespace SubcommandSample
//{
//    /// <summary>
//    /// In this example, subcommands are defined using the builder API.
//    /// Defining subcommands is possible by using the return value of app.Command().
//    /// </summary>
//    class Npm
//    {
//        public static int Main(string[] args)
//        {
//            var app = new CommandLineApplication
//            {
//                Name = "ConsoleApp",
//                Description = "An easy assignment",
//            };

//            app.HelpOption(inherited: true);
//            /*-----------------------------------------------------------------*/
//            app.Command("transform", configCmd =>
//            {
//                configCmd.OnExecute(() =>
//                {
//                    Console.WriteLine("Specify a subcommand");
//                    configCmd.ShowHelp();
//                    return 1;
//                });

//                configCmd.Command("uppercase", setCmd =>
//                {
//                    setCmd.Description = "Set config value";
//                    var word = setCmd.Argument("key", "Name of the config").IsRequired();
//                    setCmd.OnExecute(() =>
//                    {
//                        Console.WriteLine(StringTransform.Uppercase(word.Value));
//                    });
//                });

//                configCmd.Command("lowercase", setCmd =>
//                {
//                    setCmd.Description = "Set config value";
//                    var word = setCmd.Argument("key", "Name of the config").IsRequired();
//                    setCmd.OnExecute(() =>
//                    {
//                        Console.WriteLine(StringTransform.Lowercase(word.Value));
//                    });
//                });

//                configCmd.Command("capita", setCmd =>
//                {
//                    setCmd.Description = "Set config value";
//                    var word = setCmd.Argument("key", "Name of the config").IsRequired();
//                    setCmd.OnExecute(() =>
//                    {
//                        Console.WriteLine(StringTransform.Lowercase(word.Value));
//                    });
//                });
//            });

//            app.OnExecute(() =>
//            {
//                Console.WriteLine("Specify a subcommand");
//                app.ShowHelp();
//                return 1;
//            });

//            return app.Execute(args);
//        }
//    }
//}