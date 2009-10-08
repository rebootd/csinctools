using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationCriteria
{
    public class Expression
    {
        private string fieldName;
        private object fieldValue;

        public string FieldName
        {
            get { return fieldName; }
            set { fieldName = value; }
        }

        public object FieldValue
        {
            get { return fieldValue; }
            set { fieldValue = value; }
        }

        public Expression() { }

        public Expression(string field, object val)
        {
            fieldName = field;
            this.fieldValue = val;
        }
    }
}
