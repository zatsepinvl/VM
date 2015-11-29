using System;
using System.Text.RegularExpressions;
namespace VM
{
    class Parser
    {
        public const string DEFAULT_WHITESPACES = " \n\r\t";
        public Code Code { get; private set; }
        public int EntryPoint { get; private set; }

        private int pointer;

        string source;
        string[] tokens;
        public Parser(string source)
        {
            EntryPoint = 0;
            Code = new Code();
            this.source = source;
            pointer = 0;
            try
            {
                foreach (Match match in Regex.Matches(source, @"[A-Z,a-z]+\s+((\d+)|([A-Z,a-z]+)|(\"".+\""))"))
                {
                    MatchCollection temp = Regex.Matches(match.Value, @"([A-Z,a-z]+)|((\d+)|([A-Z,a-z]+)|(\"".+\""))");
                    CodeCommand command;
                    command.Name = temp[0].Value;
                    command.Arg = temp[1].Value;
                    Code.AddCommand(command);
                }
            }
            catch (Exception ex)
            {
                throw new ParserException("invalid input");
            }
        }

        private void ParseEntryPoint()
        {
            try
            {
                EntryPoint = Int32.Parse(tokens[pointer]);
                pointer++;
            }
            catch { }
        }

    }
}
