using System;
using System.Collections.Generic;
using System.Linq;

namespace DronovsCharts.Analyze
{
    class If:ComplexOperator
    {
        public If(string oprtr)
        {
            this.oprtr = oprtr;

            _operator = new COperator(OperatorType.If, GetCondition(oprtr));
            _operator.LeftText = "Да";
            _operator.RightText = "Нет";
            oprtr = oprtr.Substring(oprtr.BlockBeetweenEnd('(', ')')+1);
            
            oprtr = oprtr.Beetween("{","}");
            _operator.PLeft = CPPFileAnalyzer.AnalyzeBlock(oprtr);
        }



        public If Else(string o)
        {
            o = o.Substring("else ".Length).Trim();
            if (o.StartsWith("if"))
            {
                _operator.PRight = new List<COperator>();
                var i = new If(o);
                _operator.PRight.Add(i.GetOperator());
                return i;
            }
            if(o.StartsWith("{"))
                o = o.Beetween("{", "}");
            _operator.PRight = CPPFileAnalyzer.AnalyzeBlock(o);

            return null;
        }
    }
}
