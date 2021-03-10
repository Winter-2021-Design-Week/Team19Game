using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CashItem", menuName = "ScriptableObjects/CashItemSO", order = 1)]
public class CashItemSO : ScriptableObject
{
    public string itemName, itemType;

    public int value;

    public Sprite sprite;
}
