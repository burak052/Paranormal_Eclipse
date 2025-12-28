using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlayerInventoryData", menuName = "Scriptable Objects/PlayerInventoryData")]
public class PlayerInventoryData : ScriptableObject
{
    public List<int> ownedItemIDs = new List<int>();
}
