using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour {

    public Hand hand;
    public float spacing = 1.0f;
    private List<CardRenderer> cards;
    
    void Start()
    {
        cards = new List<CardRenderer>();
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

    public bool DrawCard()
    {
        if (cards.Count != 0)
        {
            CardRenderer top = cards[cards.Count - 1];
            if (hand.AddCard(top))
            {
                cards.RemoveAt(cards.Count - 1);
                return true;
            }
        }
        return false;
    }

    public bool AddCard(Card card)
    {
        if (card == null) { return false; }

        CardRenderer renderer = card.CreateRenderer(transform).GetComponent<CardRenderer>();
        renderer.type = CardRendererType.DECK;
        renderer.deck = this;
        renderer.transform.SetParent(transform);
        cards.Add(renderer);
        return true;
    }

    public bool AddCard(CardRenderer renderer)
    {
        if (renderer == null) { return false; }
        renderer.type = CardRendererType.DECK;
        renderer.deck = this;
        renderer.transform.SetParent(transform);
        cards.Add(renderer);
        return true;
    }

    public void AddCards(List<Card> toAdd)
    {
        foreach (Card card in toAdd)
        {
            AddCard(card);
        }
    }

    public void AddCards(List<CardRenderer> toAdd)
    {
        foreach (CardRenderer card in toAdd)
        {
            AddCard(card);
        }
    }

    public void RemoveCard(string cardName)
    {
        foreach (CardRenderer card in cards)
        {
            if (card.card.cardName.Equals(cardName))
            {
                cards.Remove(card);
                Destroy(card.gameObject);
                break;
            }
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
