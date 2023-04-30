using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SeparatorAttribute))]
public class SeparatorDrawer : DecoratorDrawer
{
    public override void OnGUI(Rect position)
    {
        // Get a refrence to the attribute
        
        SeparatorAttribute separatorAttribute = attribute as SeparatorAttribute;

        // Define the line to draw 

        Rect separatorRect = new Rect(position.xMin, position.yMin + 
                separatorAttribute.Spacing, position.width, separatorAttribute.Height);

        // Draw it

        EditorGUI.DrawRect(separatorRect, Color.white);
    }

    public override float GetHeight()
    {
        SeparatorAttribute separatorAttribute = attribute as SeparatorAttribute;

        float totalSpacing = separatorAttribute.Spacing 
            + separatorAttribute.Height 
            + separatorAttribute.Spacing;

        return totalSpacing;
    }
}
