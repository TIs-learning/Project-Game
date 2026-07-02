// Import Library
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Deklarasi Class IPointerEnterHandler IPointerExitHandler IPointerClickHandler
public class CardDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{    
    // isPlayerCard
    public bool isPlayerCard = true;
    // cardData
    public CardData cardData;
    // artwork
    public Image artwork;
    // handManager
    public HandManager handManager;
    // Setup()
    public void Setup(CardData data)
    {
        cardData = data;

        if (artwork != null)
            artwork.sprite = data.artwork;
    }
    // OnPointerEnter()
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("HOVER");
    }
    // OnPointerExit()
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("EXIT");
    }
    // TestClick()
    public void TestClick()
    {
        Debug.Log("CLICK");
    }
    // PlayCard()
    public void PlayCard()
    {
        handManager.PlayCard(this);
    }
    // OnPointerClick()
public void OnPointerClick(PointerEventData eventData)
{    // Pertama
    if (!isPlayerCard)
    return;
    // Kedua
    Debug.Log("CLICK");
    // Ketiga
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
