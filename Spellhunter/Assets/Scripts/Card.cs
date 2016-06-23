using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Card : ScriptableObject {

    public string cardName = "";
    public string cardPhase = "";
    public string cardText = "";

    public GameObject CreateRenderer(Transform parent)
    {
        GameObject cardRenderer = GameObject.Instantiate(Resources.Load("Card") as GameObject);
        cardRenderer.transform.SetParent(parent);
        cardRenderer.GetComponent<CardRenderer>().card = this;
        return cardRenderer;
    }
}
