using UnityEngine;
using System.Collections.Generic;
using SimpleJSON;

public class EquipmentDatabase : MonoBehaviour {

    public TextAsset equipmentData;
    public Dictionary<string, Equipment> equipment;

    void Start()
    {
        equipment = LoadEquipment(equipmentData);
    }

    public Equipment CreateEquipment(string equipmentName)
    {
        return equipment.ContainsKey(equipmentName) ? equipment[equipmentName] : null;
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
            weapon.text = weaponJSON["text"];
            weapon.weight = weaponJSON["weight"];
            weapon.twohanded = weaponJSON["two-handed"].AsBool;
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

            dict.Add(weapon.equipName, weapon);
        }

        for (int i = 0; i < json["shields"].Count; ++i)
        {
            JSONNode shieldJSON = json["shields"][i];
            Shield shield = (Shield)ScriptableObject.CreateInstance<Shield>();
            shield.equipName = shieldJSON["name"];
            shield.text = shieldJSON["text"];
            shield.weight = shieldJSON["weight"];
            shield.requirements = shieldJSON["requirements"];
            shield.armour = shieldJSON["armour"].AsInt;

            JSONNode abilities = shieldJSON["abilities"];
            JSONNode counts = shieldJSON["counts"];
            if (abilities.Count != counts.Count) { continue; }
            shield.cardCounts = new Dictionary<string, int>();
            for (int j = 0; j < abilities.Count; ++j)
            {
                shield.cardCounts.Add(abilities[j], counts[j].AsInt);
            }

            dict.Add(shield.equipName, shield);
        }

        for (int i = 0; i < json["armour"].Count; ++i)
        {
            JSONNode armourJSON = json["armour"][i];
            Armour armour = (Armour)ScriptableObject.CreateInstance<Armour>();
            armour.equipName = armourJSON["name"];
            armour.text = armourJSON["text"];
            armour.weight = armourJSON["weight"];
            armour.armour = armourJSON["armour"].AsInt;

            JSONNode abilities = armourJSON["abilities"];
            JSONNode counts = armourJSON["counts"];
            if (abilities.Count != counts.Count) { continue; }
            armour.cardCounts = new Dictionary<string, int>();
            for (int j = 0; j < abilities.Count; ++j)
            {
                armour.cardCounts.Add(abilities[j], counts[j].AsInt);
            }

            dict.Add(armour.equipName, armour);
        }

        return dict;
    }
}
