using UnityEngine;
using System.Collections.Generic;

public class Hand : MonoBehaviour {

    public int maxSize;

    private List<Card> cards;

	// Use this for initialization
	void Start ()
    {
	    cards = new List<Card>();
	}
	
    public void Play(int index)
    {

    }

    public void Discard(int index)
    {

    }

    public void AddCard(Card card)
    {
        cards.Add(card);
        if (cards.Count > maxSize)
        {
            // Open discard overlay and discard a card
        }
    }
}
