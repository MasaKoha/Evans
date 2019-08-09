using UnityEngine;

namespace Evans.Utility
{
    public static class FileLoader
    {
        public static string LoadSampleCsv()
        {
            return LoadTextFile("Sample");
        }

        public static string LoadTargetJson()
        {
            return LoadTextFile("Target");
        }

        private static string LoadTextFile(string path)
        {
            return Resources.Load<TextAsset>(path).text;
        }
    }
}