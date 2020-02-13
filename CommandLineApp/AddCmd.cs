using McMaster.Extensions.CommandLineUtils;
using System;
using System.ComponentModel.DataAnnotations;

//namespace CommandLineApp
//{
//    [HelpOption("--help")]
//    public class AddCmd
//    {
//        [Required]
//        [Option("--addParam1", Description = "1st parameter for add")]
//        public string AddParam1 { get; set; }

//        [Required]
//        [Option("--addParam2", Description = "2nd parameter for add")]
//        public MyEnum AddParam2 { get; set; }

//        public void OnExecute()
//        {
//            // do work, AddParam1 and AddParam2 (enum auto-parsed) available here
//        }
//    }
//}