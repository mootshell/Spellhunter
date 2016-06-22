using UnityEngine;
using System.Collections.Generic;

public class Equipment : ScriptableObject {

    public Dictionary<string, int> cardCounts = new Dictionary<string, int>();
    public string equipName;
    public string text;
}