using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DronovsCharts.Analyze
{
    class Cycle:ComplexOperator
    {
        public Cycle(string code)
        {
            int end = code.BlockBeetweenEnd('(', ')') + 1;
            _operator = new COperator(OperatorType.Cycle,code.Substring(0, end));
            code = code.Substring(end).BlockBeetween('{','}');
            _operator.PDown = CPPFileAnalyzer.AnalyzeBlock(code);
        }
    }
}
