using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashItem : MonoBehaviour
{
    [HideInInspector]
    public CashItemSO profile = null;

    string itemName, itemType;

    // Cash value of product
    [SerializeField]
    int value;

    [SerializeField]
    Text valueText;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        UpdateFromProfile();

        gm = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && gm.levelOver == false)
        {
            gm.AddCash(value);
            Destroy(gameObject);
        }
    }

    public void UpdateFromProfile()
    {
        value = profile.value;
        valueText.text = "$" + value;
        itemName = profile.itemName;
        itemType = profile.itemType;
        UpdateSprite();
    }

    void UpdateSprite()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = profile.sprite;
    }
}
