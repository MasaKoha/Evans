using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Evans.Core;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Evans.Editor
{
    public class EvansWindow : EditorWindow
    {
        [MenuItem("Window/Evans/CSV2Json")]
        private static void Create()
        {
            GetWindow<EvansWindow>("Evans");
        }

        public Object _source;

        private string _folderPath;

        private void OnGUI()
        {
            GUILayout.Label("Target Converted csv File");
            _source = EditorGUILayout.ObjectField(_source, typeof(TextAsset), true);

            if (GUILayout.Button("Target Save Json Path"))
            {
                _folderPath = EditorUtility.OpenFolderPanel("Save Json", "Assets", _source.name);
            }

            var filePath = Path.Combine(_folderPath + "/", _source.name + ".json");

            GUILayout.Label($"TargetFolder : {_folderPath}");

            if (GUILayout.Button("Convert!!"))
            {
                if (string.IsNullOrWhiteSpace(_folderPath))
                {
                    Debug.LogError("Please select a target folder.");
                    return;
                }

                var csvText = ((TextAsset) _source).text;
                var json = CSVToJson.Convert(csvText);

                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    streamWriter.Write(json);
                }
                
                Debug.Log("Completed!");
                AssetDatabase.Refresh();
            }
        }
    }
}