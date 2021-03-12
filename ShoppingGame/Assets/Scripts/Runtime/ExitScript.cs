using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// If the player collides with this, the round ends
public class ExitScript : MonoBehaviour
{
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Player triggers the round ending when pressing the interact button while inside the trigger
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetButton("Fire1"))
        {
            gm.levelOver = true;
        }
    }
}
