using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public bool isPlayerCard = true;
    public CardData cardData;
    public Image artwork;
    public HandManager handManager;
    public void Setup(CardData data)
    {
        cardData = data;

        if (artwork != null)
            artwork.sprite = data.artwork;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("HOVER");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("EXIT");
    }
    public void TestClick()
    {
        Debug.Log("CLICK");
    }
    public void PlayCard()
    {
        handManager.PlayCard(this);
    }
public void OnPointerClick(PointerEventData eventData)
{
    if (!isPlayerCard)
    return;
    Debug.Log("CLICK");

    if (handManager != null)
    {
        Debug.Log("HAND MANAGER FOUND");
        handManager.PlayCard(this);
    }
    else
    {
        Debug.Log("HAND MANAGER IS NULL");
    }
}
}