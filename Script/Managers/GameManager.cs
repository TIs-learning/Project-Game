using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Image playerFreezeIcon;
    public Image enemy1FreezeIcon;
    public Image enemy2FreezeIcon;
    public bool playerFrozen = false;
    public bool enemy1Frozen = false;
    public bool enemy2Frozen = false;
    public TMP_Text turnText;
    public static GameManager Instance;
    public Turn currentTurn = Turn.Player;
    public bool playerAlive = true;
    public bool enemy1Alive = true;
    public bool enemy2Alive = true;
    public bool playerShield = false;
    public bool enemy1Shield = false;
    public bool enemy2Shield = false;
    public Image playerShieldIcon;
    public Image enemy1ShieldIcon;
    public Image enemy2ShieldIcon;
    public enum Turn
    
    {
        Player,
        Enemy1,
        Enemy2
    }

    private void Awake()
    {
        Instance = this;
        UpdateTurnText();
    }
public void UpdateShieldIcons()
    {
    playerShieldIcon.gameObject.SetActive(playerShield);
    enemy1ShieldIcon.gameObject.SetActive(enemy1Shield);
    enemy2ShieldIcon.gameObject.SetActive(enemy2Shield);
    }
public void UpdateFreezeIcons()
{
    playerFreezeIcon.gameObject.SetActive(playerFrozen);
    enemy1FreezeIcon.gameObject.SetActive(enemy1Frozen);
    enemy2FreezeIcon.gameObject.SetActive(enemy2Frozen);
}
void UpdateTurnText()
{
    switch (currentTurn)
    {
        case Turn.Player:
            turnText.text = "PLAYER TURN";
            break;

        case Turn.Enemy1:
            turnText.text = "ENEMY 1 TURN";
            break;

        case Turn.Enemy2:
            turnText.text = "ENEMY 2 TURN";
            break;
    }
}
    public void EndTurn()
{
    do
    {
        switch (currentTurn)
        {
            case Turn.Player:
                currentTurn = Turn.Enemy1;
                break;

            case Turn.Enemy1:
                currentTurn = Turn.Enemy2;
                break;

            case Turn.Enemy2:
                currentTurn = Turn.Player;
                break;
        }

    } while (
        (currentTurn == Turn.Player && !playerAlive) ||
        (currentTurn == Turn.Enemy1 && !enemy1Alive) ||
        (currentTurn == Turn.Enemy2 && !enemy2Alive)
    );

    Debug.Log("Current Turn: " + currentTurn);
    UpdateTurnText();

    CheckLoseCondition();
        if (currentTurn == Turn.Player && playerFrozen)
    {
        Debug.Log("Player is frozen!");
        playerFrozen = false;
        UpdateFreezeIcons();
        EndTurn();
        return;
    }

    if (currentTurn == Turn.Enemy1 && enemy1Frozen)
    {
        Debug.Log("Enemy 1 is frozen!");
        enemy1Frozen = false;
        UpdateFreezeIcons();
        EndTurn();
        return;
    }

    if (currentTurn == Turn.Enemy2 && enemy2Frozen)
    {
        Debug.Log("Enemy 2 is frozen!");
        enemy2Frozen = false;
        UpdateFreezeIcons();
        EndTurn();
        return;
    }

    if (currentTurn != Turn.Player)
    {
        StartCoroutine(EnemyTurn());
    }
}

    IEnumerator EnemyTurn()
{
    yield return new WaitForSeconds(1f);

    HandManager hand = FindFirstObjectByType<HandManager>();

    if (hand != null)
    {
        if (currentTurn == Turn.Enemy1)
            hand.EnemyPlayCard(hand.enemy1Hand);

        else if (currentTurn == Turn.Enemy2)
            hand.EnemyPlayCard(hand.enemy2Hand);
    }

    yield return new WaitForSeconds(0.5f);

    EndTurn();
}
void CheckLoseCondition()
{
    HandManager hand = FindFirstObjectByType<HandManager>();

    if (hand == null)
        return;

    switch (currentTurn)
    {
        case Turn.Player:

            if (hand.IsHandEmpty(hand.handArea))
{
            playerAlive = false;
            Debug.Log("PLAYER LOSES!");
            }

            break;

        case Turn.Enemy1:

            if (hand.IsHandEmpty(hand.enemy1Hand))  
            {
                enemy1Alive = false;
                Debug.Log("ENEMY 1 LOSES!");
            }

            break;

        case Turn.Enemy2:

            if (hand.IsHandEmpty(hand.enemy2Hand))
            {
                enemy2Alive = false;
                Debug.Log("ENEMY 2 LOSES!");
            }

            break;
    }
}
}
