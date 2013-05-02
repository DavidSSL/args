using System;

namespace Args.Examples
{
    class Program
    {
        [ArgsModel(SwitchDelimiter = "-")]
        public class CommandOption
        {
            public Uri OutputFilePath { get; set; }
            public string PatientId { get; set; }

            [ArgsMemberSwitch("d")]
            public bool IsDatabase { get; set; }
            [ArgsMemberSwitch("x")]
            public bool IsXml { get; set; }
        }

        static void Main(string[] args)
        {
            var command = Configuration.Configure<CommandOption>().CreateAndBind(args);

            Console.WriteLine(@"OutputFilePath: {0} 
PatientId: {1} 
IsDatabase: {2} 
IsXml: {3}"
                , command.OutputFilePath
                , command.PatientId
                , command.IsDatabase
                , command.IsXml);

            Console.ReadLine();
        }
    }
}
