using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(RectTransform))]
public class Hand : MonoBehaviour {

    public int maxSize;
    public Canvas canvas;
    public float spacing = 0.75f;

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
            float cardDist = spacing * (float)(rectTransform.rect.width * canvas.scaleFactor);
            cards[i].targetPosition = new Vector3((i - cards.Count) * (cardDist / ((float)cards.Count + 1)) + 0.5f * cardDist, 0, 0);
            if (cards[i].flipped)
            {
                cards[i].flipped = false;
            }
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
        card.transform.SetParent(transform);
        if (cards.Count > maxSize)
        {
            // Open discard overlay and discard a card
        }
    }
}
