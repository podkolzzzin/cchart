using System;
using System.Linq;

namespace DronovsCharts.Analyze
{
    class Cout : IOOperator
    {
        public Cout(string code)
        {
            _code = code;
            if (code.StartsWith("cout<<"))
                _coutContr();
            else
                _printfConstr();
        }

        private void _printfConstr()
        {
            _code = _code.Substring("printf(".Length);
            _code = _code.Substring(0,_code.IndexOf(")"));
            var t = _code.Split(',');
            _operators.Add(new COperator(OperatorType.Output, string.Join(",", t, 1, t.Length - 1)));
        }

        private void _coutContr()
        {
            _parts = _code.Split(new string[] { "<<" }, StringSplitOptions.None);
            if (_parts.Length == 2)
            {
                _operators.Add(new COperator(OperatorType.Output, _parts[1]));
            }
            else
            {
                if (_parts.Length == 3 && _parts.Last() == "endl") 
                    _operators.Add(new COperator(OperatorType.Output, _parts[1]));
                else
                    _operators.Add(new COperator(OperatorType.Output, _code));
            }
        }

    }
}
