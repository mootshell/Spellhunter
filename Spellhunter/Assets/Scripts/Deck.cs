using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour {

    private List<Card> cards;

    // Use this for initialization
    void Start ()
    {
        cards = new List<Card>();
	}

    public Card Draw()
    {
        Card top = cards[0];
        cards.RemoveAt(0);
        return top;
    }

    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    public void AddCards(List<Card> toAdd)
    {
        cards.AddRange(toAdd);
    }

    public void RemoveCards(List<Card> toRemove)
    {
        foreach(Card c in toRemove)
        {
            cards.RemoveAt(cards.IndexOf(c));
        }
    }

    public void Shuffle()
    {
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            Card value = cards[k];
            cards[k] = cards[n];
            cards[n] = value;
        }
    }
}
