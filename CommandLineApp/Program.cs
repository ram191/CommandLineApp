using System;
using CommandLineApp;
using McMaster.Extensions.CommandLineUtils;

namespace SubcommandSample
{
    /// <summary>
    /// In this example, subcommands are defined using the builder API.
    /// Defining subcommands is possible by using the return value of app.Command().
    /// </summary>
    class Program
    {
        public static int Main(string[] args)
        {
            var app = new CommandLineApplication
            {
                Name = "ConsoleApp",
                Description = "An easy assignment",
            };

            app.HelpOption(inherited: true);

            //Number 1
            /*------------------------------------------------------------------------*/
            app.Command("uppercase", setCmd =>
            {

                var word = setCmd.Argument("key", "Name of the config").IsRequired();
                setCmd.OnExecute(() =>
                {
                    Console.WriteLine(StringTransform.Uppercase(word.Value));
                });
            });

            app.Command("lowercase", setCmd =>
            {
                setCmd.Description = "Set config value";
                var word = setCmd.Argument("key", "Name of the config").IsRequired();
                setCmd.OnExecute(() =>
                {
                    Console.WriteLine(StringTransform.Lowercase(word.Value));
                });
            });

            app.Command("capitalize", setCmd =>
            {
                setCmd.Description = "Set config value";
                var word = setCmd.Argument("key", "Name of the config").IsRequired();
                setCmd.OnExecute(() =>
                {
                    Console.WriteLine(StringTransform.Capitalize(word.Value));
                });
            });

            //Number 2
            /*------------------------------------------------------------------------*/

            //app.Command("sum", setCmd =>
            //{
            //    setCmd.Description = "Set c onfig value";
            //    var word = setCmd.Argument("numbers", "for numbers").IsRequired();
            //    var x = Convert.ToInt32(word);
            //    setCmd.OnExecute(() =>
            //    {
            //        Console.WriteLine(Arithmetic.Add(x));
            //    });
            //});

            //Number 3
            /*------------------------------------------------------------------------*/

            app.Command("palindrome", setCmd =>
            {
                setCmd.Description = "Set c onfig value";
                var word = setCmd.Argument("key", "Name of the config").IsRequired();
                setCmd.OnExecute(() =>
                {
                    var result = Palindrome.IsPalindrome(word.Value);
                    if(result == true)
                    {
                        Console.WriteLine("Is Palindrome? Yes");
                    }
                    else
                    {
                        Console.WriteLine("Is Palindrome? No");
                    }
                });
            });

            //Number 4
            /*------------------------------------------------------------------------*/

            app.Command("obfuscator", setCmd =>
            {
                setCmd.Description = "Set c onfig value";
                var word = setCmd.Argument("key", "Name of the config").IsRequired();
                setCmd.OnExecute(() =>
                {
                    Console.WriteLine(Obfuscator.Obfuscate(word.Value));
                });
            });

            app.OnExecute(() =>
            {
                Console.WriteLine("Specify a subcommand");
                app.ShowHelp();
                return 1;
            });

            app.Command("add", cmd =>
            {
                var files = cmd.Argument("numbers", "numbers to count", multipleValues: true);
                cmd.OnExecute(() =>
                {
                    int total = 0;
                    foreach (var file in files.Values)
                    {
                        var num = Convert.ToInt32(file);
                        total = total + num;
                    }
                    Console.WriteLine(total);
                });
            });

            app.Command("substract", cmd =>
            {
                var files = cmd.Argument("numbers", "numbers to count", multipleValues: true);
                cmd.OnExecute(() =>
                {
                    int total = 0;
                    foreach (var file in files.Values)
                    {
                        var num = Convert.ToInt32(file);
                        total = total - num;
                    }
                    Console.WriteLine(total);
                });
            });

            app.Command("random", cmd =>
            {
                var length = cmd.Option("--length","setting random length",CommandOptionType.SingleOrNoValue);
                var letters = cmd.Option("--letters", "setting letters availability", CommandOptionType.SingleOrNoValue);
                var numbers = cmd.Option("--numbers", "setting numbers availability", CommandOptionType.SingleOrNoValue);
                var lowercase = cmd.Option("--lowercase", "setting lowercase", CommandOptionType.NoValue);
                RandomGenerator generator = new RandomGenerator();
                cmd.OnExecute(() =>
                {
                    int num = Convert.ToInt32(length.Value());
                    string result;
                    if(!length.HasValue())
                    {
                        num = 32;
                    }

                    if (!letters.HasValue() || numbers.HasValue())
                    {
                        result = generator.GenerateNum(num);
                    }
                    else if (letters.HasValue() || !numbers.HasValue())
                    {
                        result = generator.GenerateLet(num);
                    }
                    else
                    {
                        result = generator.GenerateAll(num);
                    }

                    if(lowercase.HasValue())
                    {
                        result = result.ToLower();
                    }

                    Console.WriteLine(result);
                });
            });

            app.Command("ip", cmd =>
            {
                var files = cmd.Argument("numbers", "numbers to count", multipleValues: true);
                cmd.OnExecute(() =>
                {
                    Console.WriteLine(GetIp.GetLocalIPAddress());
                });
            });

            app.Command("ip-external", cmd =>
            {
                var files = cmd.Argument("numbers", "numbers to count", multipleValues: true);
                cmd.OnExecute(() =>
                {
                    Console.WriteLine(GetIp.GetPublicIp());
                });
            });
            return app.Execute(args);
        }
    }
}