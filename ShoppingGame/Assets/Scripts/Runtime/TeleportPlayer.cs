using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    GameManager gm;
    GameObject player;
    [SerializeField]
    GameObject teleLoc;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player");
    }

    // Player is teleported to target location
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<Rigidbody2D>().position = teleLoc.transform.position;
            gm.roundStartTime = Time.fixedTime;
            gm.roundStarted = true;
        }
    }
}
