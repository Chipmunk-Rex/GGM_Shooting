using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

    [CustomEditor(typeof(TestMono))]
public class CustomTestMono : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("myButton"))
        {
            TestMono mono = target as TestMono;
            mono.TestMethod();
        }
    }
}
