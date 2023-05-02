using System.Collections;
using System.Collections.Generic;
using System.Security;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData_", menuName = "CardData/Monster")]

public class CardData : ScriptableObject
{
    [Separator(2)]
    [SerializeField][Tooltip("Sets the name of the card.")] private string _cardName = "...";
    [SerializeField][Tooltip("Sets the type of the card.")] private CardType _cardType = CardType.None;
    [SerializeField][Tooltip("Sets the attribute of the card.")] private CardAttribute _cardAttribute = CardAttribute.None;

    [Separator(2)]
    [SerializeField][Tooltip("Sprite Will Be displayed on the front of the card.")] private Texture _cardFront = null;
    [SerializeField][Tooltip("Sprite Will Be displayed on the back of the card.")] private Texture  _cardBack = null;
    [SerializeField][Tooltip("Animation that plays when the card flips to front.")] private AnimationClip _cardFrontFlipAnimation = null;
    [SerializeField][Tooltip("Animation that plays when the card flips to back.")] private AnimationClip _cardBackFlipAnimation = null;
    [SerializeField][Tooltip("Particals that the card produces upon a loss.")] private ParticleSystem _cardLoseEffect = null;
    [SerializeField][Tooltip("Particals that the card produces upon a win.")] private ParticleSystem _cardWinEffect = null;

    [Separator(2)]
    [SerializeField][Tooltip("Sound that plays when the card flips.")] private AudioSource _cardFlipSound = null;
    [SerializeField][Tooltip("Sound that plays upon a card win.")] private AudioSource _cardWinSound = null;
    [SerializeField][Tooltip("Sound that plays upon a card loss.")] private AudioSource _cardLoseSound = null;

    [Separator(2)]
    [SerializeField][Tooltip("How much damage a card can deal.")] private int _attackPoints = 500;
    [SerializeField][Tooltip("How much damage a card can take.")] private int _defencePoints = 500;
    [SerializeField][Tooltip("The level of a card.")][Range(1,10)] private int _level = 1;

    [Separator(2)]
    [SerializeField][Tooltip("When Checked will display card stats.")] private bool _showStats = true;

    [Separator(2)]
    [SerializeField][Tooltip("")] private bool _isPositive = true;
    [SerializeField][Tooltip("")] private bool _isNegitive = false;
    [SerializeField][Tooltip("")] private int _modValue = 500;

    public string Name => _cardName;
    public CardType CardType => _cardType;
    public CardAttribute CardAttribute => _cardAttribute;
    public Texture CardFront => _cardFront;
    public Texture CardBack => _cardBack;
    public AnimationClip CardFrontFlipAnimation => _cardFrontFlipAnimation;
    public AnimationClip CardBackFlipAnimation => _cardBackFlipAnimation;
    public ParticleSystem CardLossEffect => _cardLoseEffect;
    public ParticleSystem CardWinEffect => _cardWinEffect;
    public AudioSource CardFlipSound => _cardFlipSound;
    public AudioSource CardWinSound => _cardWinSound;
    public AudioSource CardLoseSound => _cardLoseSound;
    public int AttackPoints => _attackPoints;
    public int DefencePoints => _defencePoints;
    public int Level => _level;
    public bool ShowStats => _showStats;
    public bool IsPositive => _isPositive;
    public bool IsNegitive => _isNegitive;
    public int ModValue => _modValue;
}
