using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Card : MonoBehaviour {

    public Text cardNameArea;
    public Text cardTextArea;

    public static Object cardPrefab;

    public static Card Create(string cardName, string cardText)
    {
        GameObject newObject = Instantiate(cardPrefab) as GameObject;
        Card card = newObject.GetComponent<Card>();

        card.cardNameArea.text = cardName;
        card.cardTextArea.text = cardText;

        return card;
    }
    
	void Awake ()
    {
        cardPrefab = Resources.Load("Prefabs/CardPrefab");
    }
}
