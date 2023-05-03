using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Rendering;

public class Card : MonoBehaviour
{
    [SerializeField] private CardData _data;

    public CardData Data => _data;
    

    void OnValidate()
    {
        Debug.Log("hello");
        GameObject FrontPlane = gameObject.transform.Find("VisualsFront").gameObject;
        GameObject BackPlane = gameObject.transform.Find("VisualsBack").gameObject;
        FrontPlane.GetComponent<Renderer>().sharedMaterial.SetTexture("_BaseMap", Data.CardFront);
        BackPlane.GetComponent<Renderer>().sharedMaterial.SetTexture("_BaseMap", Data.CardBack);
    }

    private void Update()
    {
        
    }
}
