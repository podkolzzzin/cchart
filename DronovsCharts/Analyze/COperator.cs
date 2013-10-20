using System.Collections.Generic;

namespace DronovsCharts.Analyze
{
    public enum OperatorType
    {
        StartEnd,
        Output,
        Input,
        If,
        Action,
        Switch,
        Case,
        Cycle
    }
    public class COperator
    {
        private OperatorType _operatorType;
        private readonly string _text;
        public List<COperator> PLeft { get; set; }
        public List<COperator> PRight { get; set; }
        public List<COperator> PDown { get; set; }
        public List<COperator> PDefault { get; set; }
        public string LeftText { get; set; }
        public string RightText { get; set; }
        public OperatorType Type { get { return _operatorType; } }
        public string Text { get { return _text; } }

        public COperator(OperatorType operatorType, string text)
        {
            this._operatorType = operatorType;
            _text = text;
        }

        public static COperator Start
        {
            get
            {
                return new COperator(OperatorType.StartEnd, "Начало");
            }     
        }

        public static COperator End
        {
            get
            {
                return new COperator(OperatorType.StartEnd, "Конец");
            }
        }

        public override string ToString()
        {
            return _operatorType.ToString() + " " + _text;
        }
    }
}
