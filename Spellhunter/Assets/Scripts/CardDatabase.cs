using UnityEngine;
using System.Collections.Generic;
using SimpleJSON;

public class CardDatabase : MonoBehaviour {

    public TextAsset cardData;
    public Dictionary<string, Card> cards;

    void Start()
    {
        cards = LoadCards(cardData);
    }

    public Card CreateCard(string cardName)
    {
        return cards.ContainsKey(cardName) ? (Card)Object.Instantiate<Card>(cards[cardName]) : null;
    }

    private Dictionary<string, Card> LoadCards(TextAsset filepath)
    {
        Dictionary<string, Card> dict = new Dictionary<string, Card>();

        JSONNode json = JSON.Parse(cardData.text);

        for(int i = 0; i < json["abilities"].Count; ++i)
        {
            JSONNode cardJSON = json["abilities"][i];
            Card card = (Card)ScriptableObject.CreateInstance<Card>();
            card.cardName = cardJSON["name"];
            card.cardText = cardJSON["text"];
            dict.Add(card.cardName, card);
        }

        for (int i = 0; i < json["spells"].Count; ++i)
        {
            JSONNode cardJSON = json["spells"][i];
            Card card = (Card)ScriptableObject.CreateInstance<Card>();
            card.cardName = cardJSON["name"];
            card.cardText = cardJSON["text"];
            dict.Add(card.cardName, card);
        }

        return dict;
    }
}
