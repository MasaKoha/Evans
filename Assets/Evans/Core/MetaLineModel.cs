using System.Collections.Generic;
using System.Linq;
using Evans.Utility;

namespace Evans.Core
{
    internal class MetaLineModel
    {
        private Dictionary<string, string> _keyValues;

        public readonly string Display;

        public MetaLineModel(string[] keys, string[] values)
        {
            _keyValues = new Dictionary<string, string>();

            for (int i = 0; i < keys.Length; i++)
            {
                _keyValues.Add(keys[i], values[i]);
            }

            var keyValues = _keyValues.ToArray();

            Display += EvansConst.Indent + "{\n";
            var lastIndex = keyValues.Length - 1;

            for (int i = 0; i < keyValues.Length; i++)
            {
                var value = keyValues[i].Value;
                long longValue = 0;
                float floatValue = 0;
                bool isLong = long.TryParse(value, out longValue);
                bool isFloat = float.TryParse(value, out floatValue);

                if (isFloat)
                {
                    value = floatValue.ToString();
                }

                if (isLong)
                {
                    value = longValue.ToString();

                }

                var tmpValue = value;

                if (!isLong && !isFloat)
                {
                    tmpValue = $"\"{value}\"";
                }

                Display += $"{EvansConst.Indent}{EvansConst.Indent}\"{keyValues[i].Key}\": {tmpValue}";

                if (i != lastIndex)
                {
                    Display += ",\n";
                }
                else
                {
                    Display += "\n";
                }
            }

            Display += EvansConst.Indent + "}";
        }
    }
}