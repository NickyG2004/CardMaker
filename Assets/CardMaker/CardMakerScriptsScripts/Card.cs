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

    private bool _faceToggle = true;

    Quaternion _rotation;


    void OnValidate()
    {
        // Debug.Log(Data.cards.Count);
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
            AudioSource newSound = Instantiate(Data.CardFlipSound.GetComponent<AudioSource>(), transform.position, Quaternion.identity);
            Destroy(newSound.gameObject, newSound.clip.length);
        }
    }


    public void onChange()
    {
        Debug.Log("hello");
        GameObject FrontPlane = gameObject.transform.Find("VisualsFront").gameObject;
        GameObject BackPlane = gameObject.transform.Find("VisualsBack").gameObject;

        FrontPlane.GetComponent<Renderer>().material.SetTexture("_BaseMap", Data.CardFront);
        BackPlane.GetComponent<Renderer>().material.SetTexture("_BaseMap", Data.CardBack);
    }

    public void CardWinEffects()
    {
        if (Data.CardType == CardType.Monster)
        {
            Debug.Log("Win effects playing");
            AudioSource newSound = Instantiate(Data.CardWinSound.GetComponent<AudioSource>(), transform.position, Quaternion.identity);
            Destroy(newSound.gameObject, newSound.clip.length);
            Instantiate(Data.CardWinEffect, gameObject.transform.position, Quaternion.identity);
        }
    }

    public void CardLoseEffects()
    {
        if(Data.CardType == CardType.Monster)
        {
            Debug.Log("Lose effects playing");
            AudioSource newSound = Instantiate(Data.CardLoseSound.GetComponent<AudioSource>(), transform.position, Quaternion.identity);
            Destroy(newSound.gameObject, newSound.clip.length);
            Instantiate(Data.CardLossEffect, gameObject.transform.position, Quaternion.identity);
        }
    }

    public void Destroycard()
    {
        Debug.Log("Card Dystroyed");
        Destroy(gameObject);
    }

    public CardData getCardData()
    {
        return Data;
    }

}
