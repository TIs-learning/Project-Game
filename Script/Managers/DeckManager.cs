using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [Header("Card Pools")]
    public List<CardData> neutralCards;
    public List<CardData> fireCards;
    public List<CardData> iceCards;
    public List<CardData> shadowCards;

    [Header("Current Deck")]
    public List<CardData> deck = new List<CardData>();

    public int deckSize = 300;

    public void GenerateDeck(CardElement element)
    {
        deck.Clear();

        for (int i = 0; i < deckSize; i++)
        {
            bool useNeutral = Random.value < 0.75f;

            if (useNeutral)
            {
                deck.Add(neutralCards[Random.Range(0, neutralCards.Count)]);
            }
            else
            {
                switch (element)
                {
                    case CardElement.Fire:
                        deck.Add(fireCards[Random.Range(0, fireCards.Count)]);
                        break;

                    case CardElement.Ice:
                        deck.Add(iceCards[Random.Range(0, iceCards.Count)]);
                        break;

                    case CardElement.Shadow:
                        deck.Add(shadowCards[Random.Range(0, shadowCards.Count)]);
                        break;
                }
            }
        }

        Debug.Log("Deck Generated!");
    }

    public void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            int randomIndex = Random.Range(i, deck.Count);

            CardData temp = deck[i];
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }

        Debug.Log("Deck Shuffled!");
    }

    public CardData DrawCard()
    {
        if (deck.Count == 0)
        {
            Debug.Log("Deck is empty!");
            return null;
        }

        CardData drawnCard = deck[0];
        deck.RemoveAt(0);

        return drawnCard;
    }
}