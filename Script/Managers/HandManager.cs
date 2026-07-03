// Import library
using System.Collections;
using UnityEngine;

// Deklarasi Kelas HandManager (Inheritance)
public class HandManager : MonoBehaviour
{
    // Penyimpanan kartu terakhir
    public CardData playerLastCard;
    public CardData enemy1LastCard;
    public CardData enemy2LastCard;

    // Posisi kartu yang dimainkan
    public Transform playerPlayPoint;
    public Transform enemy1PlayPoint;
    public Transform enemy2PlayPoint;   

    // Belakang Kartu
    public Sprite cardBack;

    // Referensi Hand
    [Header("References")]
    public Transform enemy1Hand;
    public Transform enemy2Hand;
    public Transform handArea;

    // Prefab dan Deck
    public GameObject cardPrefab;
    public DeckManager deckManager;

    // Pengaturan jumlah kartu awal
    [Header("Settings")]
    public int startingHandSize = 5;

// Start()
void Start()
{
    deckManager.GenerateDeck(CardElement.Fire);
    deckManager.ShuffleDeck();

    DrawStartingHand(handArea);

    DrawStartingHand(enemy1Hand);

    DrawStartingHand(enemy2Hand);
}

// DrawStartingHand()
void DrawStartingHand(Transform hand)
{
    for (int i = 0; i < startingHandSize; i++)
    {
        DrawCardToHand(hand);
    }
}

// DrawCardToHand()
public void DrawCardToHand(Transform hand)
{
    CardData card = deckManager.DrawCard();

    if (card == null)
        return;

    GameObject newCard = Instantiate(cardPrefab, hand);
    Debug.Log(newCard.transform.parent.name);
    CardDisplay display = newCard.GetComponent<CardDisplay>();

    if (display != null)
    {
        display.handManager = this;
        display.isPlayerCard = (hand == handArea);
        display.Setup(card);
        if (hand != handArea)
    {
        display.artwork.sprite = cardBack;
    }
    }
}

// RemoveRandomCard()
public void RemoveRandomCard(Transform hand)
{
    if (hand.childCount == 0)
        return;

    int randomIndex = Random.Range(0, hand.childCount);

    Destroy(hand.GetChild(randomIndex).gameObject);
}

// RefreshHand()
void RefreshHand(Transform ownerHand, int targetSize)
{
    int cardsNeeded = targetSize - ownerHand.childCount;

    for (int i = 0; i < cardsNeeded; i++)
    {
        if (deckManager.deck.Count == 0)
            break;

        DrawCardToHand(ownerHand);
    }
}

// ResolveEffect()
void ResolveEffect(CardData card, Transform ownerHand){
    switch (card.effect){
        // Effect Draw
        case EffectType.Draw:

            Debug.Log("Drawing 2 cards!");

        for (int i = 0; i < card.value; i++)
        {
            DrawCardToHand(ownerHand);
        }
        
            break;
            
        // Effect Attack
        case EffectType.Attack:

            Debug.Log("Attack!");

            Transform targetHand = null;

            // IsHandEmpty()
            if (ownerHand == handArea)
            {
                targetHand = (Random.value < 0.5f) ? enemy1Hand : enemy2Hand;
            }
                else if (ownerHand == enemy1Hand)
            {
                targetHand = (Random.value < 0.5f) ? handArea : enemy2Hand;
            }
                else if (ownerHand == enemy2Hand)
            {
                targetHand = (Random.value < 0.5f) ? handArea : enemy1Hand;
            }

            bool blocked = false;

        if (targetHand == handArea && GameManager.Instance.playerShield)
        {
            GameManager.Instance.playerShield = false;
            GameManager.Instance.UpdateShieldIcons();
            blocked = true;
        }

        else if (targetHand == enemy1Hand && GameManager.Instance.enemy1Shield)
        {
            GameManager.Instance.enemy1Shield = false;
            GameManager.Instance.UpdateShieldIcons();
            blocked = true;
        }

        else if (targetHand == enemy2Hand && GameManager.Instance.enemy2Shield)
        {
            GameManager.Instance.enemy2Shield = false;
            GameManager.Instance.UpdateShieldIcons();
            blocked = true;
        }

        if (!blocked)
        {
            RemoveRandomCard(targetHand);
        }
        else
        {
            Debug.Log("Attack Blocked!");
        }

            break;
            case EffectType.Repeat:

        Debug.Log("Repeat!");

        CardData lastCard = null;

        if (ownerHand == handArea)
            lastCard = playerLastCard;

        else if (ownerHand == enemy1Hand)
            lastCard = enemy1LastCard;

        else if (ownerHand == enemy2Hand)
            lastCard = enemy2LastCard;

        if (lastCard != null)
        {
            
            if (lastCard.effect != EffectType.Repeat)
                {
                    ResolveEffect(lastCard, ownerHand);
                }
                else
                {
                    Debug.Log("Nothing to repeat.");
                }
        }

        break;

        case EffectType.Shield:

        Debug.Log("Shield!");

        if (ownerHand == handArea){
            GameManager.Instance.playerShield = true;
            GameManager.Instance.UpdateShieldIcons();
        }

        else if (ownerHand == enemy1Hand){
            GameManager.Instance.enemy1Shield = true;
            GameManager.Instance.UpdateShieldIcons();
        }
        else if (ownerHand == enemy2Hand){
            GameManager.Instance.enemy2Shield = true;
            GameManager.Instance.UpdateShieldIcons();
        }
        break;
        case EffectType.Freeze:

        Debug.Log("Freeze");

        int target = Random.Range(0, 2);

        if (ownerHand == handArea)
        {
        if (target == 0){
            GameManager.Instance.enemy1Frozen = true;
            GameManager.Instance.UpdateFreezeIcons();
        }
        else
            GameManager.Instance.enemy2Frozen = true;
            GameManager.Instance.UpdateFreezeIcons();
        }
        else if (ownerHand == enemy1Hand)
        {
        if (target == 0){
            GameManager.Instance.playerFrozen = true;
            GameManager.Instance.UpdateFreezeIcons();
        }
        else
            GameManager.Instance.enemy2Frozen = true;
            GameManager.Instance.UpdateFreezeIcons();
        }
        else if (ownerHand == enemy2Hand)
        {
        if (target == 0){
            GameManager.Instance.playerFrozen = true;
            GameManager.Instance.UpdateFreezeIcons();
        }
        else
            GameManager.Instance.enemy1Frozen = true;
            GameManager.Instance.UpdateFreezeIcons();
        }

        break;
        case EffectType.Peek:

        Debug.Log("Peek!");
        if (ownerHand != handArea)
        {
            Debug.Log("Enemy Peek skipped.");
            break;
        }

        Transform revealTarget = null;

        if (ownerHand == handArea)
        {
            revealTarget = (Random.value < 0.5f) ? enemy1Hand : enemy2Hand;
        }
        else if (ownerHand == enemy1Hand)
        {
            revealTarget = (Random.value < 0.5f) ? handArea : enemy2Hand;
        }
        else
        {
            revealTarget = (Random.value < 0.5f) ? handArea : enemy1Hand;
        }

        StartCoroutine(RevealHand(revealTarget));

        break;

        case EffectType.FireRefresh:

        Debug.Log("Refresh!");

        RefreshHand(ownerHand, card.value + 1);

        break;
        }
        IEnumerator RevealHand(Transform enemyHand)
{
    // Reveal every card
    foreach (Transform child in enemyHand)
    {
        CardDisplay display = child.GetComponent<CardDisplay>();

        if (display != null)
            display.artwork.sprite = display.cardData.artwork;
    }

    yield return new WaitForSeconds(2f);

    // Hide every card again
    bool isPlayerHand = (enemyHand == handArea);

    foreach (Transform child in enemyHand)
    {
        CardDisplay display = child.GetComponent<CardDisplay>();

        if (display != null)
        {
            if (isPlayerHand)
                display.artwork.sprite = display.cardData.artwork;
            else
                display.artwork.sprite = cardBack;
        }
    }
}
    }
    // PlayCard() and PlaceCard()
    public void PlayCard(CardDisplay card){
    if (GameManager.Instance.currentTurn != GameManager.Turn.Player)
    {
        Debug.Log("Not your turn!");
        return;
    }

    Debug.Log("Played: " + card.cardData.cardName);

    StartCoroutine(PlayPlayerCard(card));
    }
    IEnumerator PlayPlayerCard(CardDisplay card)
{
    CardAnimator animator = card.GetComponent<CardAnimator>();

    if (animator != null)
    {
        yield return StartCoroutine(
            animator.MoveTo(playerPlayPoint, 0.2f)
        );
    }

    ResolveEffect(card.cardData, handArea);

    PlaceCard(card, playerPlayPoint);

    GameManager.Instance.EndTurn();
}

IEnumerator PlayEnemyCard(CardDisplay card, Transform ownerHand, Transform playPoint)
{
    CardAnimator animator = card.GetComponent<CardAnimator>();

    if (animator != null)
    {
        yield return StartCoroutine(
            animator.MoveTo(playPoint, 0.35f)
        );
    }

    ResolveEffect(card.cardData, ownerHand);

    PlaceCard(card, playPoint);
}
// EnemyPlayCard()
public void EnemyPlayCard(Transform enemyHand)
{
    if (enemyHand.childCount == 0)
        return;

    int randomIndex = Random.Range(0, enemyHand.childCount);

    CardDisplay card =
        enemyHand.GetChild(randomIndex).GetComponent<CardDisplay>();

    if (card == null)
        return;

    Debug.Log("Enemy played: " + card.cardData.cardName);

    Transform playPoint = null;

    if (enemyHand == enemy1Hand)
        playPoint = enemy1PlayPoint;
    else
        playPoint = enemy2PlayPoint;

StartCoroutine(
    PlayEnemyCard(card, enemyHand, playPoint)
);
}
    public bool IsHandEmpty(Transform hand)
    {
        return hand.childCount == 0;
    }
void PlaceCard(CardDisplay card, Transform playPoint)
{
    // Remove previous last played card
    foreach (Transform child in playPoint)
    {
        Destroy(child.gameObject);
    }

    // Move card into discard pile
    card.transform.SetParent(playPoint);

    RectTransform rect = card.GetComponent<RectTransform>();

    rect.anchoredPosition = Vector2.zero;
    rect.localRotation = Quaternion.identity;

    // Make the discard card smaller
    rect.localScale = new Vector3(0.6f, 0.6f, 1f);

    // Reveal the real artwork
    card.artwork.sprite = card.cardData.artwork;

    // Disable clicking
    UnityEngine.UI.Button button = card.GetComponent<UnityEngine.UI.Button>();

    if (button != null)
        button.enabled = false;

    // Disable hover/click logic
    card.isPlayerCard = false;
if (card.cardData.effect != EffectType.Repeat)
{
    if (playPoint == playerPlayPoint)
        playerLastCard = card.cardData;

    else if (playPoint == enemy1PlayPoint)
        enemy1LastCard = card.cardData;

    else if (playPoint == enemy2PlayPoint)
        enemy2LastCard = card.cardData;
}

}
}
