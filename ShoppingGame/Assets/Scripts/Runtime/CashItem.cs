using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashItem : MonoBehaviour
{
    [HideInInspector]
    public CashItemSO profile;

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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player")
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
