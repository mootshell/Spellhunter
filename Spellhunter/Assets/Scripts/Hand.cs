using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(RectTransform))]
public class Hand : MonoBehaviour {

    public int maxSize;
    public Canvas canvas;

    private RectTransform rectTransform;
    private List<CardRenderer> cards;
    
	void Start ()
    {
        rectTransform = GetComponent<RectTransform>();
        cards = new List<CardRenderer>();
	}

    void Update()
    {
        for (int i = 0; i < cards.Count; ++i)
        {
            cards[i].targetPosition = new Vector3(i * (cards.Count / (rectTransform.rect.width * canvas.scaleFactor)), 0, 0);
        }
    }
	
    public void Play(int index)
    {

    }

    public void Discard(int index)
    {

    }

    public void AddCard(Card card)
    {
        AddCard(card.CreateRenderer(transform).GetComponent<CardRenderer>());
    }

    public void AddCard(CardRenderer card)
    {
        cards.Add(card);
        if (cards.Count > maxSize)
        {
            // Open discard overlay and discard a card
        }
    }
}
