using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardInspector : MonoBehaviour
{
    public static CardInspector Instance;

    [Header("UI")]
    public TMP_Text cardName;
    public TMP_Text description;
    public Image artwork;

    private void Awake()
    {
        Instance = this;
        Hide();
    }

    public void Show(CardData card)
    {
        cardName.text = card.cardName;
        description.text = card.description;
        artwork.sprite = card.artwork;
        artwork.enabled = true;
    }

    public void Hide()
    {
        cardName.text = "Hover over a card";
        description.text = "";
        artwork.sprite = null;
        artwork.enabled = false;
    }
}