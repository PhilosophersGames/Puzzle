using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(AchievementDatabase))]
public class AchievementDataBaseEditor : Editor
{
    private AchievementDatabase database;

    private void OnEnable()
    {
       database = target as AchievementDatabase;
    }

//Create an inspector button
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Generate Enum", GUILayout.Height(30)))
        {
            GenerateEnum();
        }

    }

    private void GenerateEnum()
    {
        string filePath = Path.Combine(Application.dataPath, "Resources/Achievements/Achievement Scripts/Achievements.cs");
        string code = "public enum Achievements {";
        foreach (Achievement achievement in database.achievements)
        {
            //
            code += achievement.id + ",";
        }
        code += "}";
        File.WriteAllText(filePath, code);
        AssetDatabase.ImportAsset("Assets/Resources/Achievements/Achievement Scripts/Achievement.cs");
    }
}