using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour {

    public Hand hand;
    public CardDatabase database;
    private List<Card> cards;

    // Use this for initialization
    void Start ()
    {
        cards = new List<Card>();
        database = GameObject.Find("CardDatabase").GetComponent<CardDatabase>();

        // Debugging
        AddCard(database.CreateCard("Attack"));
        AddCard(database.CreateCard("Attack"));
        AddCard(database.CreateCard("Attack"));
        AddCard(database.CreateCard("Anchor"));
        AddCard(database.CreateCard("Anchor"));
        AddCard(database.CreateCard("Anchor"));
    }

    public void Draw()
    {
        Card top = cards[0];
        cards.RemoveAt(0);
        hand.AddCard(top);
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
