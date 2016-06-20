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

    public bool AddCard(Card card)
    {
        return AddCard(card.CreateRenderer(transform).GetComponent<CardRenderer>());
    }

    public bool AddCard(CardRenderer card)
    {
        if (cards.Count < maxSize)
        {
            cards.Add(card);
            card.transform.SetParent(transform);
            return true;
        }
        return false;
    }
}
