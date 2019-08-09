using System.Collections.Generic;

namespace Evans.Core
{
    public static class CSVToJson
    {
        public static string Convert(string csvText)
        {
            var textLines = csvText.Replace("\r\n", "\n").Split('\n');
            var keys = textLines[0].Split(',');

            var lineModel = new List<MetaLineModel>();

            for (var i = 1; i < textLines.Length; i++)
            {
                if (textLines[i].Length == 0)
                {
                    continue;
                }

                var values = textLines[i].Split(',');
                lineModel.Add(new MetaLineModel(keys, values));
            }

            var str = "";
            str += "[\n";
            var lastIndex = lineModel.Count - 1;
            for (var i = 0; i < lineModel.Count; i++)
            {
                str += lineModel[i].Display;
                if (i != lastIndex)
                {
                    str += ",\n";
                }
                else
                {
                    str += "\n";
                }
            }

            str += "]";
            return str;
        }
    }
}