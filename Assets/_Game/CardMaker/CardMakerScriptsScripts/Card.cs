using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Collider))]
public class Card : MonoBehaviour
{
    [SerializeField] private CardData _data;

    public CardData Data => _data;

    private bool _faceToggle = false;

    Quaternion _rotation;


    void OnValidate()
    {
        Debug.Log(Data.cards.Count);
        onChange();
        if(!Data.cards.Contains(gameObject))
        {
            Data.cards.Add(gameObject);
        }
    }

    void Start()
    {
        GameObject BackPlane = gameObject.transform.Find("VisualsBack").gameObject;
        BackPlane.GetComponent<Renderer>().sharedMaterial.SetTexture("_BaseMap", Data.CardBack);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _rotation, Time.deltaTime * 2);
    }

    private void OnMouseOver()
    {
        if(Input.GetKeyDown(KeyCode.Mouse2))
        {
            if (_faceToggle == false)
            {
                _rotation = Quaternion.Euler(0f, 0f, 0f);
                Debug.Log(gameObject);
                _faceToggle = true;
            }
            else
            {
                _rotation = Quaternion.Euler(0f, 180f, 0f);
                Debug.Log(gameObject);
                _faceToggle = false;
            }
        }
    }

    public void onChange()
    {
        Debug.Log("hello");
        GameObject FrontPlane = gameObject.transform.Find("VisualsFront").gameObject;
        GameObject BackPlane = gameObject.transform.Find("VisualsBack").gameObject;

        FrontPlane.GetComponent<Renderer>().sharedMaterial.SetTexture("_BaseMap", Data.CardFront);
        BackPlane.GetComponent<Renderer>().sharedMaterial.SetTexture("_BaseMap", Data.CardBack);
    }
}
