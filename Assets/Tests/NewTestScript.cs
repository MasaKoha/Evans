using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Evans.Utility;
using Evans.Core;
using System;

namespace Evans.Core
{
    [Serializable]
    public class SampleClass
    {
        public string name;
        public long number;
        public float height;
        public float weight;
        public string feature;
    }

    public class EvansTest
    {
        private string _csvText = "";
        private string _targetJsonText = "";

        [SetUp]
        public void ReadFile()
        {
            _csvText = FileLoader.LoadSampleCsv();
            _targetJsonText = FileLoader.LoadTargetJson();
        }

        [Test]
        public void CSVToJsonConvertTest()
        {
            var json = CSVToJson.Convert(_csvText);
            Assert.AreEqual(_targetJsonText, json);
        }

        [Test]
        public void ConvertJsonUtilityTest()
        {
            var json = JsonHelper.ConvertIntoJsonUtility(_csvText);
            var sample = JsonHelper.GetListFromJson<SampleClass>(json);
            Assert.Pass();
        }

        [Test]
        public void GetSampleValueTest()
        {
            var json = JsonHelper.ConvertIntoJsonUtility(_csvText);
            var sample = JsonHelper.GetListFromJson<SampleClass>(json);
            Assert.AreEqual("sato", sample[0].name);
            Assert.AreEqual(90, sample[0].weight);
            Assert.AreEqual("13", sample[3].feature);
            Assert.AreEqual("", sample[4].feature);
        }
    }
}