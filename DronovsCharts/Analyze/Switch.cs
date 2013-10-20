using System;
using System.Collections.Generic;

namespace DronovsCharts.Analyze
{
    class Switch:ComplexOperator
    {
        public Switch(string oprtr)
        {
            this.oprtr = oprtr;
            this._operator = new COperator(OperatorType.Switch, GetCondition(oprtr));
            _parseCases();
        }

        private void _parseCases()
        {
            var t = oprtr.Beetween("{", "}");
            var operators = t.Split(new string[] { "default:" }, StringSplitOptions.RemoveEmptyEntries);
            if(operators.Length>1)
                _operator.PDefault = CPPFileAnalyzer.AnalyzeBlock(operators[1]);
            else
            {
                _operator.PDefault = new List<COperator>();
            }
            _operator.LeftText = operators[0];
            _operator.PDown = new List<COperator>();
            var cases = operators[0].Split(new string[] { "case "}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var o in cases)
            {
                var parts = o.Split(':');
                if(parts.Length<2) continue;
                COperator c = new COperator(OperatorType.Case, parts[0])
                    {
                        PLeft = CPPFileAnalyzer.AnalyzeBlock(parts[1])
                    };

                _operator.PDown.Add(c);
            }        
        }
    }
}
