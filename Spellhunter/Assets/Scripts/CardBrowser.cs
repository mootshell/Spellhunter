using UnityEngine;
using UnityEngine.UI;

public class CardBrowser : MonoBehaviour {

    public CardDatabase database;
    public Deck deck;
    public InputField searchBox;

	public void OnMouseClick()
    {
        Card card = database.CreateCard(searchBox.text);
        if (card != null)
        {
            deck.AddCard(card);
        }
        searchBox.text = "";
    }
}
