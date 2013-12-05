using System;
using System.Collections.Generic;

namespace DronovsCharts.Analyze
{
    public class CPPFileAnalyzer
    {
        private string _code;
        private List<COperator> _result = new List<COperator>();

        public List<COperator> Result
        {
            get { return _result; }
        }

        public CPPFileAnalyzer(string code)
        {
            _findMain(code);
        }

        private CPPFileAnalyzer()
        {

        }

        public static List<COperator> AnalyzeBlock(string code)
        {
            var t = new CPPFileAnalyzer();
            t._blockAnalyzer(code.OperatorSplit());
            return t._result;
        }

        private void _findMain(string code)
        {
            code = code.Trim(' ', '\n', '\r', '\t');
            var main = code.Substring(code.IndexOf("main()") + 6);
            main = main.Substring(main.IndexOf('{') + 1);

            var oprtrs = main.OperatorSplit();



            _result.Add(COperator.Start);

            _blockAnalyzer(oprtrs);

            _result.Add(COperator.End);
            Console.WriteLine(_result.ToArrStr());
        }

        private void _blockAnalyzer(IEnumerable<string> oprtrs)
        {
            If sIf = null;
            foreach (var oprtr in oprtrs)
            {
                if (oprtr.StartsWith("cout") || oprtr.StartsWith("printf"))
                {
                    _result.AddRange(new Cout(oprtr).GetOperators());
                }
                else if (oprtr.StartsWith("cin"))
                {
                    _result.AddRange(new Cin(oprtr).GetOperators());
                }
                else if (oprtr.StartsWith("if"))
                {
                    sIf = new If(oprtr);
                    _result.Add(sIf.GetOperator());
                }
                else if (oprtr.StartsWith("for", "while"))
                {
                    _result.Add(new Cycle(oprtr).GetOperator());
                }
                else if (oprtr.StartsWith("else"))
                {
                    sIf = sIf.Else(oprtr);
                }
                else if (oprtr.StartsWith("switch"))
                {
                    _result.Add(new Switch(oprtr).GetOperator());
                }
                else if (oprtr.StartsWith("int", "double", "float", "char", "bool", "long int", "unsigned int", "unsigned long",
                                          "long doble", "break", "continue", "const", "SetConsole"))
                {
                    
                }
                else
                {
                    _result.Add(new COperator(OperatorType.Action, oprtr));
                }
            }
        }

    }
}
