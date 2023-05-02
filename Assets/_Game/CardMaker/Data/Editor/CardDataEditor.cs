using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using log4net.Core;
using UnityEditor.Rendering;

[CustomEditor(typeof(CardData))]

public class CardDataEditor : Editor
{
    private SerializedProperty _cardName;
    private SerializedProperty _cardType;
    private SerializedProperty _cardAttribute;
    private SerializedProperty _cardFront;
    private SerializedProperty _cardBack;
    private SerializedProperty _cardFrontFlipAnimation;
    private SerializedProperty _cardBackFlipAnimation;
    private SerializedProperty _cardLoseEffect;
    private SerializedProperty _cardWinEffect;
    private SerializedProperty _cardFlipSound;
    private SerializedProperty _cardWinSound;
    private SerializedProperty _cardLoseSound;
    private SerializedProperty _attackPoints;
    private SerializedProperty _defencePoints;
    private SerializedProperty _level;
    private SerializedProperty _showStats;

    private void OnEnable()
    {
        _cardName = serializedObject.FindProperty("_cardName");
        _cardType = serializedObject.FindProperty("_cardType");
        _cardAttribute = serializedObject.FindProperty("_cardAttribute");
        _cardFront = serializedObject.FindProperty("_cardFront");
        _cardBack = serializedObject.FindProperty("_cardBack");
        _cardFrontFlipAnimation = serializedObject.FindProperty("_cardFrontFlipAnimation");
        _cardBackFlipAnimation = serializedObject.FindProperty("_cardBackFlipAnimation");
        _cardLoseEffect = serializedObject.FindProperty("_cardLoseEffect");
        _cardWinEffect = serializedObject.FindProperty("_cardWinEffect");
        _cardFlipSound = serializedObject.FindProperty("_cardFlipSound");
        _cardWinSound = serializedObject.FindProperty("_cardWinSound");
        _cardLoseSound = serializedObject.FindProperty("_cardLoseSound");
        _attackPoints = serializedObject.FindProperty("_attackPoints");
        _defencePoints = serializedObject.FindProperty("_defencePoints");
        _level = serializedObject.FindProperty("_level");
        _showStats = serializedObject.FindProperty("_showStats");

    }

