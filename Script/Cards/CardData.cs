using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card Game/Card")]
public class CardData : ScriptableObject{
    [Header("Basic Info")]
    public string cardName;

    [TextArea]
    public string description;
    public Sprite artwork;

    [Header("Card Properties")]
    public CardElement element;

    public CardKind kind;

    public EffectType effect;

    public int value;

    public bool hasSymbol;
}