using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGridTest
{
   public class DevAttribute
    {
        string attributeName;

        public string AttributeName
        {
            get { return attributeName; }
            set { attributeName = value; }
        }

        string attributeType;

        public string AttributeType
        {
            get { return attributeType; }
            set { attributeType = value; }
        }

        object attributeValue;

        public object AttributeValue
        {
            get { return attributeValue; }
            set { attributeValue = value; }
        }
    }
}
