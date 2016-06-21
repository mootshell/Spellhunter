using UnityEngine;
using System.Collections.Generic;
using SimpleJSON;

public class EquipmentDatabase : MonoBehaviour {

    public TextAsset equipmentData;
    public Dictionary<string, Equipment> equipment;

    void Start()
    {

    }

    public Equipment CreateEquipment(string equipmentName)
    {
        return equipment.ContainsKey(equipmentName) ? (Equipment)Object.Instantiate<Equipment>(equipment[equipmentName]) : null;
    }


    public Dictionary<string, Equipment> LoadEquipment(TextAsset filepath)
    {
        Dictionary<string, Equipment> dict = new Dictionary<string, Equipment>();

        JSONNode json = JSON.Parse(equipmentData.text);

        for (int i = 0; i < json["weapons"].Count; ++i)
        {
            JSONNode weaponJSON = json["weapons"][i];
            Weapon weapon = (Weapon)ScriptableObject.CreateInstance<Weapon>();
            weapon.equipName = weaponJSON["name"];
            Debug.Log(weaponJSON["text"]);
            weapon.weight = weaponJSON["weight"];
            weapon.range = weaponJSON["range"];
            weapon.requirements = weaponJSON["requirements"];
            weapon.damage = weaponJSON["damage"];
            weapon.scaling = weaponJSON["scaling"];

            JSONNode abilities = weaponJSON["abilities"];
            JSONNode counts = weaponJSON["counts"];
            if (abilities.Count != counts.Count) { continue; }
            weapon.cardCounts = new Dictionary<string, int>();
            for (int j = 0; j < abilities.Count; ++j)
            {
                weapon.cardCounts.Add(abilities[j], counts[j].AsInt);
            }

            dict.Add(weapon.name, weapon);
        }

        return dict;
    }
}
