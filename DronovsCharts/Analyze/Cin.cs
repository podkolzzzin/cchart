using System;
using System.Linq;

namespace DronovsCharts.Analyze
{
    class Cin: IOOperator
    {
        public Cin(string code)
        {
            _parts = code.Split(new string[] {">>"},StringSplitOptions.None);
            var t = _parts.ToList();
            t.RemoveAt(0);
            _parts = t.ToArray();
            _operators.Add(new COperator(OperatorType.Input, _parts.ToSpecString(',')));
        }
    }
}
