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

            return app.Execute(args);
        }
    }
}