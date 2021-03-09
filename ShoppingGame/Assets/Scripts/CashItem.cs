using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashItem : MonoBehaviour
{
    // Cash value of product
    [SerializeField]
    int value;

    [SerializeField]
    Text valueText;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        valueText.text = "$" + value;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            gm.AddCash(value);
            Destroy(gameObject);
        }
    }
}
