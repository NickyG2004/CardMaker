using System.Collections;
using System.Collections.Generic;
using System.Security;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData_", menuName = "UnitData/Monster")]

public class CardData : ScriptableObject
{
    [Separator(2)]
    [Header("General Card Information")]
    [SerializeField][Tooltip("Sets the name of the card.")] private string _cardName = "...";
    [SerializeField][Tooltip("Sets the type of the card.")] private CardType _cardType = CardType.None;
    [SerializeField][Tooltip("Sets the attribute of the card.")] private CardAttribute _cardAttribute = CardAttribute.None;

    [Separator(2)]
    [Header("Visual Data")]
    [SerializeField][Tooltip("Sprite Will Be displayed on the front of the card.")] private Sprite _cardFront = null;
    [SerializeField][Tooltip("Sprite Will Be displayed on the back of the card.")] private Sprite _cardBack = null;
    [SerializeField][Tooltip("Animation that plays when the card flips.")] private Animation _cardFlipAnimation = null;
    [SerializeField][Tooltip("Particals that the card produces upon a loss.")] private ParticleSystem _cardLoseEffect = null;
    [SerializeField][Tooltip("Particals that the card produces upon a win.")] private ParticleSystem _cardWinEffect = null;

    [Separator(2)]
    [Header("Visual Data")]
    [SerializeField][Tooltip("Sound that plays when the card flips.")] private AudioClip _cardFlipSound = null;
    [SerializeField][Tooltip("Sound that plays upon a card win.")] private AudioClip _cardWinSound = null;
    [SerializeField][Tooltip("Sound that plays upon a card loss.")] private AudioClip _cardLoseSound = null;

    [Separator(2)]
    [Header("Combat States")]
    [SerializeField][Tooltip("How much damage a card can deal.")] private int _attackPoints = 500;
    [SerializeField][Tooltip("How much damage a card can take.")] private int _defencePoints = 500;
    [SerializeField][Tooltip("The level of a card.")][Range(1,10)] private int _level = 1;

    public string Name => _cardName;
    public CardType CardType => _cardType;
    public CardAttribute CardAttribute => _cardAttribute;
    public Sprite CardFront => _cardFront;
    public Sprite CardBack => _cardBack;
    public Animation CardFlipAnimation => _cardFlipAnimation;
    public AudioClip CardFlipSound => _cardFlipSound;
    public AudioClip CardWinSound => _cardWinSound;
    public AudioClip CardLoseSound => _cardLoseSound;
    public int AttackPoints => _attackPoints;
    public int DefencePoints => _defencePoints;
    public int Level => _level;

}
