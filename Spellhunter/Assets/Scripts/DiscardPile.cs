using UnityEngine;
using System.Collections.Generic;

public class DiscardPile : MonoBehaviour {

    public Deck deck;

    public float spacing = 1.0f;
    private List<CardRenderer> cards;

    void Start ()
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
                cards[i].flipped = false;
            }
        }
    }

    public void AddCard(CardRenderer card)
    {
        cards.Add(card);
        card.transform.SetParent(transform);
        card.type = CardRendererType.DISCARD;
        card.discard = this;
    }

    public void Reshuffle()
    {
        deck.AddCards(cards);
        cards.Clear();
        deck.Shuffle();
    }
}
