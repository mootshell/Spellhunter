using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class CardRenderer : MonoBehaviour {

    public Card card;
    public Text nameArea;
    public Text phaseArea;
    public Text textArea;

    public Deck deck;
    public Hand hand;
    public DiscardPile discard;

    public Vector3 targetPosition;
    public float speed = 2.0f;
    public float snapDistance = 5.0f;
    public bool flipped = true;
    
    public CardRendererType type = CardRendererType.DECK;

    private RectTransform rectTransform;
    private float elapsedTime = 0;

	// Use this for initialization
	void Start () {
        nameArea.text = card.cardName;
        phaseArea.text = card.cardPhase + " Phase";
        textArea.text = card.cardText;
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition3D = new Vector3(0, 0, 0);
        rectTransform.localScale = new Vector3(1, 1, 1);
        //targetPosition = new Vector3(0, 0, 0);
    }

    void Update() {
        if (Vector3.Distance(rectTransform.anchoredPosition3D, targetPosition) < snapDistance)
        {
            elapsedTime = 0;
            rectTransform.anchoredPosition3D = targetPosition;
            rectTransform.localRotation = Quaternion.Euler(0, (flipped) ? 180 : 0, 0);
        }
        else
        {
            elapsedTime += Time.deltaTime;
            rectTransform.anchoredPosition3D = Vector3.Lerp(rectTransform.anchoredPosition3D, targetPosition, speed * elapsedTime);
            rectTransform.localRotation = Quaternion.Lerp(rectTransform.localRotation, Quaternion.Euler(0, (flipped) ? 180 : 0, 0), speed * elapsedTime);
        }
	}

    public void OnMouseOver()
    {
        if (type == CardRendererType.HAND)
        {
            hand.selectedCard = this;
        }
    }

    public void OnMouseAway()
    {
        if (type == CardRendererType.HAND)
        {
            hand.selectedCard = null;
        }
    }

    public void OnMouseClick()
    {
        if (type == CardRendererType.DECK)
        {
            deck.DrawCard();
        }
        else if (type == CardRendererType.HAND)
        {
            hand.PlaySelected();
        }
        else if (type == CardRendererType.DISCARD)
        {
            discard.Reshuffle();
        }
    }
}


public enum CardRendererType
{
    DECK, HAND, DISCARD
}