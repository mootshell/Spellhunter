using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour {

    public Deck deck;
    public CardDatabase database;

    public Image icon;
    public Button unequipButton;
    public GameObject tooltip;
    public Text nameArea;
    public Text infoArea;
    public Text textArea;

    private Equipment equipped = null;
    
	void Start ()
    {
        tooltip.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        tooltip.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        tooltip.SetActive(false);
        unequipButton.gameObject.SetActive(false);
    }
	
	void Update ()
    {
	    if (equipped == null)
        {
            icon.color = new Color(icon.color.r, icon.color.g, icon.color.b, 0.5f);
        }
        else
        {
            icon.color = new Color(icon.color.r, icon.color.g, icon.color.b, 1.0f);
        }
	}

    public void Equip(Equipment toEquip)
    {
        equipped = toEquip;
        foreach (string abilityName in equipped.cardCounts.Keys)
        {
            for (int i = 0; i < equipped.cardCounts[abilityName]; ++i)
            {
                deck.AddCard(database.CreateCard(abilityName));
            }
        }
        unequipButton.gameObject.SetActive(true);
    }

    public void Unequip()
    {
        foreach (string abilityName in equipped.cardCounts.Keys)
        {
            for (int i = 0; i < equipped.cardCounts[abilityName]; ++i)
            {
                deck.RemoveCard(abilityName);
            }
        }
        equipped = null;
    }

    public void OnMouseOver()
    {
        if (equipped != null)
        {
            tooltip.SetActive(true);
            nameArea.text = equipped.equipName;
            textArea.text = equipped.text;
        }
    }

    public void OnMouseAway()
    {
        tooltip.SetActive(false);
    }
}
