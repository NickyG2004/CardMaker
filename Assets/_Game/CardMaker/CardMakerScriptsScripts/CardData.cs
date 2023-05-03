using System.Collections;
using System.Collections.Generic;
using System.Security;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData_", menuName = "CardData/DataObject")]

public class CardData : ScriptableObject
{
    [Separator(2)]
    [SerializeField][Tooltip("Sets the name of the card.")] private string _cardName = "...";
    [SerializeField][Tooltip("Sets the type of the card.")] private CardType _cardType = CardType.None;
    [SerializeField][Tooltip("Sets the attribute of the card.")] private CardAttribute _cardAttribute = CardAttribute.None;

    [Separator(2)]
    [SerializeField][Tooltip("Texture Will Be displayed on the front of the card.")] private Texture _cardFront = null;
    [SerializeField][Tooltip("Texture Will Be displayed on the back of the card.")] private Texture  _cardBack = null;
    [SerializeField][Tooltip("Animation Clip that plays when the card flips to front.")] private AnimationClip _cardFrontFlipAnimation = null;
    [SerializeField][Tooltip("Animation Clip that plays when the card flips to back.")] private AnimationClip _cardBackFlipAnimation = null;
    [SerializeField][Tooltip("Particals that the card produces upon a loss.")] private GameObject _cardLoseEffect = null;
    [SerializeField][Tooltip("Particals that the card produces upon a win.")] private GameObject _cardWinEffect = null;

    [Separator(2)]
    [SerializeField][Tooltip("Sound that plays when the card flips.")] private GameObject _cardFlipSound = null;
    [SerializeField][Tooltip("Sound that plays upon a card win.")] private GameObject _cardWinSound = null;
    [SerializeField][Tooltip("Sound that plays upon a card loss.")] private GameObject _cardLoseSound = null;

    [Separator(2)]
    [SerializeField][Tooltip("How much damage a card can deal.")] private int _attackPoints = 500;
    [SerializeField][Tooltip("How much damage a card can take.")] private int _defencePoints = 500;
    [SerializeField][Tooltip("The level of a card.")][Range(1,10)] private int _level = 1;

    [Separator(2)]
    [SerializeField][Tooltip("When Checked will display card stats.")] private bool _showStats = true;

    [Separator(2)]
    [SerializeField][Tooltip("Makes the modifire card Buff Attack and Defence stats.")] private bool _isPositive = true;
    [SerializeField][Tooltip("Makes the modifire card Debuff Attack and Defence stats.")] private bool _isNegitive = false;
    [SerializeField][Tooltip("Amount the cards will be Buffed or Debuffed.")] private int _modValue = 500;

    public string Name => _cardName;
    public CardType CardType => _cardType;
    public CardAttribute CardAttribute => _cardAttribute;
    public Texture CardFront => _cardFront;
    public Texture CardBack => _cardBack;
    public AnimationClip CardFrontFlipAnimation => _cardFrontFlipAnimation;
    public AnimationClip CardBackFlipAnimation => _cardBackFlipAnimation;
    public GameObject CardLossEffect => _cardLoseEffect;
    public GameObject CardWinEffect => _cardWinEffect;
    public GameObject CardFlipSound => _cardFlipSound;
    public GameObject CardWinSound => _cardWinSound;
    public GameObject CardLoseSound => _cardLoseSound;
    public int AttackPoints => _attackPoints;
    public int DefencePoints => _defencePoints;
    public int Level => _level;
    public bool ShowStats => _showStats;
    public bool IsPositive => _isPositive;
    public bool IsNegitive => _isNegitive;
    public int ModValue => _modValue;

    private void OnEnable()
    {
        //Debug.Log("Somthing");
        _cardFront = (Texture)Resources.Load("CheckerPattern");
        _cardBack = (Texture)Resources.Load("DefaultCardBack");
        _cardFrontFlipAnimation = (AnimationClip)Resources.Load("DefaultCardFrontFlip");
        _cardBackFlipAnimation = (AnimationClip)Resources.Load("DefaultCardBackFlip");
        _cardLoseEffect = (GameObject)Resources.Load("VFX_CardLossEffect");
        _cardWinEffect = (GameObject)Resources.Load("VFX_CardWinEffect");
        _cardFlipSound = (GameObject)Resources.Load("SFX_CardFlipSound");
        _cardWinSound = (GameObject)Resources.Load("SFX_CardWinSound");
        _cardLoseSound = (GameObject)Resources.Load("SFX_CardLossSound");
        Debug.Log(_cardLoseEffect);
        Debug.Log(_cardWinEffect);

    }
}
