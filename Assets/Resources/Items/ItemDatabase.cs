using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Database", menuName = "Item/New Item Database")]
public class ItemDatabase : ScriptableObject
{
    [SerializeField]
    private List<Item> Items;

    public Item GetRandomItem() => Items[Random.Range(0, Items.Count)];
}
