namespace DronovsCharts.Analyze
{
    class ComplexOperator
    {
        protected string oprtr;
        protected COperator _operator;


        public COperator GetOperator()
        {
            return _operator;
        }

        public static string GetCondition(string code)
        {
            return code.Beetween("(",")");
        }
    }
}
