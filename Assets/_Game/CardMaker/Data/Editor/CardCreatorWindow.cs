using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using log4net.Core;

public class CardCreatorWindow : EditorWindow
{
    [MenuItem("CardMaker/Create Card")]
    public static void ShowWindow()
    {
        GetWindow<CardCreatorWindow>("Card Creator");
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Card Object Creator", EditorStyles.boldLabel);
        if (GUILayout.Button("Create a Card Object."))
        {
            Debug.Log("Clone Should be Made");
        }
    }


}
