using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardRenderer : MonoBehaviour {

    public Card card;
    public Text nameArea;
    public Text textArea;


	// Use this for initialization
	void Start () {
        nameArea.text = card.name;
        textArea.text = card.text;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
