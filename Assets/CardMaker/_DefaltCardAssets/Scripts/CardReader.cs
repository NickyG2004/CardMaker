using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CardReader : MonoBehaviour
{
    [SerializeField] GameObject _MonsterDisplay;
    [SerializeField] TextMeshProUGUI _cardNameDiplayMonster;
    [SerializeField] GameObject _cardAttributeDisplay;
    [SerializeField] GameObject _cardAttackPointDisplay;
    [SerializeField] GameObject _cardDefencePointDisplay;
    [SerializeField] GameObject _cardCardLevel;

    [SerializeField] GameObject _ModifierDisplay;
    [SerializeField] GameObject _cardNameDiplayModifire;
    [SerializeField] GameObject _cardModDirectionDisplay;
    [SerializeField] GameObject _cardModMagnitudeDispaly;

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
            Debug.Log(Data.Name);
            string name = Data.Name;
            _cardNameDiplayMonster.text = name;
            Debug.Log(getAttribute((int)Data.CardAttribute));
            //_cardAttributeDisplay.GetComponent<TextMeshPro>().text = getAttribute((int)Data.CardAttribute);



        }
        else if (Data.CardType == CardType.Modifier)
        {
            _ModifierDisplay.SetActive(true);
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
}
