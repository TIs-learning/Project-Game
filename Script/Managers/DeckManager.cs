// Import Library
using System.Collections.Generic;
using UnityEngine;

// Definisi Class (inheritance)
public class DeckManager : MonoBehaviour
{    
    // Card Pools
    [Header("Card Pools")]
    public List<CardData> neutralCards;
    public List<CardData> fireCards;
    public List<CardData> iceCards;
    public List<CardData> shadowCards;

    // Current Deck
    [Header("Current Deck")]
    public List<CardData> deck = new List<CardData>();

    // Deck Size
    public int deckSize = 300;

    // Method GenerateDeck()
    public void GenerateDeck(CardElement element)
    {
        // Mengosongkan Deck Lama
        deck.Clear();

        // Membuat Deck Baru
        for (int i = 0; i < deckSize; i++)
        {
            // Menentukan Jenis Kartu
            bool useNeutral = Random.value < 0.75f;

            // Jika Neutral
            if (useNeutral)
            {
                deck.Add(neutralCards[Random.Range(0, neutralCards.Count)]);
            }
            else
            {
                // Jika Element
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
        
        // Deck Selesai
        Debug.Log("Deck Generated!");
    }
    
    // Method ShuffleDeck()
    public void ShuffleDeck()
    {
        // Algoritma
        for (int i = 0; i < deck.Count; i++)
        {
            // Pilih Index Acak
            int randomIndex = Random.Range(i, deck.Count);

            // Tukar Posisi
            CardData temp = deck[i];
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }

        Debug.Log("Deck Shuffled!");
    }

    // Method DrawCard()
    public CardData DrawCard()
    {
    
        // Deck Kosong?
        if (deck.Count == 0)
        {
            Debug.Log("Deck is empty!");
            return null;
        }
        // Ambil Kartu Pertama
        CardData drawnCard = deck[0];
        
        // Hapus Dari Deck
        deck.RemoveAt(0);
        
        // Return
        return drawnCard;
    }
}
