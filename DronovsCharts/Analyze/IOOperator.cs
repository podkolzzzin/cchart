using System.Collections.Generic;

namespace DronovsCharts.Analyze
{
    class IOOperator
    {
        protected string _code;
        protected string[] _parts;
        protected List<COperator> _operators = new List<COperator>(); 
        public List<COperator> GetOperators()
        {
            return _operators;
        }
    }
}
