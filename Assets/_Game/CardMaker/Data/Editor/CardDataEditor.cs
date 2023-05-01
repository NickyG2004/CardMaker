using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

[CustomEditor(typeof(CardData))]

public class CardDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        CardData data = (CardData)target;

        EditorGUILayout.LabelField(data.Name.ToUpper(), EditorStyles.boldLabel);
        EditorGUILayout.Space(10);

        // Add before.

        base.OnInspectorGUI();

        // Add after.
        EditorGUILayout.Space(20);
        EditorGUILayout.LabelField("CARD STATS: ", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Card Name: " + data.Name, EditorStyles.whiteLabel);
        EditorGUILayout.LabelField("Card Type: " + data.CardType, EditorStyles.whiteLabel);
        EditorGUILayout.LabelField("Card Attribute: " + data.CardAttribute, EditorStyles.whiteLabel);
        EditorGUILayout.LabelField("Attack Points: " + data.AttackPoints, EditorStyles.whiteLabel);
        EditorGUILayout.LabelField("Defence Points: " + data.DefencePoints, EditorStyles.whiteLabel);
        EditorGUILayout.LabelField("Level: " + data.Level, EditorStyles.whiteLabel);

        if (data.Name == string.Empty)
        {
            EditorGUILayout.HelpBox("Warrning: No name specified. Please name the Card!", MessageType.Error);
        }

        if (data.Name == "...")
        {
            EditorGUILayout.HelpBox("Caution: default name placeholder still in place. Please name the Card!", MessageType.Warning);
        }

        if (data.CardType == CardType.None)
        {
            EditorGUILayout.HelpBox("Warrning: No card type specified. Please Choose a Type!", MessageType.Error);
        }

        if (data.CardAttribute == CardAttribute.None)
        {
            EditorGUILayout.HelpBox("Warrning: No card attribute specified. Please Choose an Attribute!", MessageType.Error);
        }

        if (data.CardFront == null)
        {
            EditorGUILayout.HelpBox("Warrning: No card front material specified. Please Input a Material!", MessageType.Error);
        }

        if (data.CardBack == null)
        {
            EditorGUILayout.HelpBox("Warrning: No card back material specified. Please Input a Material!", MessageType.Error);
        }

        if (data.CardBackFlipAnimation == null)
        {
            EditorGUILayout.HelpBox("Warrning: No card flip to front animation specified. Please Input an Animation Clip!", MessageType.Error);
        }

        if (data.CardBackFlipAnimation == null)
        {
            EditorGUILayout.HelpBox("Warrning: No card flip to back animation specified. Please Input an Animation Clip!", MessageType.Error);
        }

        if (data.CardLossEffect == null)
        {
            EditorGUILayout.HelpBox("Warrning: No card loss effect specified. Please Input a Partical Effect!", MessageType.Error);
        }

        if (data.CardWinEffect == null)
        {
            EditorGUILayout.HelpBox("Warrning: No card win effect specified. Please Input a Partical Effect!", MessageType.Error);
        }

        if (data.CardFlipSound == null)
        {
            EditorGUILayout.HelpBox("Warrning: No card flip sound specified. Please Input an Audio Source!", MessageType.Error);
        }

        if (data.CardWinSound == null)
        {
            EditorGUILayout.HelpBox("Warrning: No card win sound specified. Please Input an Audio Source!", MessageType.Error);
        }

        if (data.CardLoseSound == null)
        {
            EditorGUILayout.HelpBox("Warrning: No card loss sound specified. Please Input an Audio Source!", MessageType.Error);
        }

        if (data.AttackPoints < 0)
        {
            EditorGUILayout.HelpBox("Warrning: Attack point can not be a negitive value, Plase enter a positive number!", MessageType.Error);
        }

        if (data.DefencePoints < 0)
        {
            EditorGUILayout.HelpBox("Warrning: Defence point can not be a negitive value, Plase enter a positive number!", MessageType.Error);
        }
    }
}
