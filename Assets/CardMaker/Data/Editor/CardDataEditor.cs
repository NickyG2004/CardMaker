using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using log4net.Core;
using UnityEditor.Rendering;
using System.Diagnostics;

[CustomEditor(typeof(CardData))]

public class CardDataEditor : Editor
{
    private SerializedProperty _cardName;
    private SerializedProperty _cardType;
    private SerializedProperty _cardAttribute;
    private SerializedProperty _cardFront;
    private SerializedProperty _cardBack;
    // private SerializedProperty _cardFrontFlipAnimation;
    // private SerializedProperty _cardBackFlipAnimation;
    private SerializedProperty _cardLoseEffect;
    private SerializedProperty _cardWinEffect;
    private SerializedProperty _cardFlipSound;
    private SerializedProperty _cardWinSound;
    private SerializedProperty _cardLoseSound;
    private SerializedProperty _attackPoints;
    private SerializedProperty _defencePoints;
    private SerializedProperty _level;
    private SerializedProperty _showStats;
    private SerializedProperty _isPositive;
    private SerializedProperty _isNegitive;
    private SerializedProperty _modValue;

    private void OnEnable()
    {
        _cardName = serializedObject.FindProperty("_cardName");
        _cardType = serializedObject.FindProperty("_cardType");
        _cardAttribute = serializedObject.FindProperty("_cardAttribute");
        _cardFront = serializedObject.FindProperty("_cardFront");
        _cardBack = serializedObject.FindProperty("_cardBack");
        // _cardFrontFlipAnimation = serializedObject.FindProperty("_cardFrontFlipAnimation");
        // _cardBackFlipAnimation = serializedObject.FindProperty("_cardBackFlipAnimation");
        _cardLoseEffect = serializedObject.FindProperty("_cardLoseEffect");
        _cardWinEffect = serializedObject.FindProperty("_cardWinEffect");
        _cardFlipSound = serializedObject.FindProperty("_cardFlipSound");
        _cardWinSound = serializedObject.FindProperty("_cardWinSound");
        _cardLoseSound = serializedObject.FindProperty("_cardLoseSound");
        _attackPoints = serializedObject.FindProperty("_attackPoints");
        _defencePoints = serializedObject.FindProperty("_defencePoints");
        _level = serializedObject.FindProperty("_level");
        _showStats = serializedObject.FindProperty("_showStats");
        _isPositive = serializedObject.FindProperty("_isPositive");
        _isNegitive = serializedObject.FindProperty("_isNegitive");
        _modValue = serializedObject.FindProperty("_modValue");

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

             //EditorGUILayout.PropertyField(_cardFrontFlipAnimation, new GUIContent("Card flip to front Animation"));
             //if (_cardFrontFlipAnimation == null)
            // {
            //     EditorGUILayout.HelpBox("Warrning: No card flip to front animation specified. Please Input an Animation Clip!", MessageType.Error);
            // }

            // EditorGUILayout.PropertyField(_cardBackFlipAnimation, new GUIContent("Card flip to back Animation"));
            // if (_cardBackFlipAnimation == null)
            // {
              //   EditorGUILayout.HelpBox("Warrning: No card flip to back animation specified. Please Input an Animation Clip!", MessageType.Error);
            // }

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
            if (_attackPoints.intValue % 100 != 0)
            {
                _attackPoints.intValue = RoundValue(_attackPoints.intValue);
            }
            if (_attackPoints.intValue < 0)
            {
                EditorGUILayout.HelpBox("Warrning: Attack point can not be a negitive value, Plase enter a positive number!", MessageType.Error);
            }

            EditorGUILayout.PropertyField(_defencePoints, new GUIContent("Defence Points"));
            if (_defencePoints.intValue % 100 != 0)
            {
                _defencePoints.intValue = RoundValue(_defencePoints.intValue);
            }
            if (_defencePoints.intValue < 0)
            {
                EditorGUILayout.HelpBox("Warrning: Defence point can not be a negitive value, Plase enter a positive number!", MessageType.Error);
            }

            EditorGUILayout.HelpBox("Note: Inputed values will be rounded down to nearest hundreds place.", MessageType.Info);

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
                EditorGUILayout.LabelField("Card Type: " + getCardType(_cardType.intValue), EditorStyles.whiteLabel);
                EditorGUILayout.LabelField("Card Attribute: " + getAttribute(_cardAttribute.intValue), EditorStyles.whiteLabel);
                EditorGUILayout.LabelField("Attack Points: " + _attackPoints.intValue, EditorStyles.whiteLabel);
                EditorGUILayout.LabelField("Defence Points: " + _defencePoints.intValue, EditorStyles.whiteLabel);
                EditorGUILayout.LabelField("Level: " + _level.intValue, EditorStyles.whiteLabel);
                EditorGUI.indentLevel--;
            }
        }

        if (_cardType.intValue == 2)
        {
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

            // EditorGUILayout.PropertyField(_cardFrontFlipAnimation, new GUIContent("Card flip to front Animation"));
            // if (_cardFrontFlipAnimation == null)
            // {
             //    EditorGUILayout.HelpBox("Warrning: No card flip to front animation specified. Please Input an Animation Clip!", MessageType.Error);
            // }

            // EditorGUILayout.PropertyField(_cardBackFlipAnimation, new GUIContent("Card flip to back Animation"));
            // if (_cardBackFlipAnimation == null)
            // {
            //     EditorGUILayout.HelpBox("Warrning: No card flip to back animation specified. Please Input an Animation Clip!", MessageType.Error);
           // }

            EditorGUI.indentLevel--;
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Card Audio Data", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;

            EditorGUILayout.PropertyField(_cardFlipSound, new GUIContent("Card Flip Sound"));
            if (_cardFlipSound == null)
            {
                EditorGUILayout.HelpBox("Warrning: No card flip sound specified. Please Input an Audio Source!", MessageType.Error);
            }

            EditorGUI.indentLevel--;
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Card Modifier Stats", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;
            EditorGUIUtility.labelWidth = 110;
            EditorGUILayout.PropertyField(_isPositive, new GUIContent("Is Buff Value"));
            EditorGUILayout.PropertyField(_isNegitive, new GUIContent("Is Debuff Value"));
            if (_isNegitive.boolValue == false && _isPositive.boolValue == false)
            {
                EditorGUILayout.HelpBox("Warrning: No Modifier Direction selected, Please check a Box", MessageType.Error);
            }

            if (_isNegitive.boolValue == false || _isPositive.boolValue == false)
            {
                EditorGUILayout.HelpBox("Note: No only one box may be checked at a time.", MessageType.Info);
            }

            if (_isNegitive.boolValue == true && _isPositive.boolValue == true)
            {
                _isNegitive.boolValue = false;
                _isPositive.boolValue = false;
            }

            EditorGUIUtility.labelWidth = 0;
            EditorGUILayout.PropertyField(_modValue, new GUIContent("Modifier Magnitude"));
            if (_modValue.intValue % 100 != 0)
            {
                _modValue.intValue = RoundValue(_modValue.intValue);
            }
            if (GUILayout.Button("Random Mod Magnitude"))
            {
                RandomizeMod();
            }
            if (_modValue.intValue < 0)
            {
                EditorGUILayout.HelpBox("Warrning: Modifier Magnitude can not be a negitive value, Plase enter a positive number!", MessageType.Error);
            }
            if (_modValue.intValue == 0)
            {
                EditorGUILayout.HelpBox("Warrning: Modifier Magnitude can not be a Equal to Zero, Plase enter a value greater then zero!", MessageType.Error);
            }

            EditorGUI.indentLevel--;

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
                EditorGUILayout.LabelField("Card Type: " + getCardType(_cardType.intValue), EditorStyles.whiteLabel);
                EditorGUILayout.LabelField("Modifire Direction: " + getModType(_isPositive.boolValue, _isNegitive.boolValue), EditorStyles.whiteLabel);
                EditorGUILayout.LabelField("Modifire Magnitude: " + _modValue.intValue, EditorStyles.whiteLabel);
                EditorGUI.indentLevel--;
                
            }
        }

        serializedObject.ApplyModifiedProperties();
    }

    void RandomizeStats()
    {
        _attackPoints.intValue = UnityEngine.Random.Range(0, 4099);
        _attackPoints.intValue = RoundValue(_attackPoints.intValue);

        _defencePoints.intValue = UnityEngine.Random.Range(0, 4099);
        _defencePoints.intValue = RoundValue(_defencePoints.intValue);

        _level.intValue = UnityEngine.Random.Range(1, 10);
    }

    void RandomizeMod()
    {
        _modValue.intValue = UnityEngine.Random.Range(100, 1099);
        _modValue.intValue = RoundValue(_modValue.intValue);
    }

    int RoundValue(int value)
    {
        value /= 100;
        value *= 100;
        return value;
    }
    string getAttribute(int value)
    {
        string AttributeName = "";

        switch (value)
        {
            case 1:
                AttributeName = "Air";
                break;
            case 2:
                AttributeName = "Earth";
                break;
            case 3:
                AttributeName = "Fire";
                break;
            case 4:
                AttributeName = "Water";
                break;
            case 5:
                AttributeName = "Light";
                break;
            case 6:
                AttributeName = "Dark";
                break;
            default:
                AttributeName = "None";
                break;
        }
        return AttributeName;
    }
    string getCardType(int value)
    {
        string cardType = "";

        switch (value)
        {
            case 1:
                cardType = "Monster";
                break;
            case 2:
                cardType = "Modifier";
                break;
            default:
                cardType = "None";
                break;
        }
        return cardType;
    }

    string getModType(bool buff, bool debuff)
    {
        string modType = "";

        if(buff == true)
        {
            modType = "Buff";
        }
        else if(debuff == true) 
        {
            modType = "DeBuff";
        }
        else
        {
            modType = "Undecided";
        }

        return modType;
    }
}