    public override void OnInspectorGUI()
    {
        // CardData data = (CardData)target;

        serializedObject.UpdateIfRequiredOrScript();

        EditorGUILayout.LabelField(_cardName.stringValue.ToUpper(), EditorStyles.boldLabel);
        EditorGUILayout.Space(10);

        // Add before.

        // base.OnInspectorGUI();

        // Custom GUI

        EditorGUILayout.LabelField("General Card Information", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;
        EditorGUILayout.PropertyField(_cardName, new GUIContent("Card Name"));
        if (_cardName.stringValue == string.Empty)
        {
            EditorGUILayout.HelpBox("Warrning: No name specified. Please name the Card!", MessageType.Error);
        }

        if (_cardName.stringValue == "...")
        {
            EditorGUILayout.HelpBox("Caution: default name placeholder still in place. Please name the Card!", MessageType.Warning);
        }

        EditorGUILayout.PropertyField(_cardType, new GUIContent("Card Type"));
        if (_cardType.intValue == 0)
        {
            EditorGUILayout.HelpBox("Warrning: No card type specified. Please Choose a Type!", MessageType.Error);
        }

        EditorGUI.indentLevel--;


        if (_cardType.intValue == 1)
        {
            EditorGUI.indentLevel++;

            EditorGUILayout.PropertyField(_cardAttribute, new GUIContent("Card Attribute"));
            if (_cardAttribute.intValue == 0)
            {
                EditorGUILayout.HelpBox("Warrning: No card attribute specified. Please Choose an Attribute!", MessageType.Error);
            }

            EditorGUI.indentLevel--;
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Card Visual Data", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;

            EditorGUILayout.PropertyField(_cardFront, new GUIContent("Card Front Texture"));
            if (_cardFront == null)
            {
                EditorGUILayout.HelpBox("Warrning: No card front texture specified. Please Input a Texture!", MessageType.Error);
            }

            EditorGUILayout.PropertyField(_cardBack, new GUIContent("Card Back Texture"));
            if (_cardBack == null)
            {
                EditorGUILayout.HelpBox("Warrning: No card back texture specified. Please Input a Texture!", MessageType.Error);
            }

            EditorGUILayout.PropertyField(_cardFrontFlipAnimation, new GUIContent("Card flip to front Animation"));
            if (_cardFrontFlipAnimation == null)
            {
                EditorGUILayout.HelpBox("Warrning: No card flip to front animation specified. Please Input an Animation Clip!", MessageType.Error);
            }

            EditorGUILayout.PropertyField(_cardBackFlipAnimation, new GUIContent("Card flip to back Animation"));
            if (_cardBackFlipAnimation == null)
            {
                EditorGUILayout.HelpBox("Warrning: No card flip to back animation specified. Please Input an Animation Clip!", MessageType.Error);
            }

            EditorGUILayout.PropertyField(_cardLoseEffect, new GUIContent("Card Lose Effect"));
            if (_cardLoseEffect == null)
            {
                EditorGUILayout.HelpBox("Warrning: No card loss effect specified. Please Input a Partical Effect!", MessageType.Error);
            }

            EditorGUILayout.PropertyField(_cardWinEffect, new GUIContent("Card Win Effect"));
            if (_cardWinEffect == null)
            {
                EditorGUILayout.HelpBox("Warrning: No card win effect specified. Please Input a Partical Effect!", MessageType.Error);
            }

            EditorGUI.indentLevel--;
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Card Audio Data", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;

            EditorGUILayout.PropertyField(_cardFlipSound, new GUIContent("Card Flip Sound"));
            if (_cardFlipSound == null)
            {
                EditorGUILayout.HelpBox("Warrning: No card flip sound specified. Please Input an Audio Source!", MessageType.Error);
            }

            EditorGUILayout.PropertyField(_cardWinSound, new GUIContent("Card Win Sound"));
            if (_cardWinSound == null)
            {
                EditorGUILayout.HelpBox("Warrning: No card win sound specified. Please Input an Audio Source!", MessageType.Error);
            }

            EditorGUILayout.PropertyField(_cardLoseSound, new GUIContent("Card Lose Sound"));
            if (_cardLoseSound == null)
            {
                EditorGUILayout.HelpBox("Warrning: No card loss sound specified. Please Input an Audio Source!", MessageType.Error);
            }

            EditorGUI.indentLevel--;
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Card Combat Stats", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;

            EditorGUILayout.PropertyField(_attackPoints, new GUIContent("Attack Points"));
            if (_attackPoints.intValue < 0)
            {
                EditorGUILayout.HelpBox("Warrning: Attack point can not be a negitive value, Plase enter a positive number!", MessageType.Error);
            }

            EditorGUILayout.PropertyField(_defencePoints, new GUIContent("Defence Points"));
            if (_defencePoints.intValue < 0)
            {
                EditorGUILayout.HelpBox("Warrning: Defence point can not be a negitive value, Plase enter a positive number!", MessageType.Error);
            }

            EditorGUILayout.PropertyField(_level, new GUIContent("Card Level"));

            if (GUILayout.Button("Random Stats"))
            {
                RandomizeStats();
            }

            EditorGUI.indentLevel--;
            EditorGUILayout.Space();
            EditorGUIUtility.labelWidth = 70;
            EditorGUILayout.PropertyField(_showStats, new GUIContent("Show Stats"));

            // Add after.
            if (_showStats.boolValue == true)
            {
                
                EditorGUILayout.Space(20);
                EditorGUILayout.LabelField("CARD STATS: ", EditorStyles.boldLabel);
                EditorGUI.indentLevel++;
                EditorGUILayout.LabelField("Card Name: " + _cardName.stringValue, EditorStyles.whiteLabel);
                EditorGUILayout.LabelField("Card Type: " + _cardType, EditorStyles.whiteLabel);
                EditorGUILayout.LabelField("Card Attribute: " + _cardAttribute, EditorStyles.whiteLabel);
                EditorGUILayout.LabelField("Attack Points: " + _attackPoints.intValue, EditorStyles.whiteLabel);
                EditorGUILayout.LabelField("Defence Points: " + _defencePoints.intValue, EditorStyles.whiteLabel);
                EditorGUILayout.LabelField("Level: " + _level.intValue, EditorStyles.whiteLabel);
                EditorGUI.indentLevel--;
            }
        }

        serializedObject.ApplyModifiedProperties();
    }

    void RandomizeStats()
    {
        _attackPoints.intValue = UnityEngine.Random.Range(0, 4000);
        _defencePoints.intValue = UnityEngine.Random.Range(0, 4000);
        _level.intValue = UnityEngine.Random.Range(1, 10);
    }
}
