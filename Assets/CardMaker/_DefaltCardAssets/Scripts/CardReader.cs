using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CardReader : MonoBehaviour
{
    [SerializeField] GameObject _MonsterDisplay;
    [SerializeField] TextMeshProUGUI _cardNameDiplayMonster;
    [SerializeField] TextMeshProUGUI _cardAttributeDisplay;
    [SerializeField] TextMeshProUGUI _cardAttackPointDisplay;
    [SerializeField] TextMeshProUGUI _cardDefencePointDisplay;
    [SerializeField] TextMeshProUGUI _cardCardLevel;

    [SerializeField] GameObject _ModifierDisplay;
    [SerializeField] TextMeshProUGUI _cardNameDiplayModifire;
    [SerializeField] TextMeshProUGUI _cardModDirectionDisplay;
    [SerializeField] TextMeshProUGUI _cardModMagnitudeDispaly;

    CardData CardInfo = null;

    private void Awake()
    {
        _MonsterDisplay.SetActive(false);
        _ModifierDisplay.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Card")
        {
            Debug.Log("TriggerEntered");
            if (other.GetComponent<Card>())
            {
                Debug.Log("CardTriggered");
                Card _card = other.GetComponent<Card>();
                CardInfo = _card.getCardData();
                DisplayStats(CardInfo);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Card")
        {
            Debug.Log("TriggerExited");
            if (other.GetComponent<Card>())
            {
                Debug.Log("CardOut");
                _MonsterDisplay.SetActive(false);
                _ModifierDisplay.SetActive(false);
            }
        }
    }

    private void DisplayStats(CardData Data)
    {
        if (Data.CardType == CardType.Monster)
        {
            _MonsterDisplay.SetActive(true);
            _cardNameDiplayMonster.text = "Name: " + Data.Name;
            _cardAttributeDisplay.text = "Attribute: " + getAttribute((int)Data.CardAttribute);
            _cardAttackPointDisplay.text = "Attack Points: " + Data.AttackPoints.ToString();
            _cardDefencePointDisplay.text = "Defence Points: " + Data.DefencePoints.ToString();
            _cardCardLevel.text = "Level: " + Data.Level.ToString();
        }
        else if (Data.CardType == CardType.Modifier)
        {
            _ModifierDisplay.SetActive(true);
            _cardNameDiplayModifire.text = "Name: " + Data.Name;
            _cardModDirectionDisplay.text = "Modifire Direction: " + modifireDirection(Data.IsNegitive, Data.IsPositive);
            _cardModMagnitudeDispaly.text = "Modifire Magnitude " + Data.ModValue.ToString();
        }
    }

    private string getAttribute(int value)
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

    private string modifireDirection(bool debuff, bool buff)
    {
        string temp = "";
        if (debuff == true)
        {
            temp = "Debuff";
        }
        else if(buff == true)
        {
            temp = "Buff";
        }
        else
        {
            temp = "Undecided";
        }

        return temp;
    }
}
