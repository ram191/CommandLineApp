using System;
using System.Collections.Generic;
using System.Linq;
using CommandLineApp;
using McMaster.Extensions.CommandLineUtils;

namespace SubcommandSample
{
    class Program
    {
        public static int Main(string[] args)
        {
            var app = new CommandLineApplication
            {
                Name = "ConsoleApp",
                Description = "An required assignment",
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


            app.Command("add", cmd =>
            {
                var files = cmd.Argument("numbers", "numbers to count", multipleValues: true);
                cmd.OnExecute(() =>
                {
                    var result = Arithmetic.DoArithmetic(files.Values, "add");

                    Console.WriteLine(result);
                });
            });

            app.Command("substract", cmd =>
            {
                var files = cmd.Argument("numbers", "numbers to count", multipleValues: true);
                cmd.OnExecute(() =>
                {
                    var result = Arithmetic.DoArithmetic(files.Values, "substract");

                    Console.WriteLine(result);
                });
            });

            app.Command("multiply", cmd =>
            {
                var files = cmd.Argument("numbers", "numbers to count", multipleValues: true);
                cmd.OnExecute(() =>
                {
                    var result = Arithmetic.DoArithmetic(files.Values, "multiply");

                    Console.WriteLine(result);
                });
            });

            app.Command("divide", cmd =>
            {
                var files = cmd.Argument("numbers", "numbers to count", multipleValues: true);
                cmd.OnExecute(() =>
                {
                    var result = Arithmetic.DoArithmetic(files.Values, "divide");

                    Console.WriteLine(result);
                });
            });

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

            //Number 5
            /*------------------------------------------------------------------------*/


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

            //Number 6
            /*------------------------------------------------------------------------*/

            app.Command("ip", cmd =>
            {
                cmd.OnExecute(() =>
                {
                    Console.WriteLine(GetIp.GetLocalIPAddress());
                });
            });

            //Number 7
            /*------------------------------------------------------------------------*/

            app.Command("ip-external", cmd =>
            {
                cmd.OnExecute(() =>
                {
                    Console.WriteLine(GetIp.GetPublicIp());
                });
            });

            //Number 8
            /*------------------------------------------------------------------------*/

            app.Command("screenshot", cmd =>
            {
                var link = cmd.Argument("link", "link to be screenshot").IsRequired();
                var format = cmd.Option("--format", "the format", CommandOptionType.SingleOrNoValue);
                var output = cmd.Option("--output", "the output", CommandOptionType.SingleOrNoValue);
                cmd.OnExecute(() =>
                {
                    if(format.HasValue() && output.HasValue())
                    {
                        Screenshot.GetScreenshot(link.Value, format.Value(), output.Value());
                    }
                    else if (format.HasValue())
                    {
                        Screenshot.GetScreenshot(link.Value, format.Value());
                    }
                    else if (output.HasValue())
                    {
                        Screenshot.GetScreenshot(link.Value, default, output.Value());
                    }
                    else
                    {
                        Screenshot.GetScreenshot(link.Value);
                    }
                });
            });
            return app.Execute(args);
        }
    }
}