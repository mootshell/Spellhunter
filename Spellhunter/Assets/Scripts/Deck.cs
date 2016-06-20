using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour {

    public Hand hand;
    public CardDatabase database;
    public float spacing = 1.0f;
    private List<CardRenderer> cards;
    
    void Start ()
    {
        cards = new List<CardRenderer>();
        database = GameObject.Find("CardDatabase").GetComponent<CardDatabase>();

        // Debugging
        AddCard(database.CreateCard("Attack"));
        AddCard(database.CreateCard("Attack"));
        AddCard(database.CreateCard("Attack"));
        AddCard(database.CreateCard("Anchor"));
        AddCard(database.CreateCard("Anchor"));
        AddCard(database.CreateCard("Anchor"));
    }

    void Update()
    {
        for (int i = 0; i < cards.Count; ++i)
        {
            cards[i].targetPosition = new Vector3(0, 0, -i * spacing);
            if (!cards[i].flipped)
            {
                cards[i].flipped = true;
            }
        }
    }

    public void Draw()
    {
        if (cards.Count != 0)
        {
            CardRenderer top = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            hand.AddCard(top);
        }
    }

    public void AddCard(Card card)
    {
        cards.Add(card.CreateRenderer(transform).GetComponent<CardRenderer>());
    }

    public void AddCards(List<Card> toAdd)
    {
        foreach (Card card in toAdd)
        {
            AddCard(card);
        }
    }

    public void Clear()
    {
        foreach (CardRenderer card in cards)
        {
            Destroy(card);
        }
        cards.Clear();
    }

    public void Shuffle()
    {
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            CardRenderer card = cards[k];
            int kIndex = cards[k].transform.GetSiblingIndex();
            int nIndex = cards[n].transform.GetSiblingIndex();
            cards[k] = cards[n];
            cards[k].transform.SetSiblingIndex(kIndex);
            cards[n] = card;
            cards[n].transform.SetSiblingIndex(nIndex);
        }
    }
}
