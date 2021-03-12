using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    Image pressStart;

    bool lit = false;
    float rate = .8f;

    // Start is called before the first frame update
    void Start()
    {
        // Start blinking on "Press any key" image
        StartCoroutine(Blink(rate));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            // Increase blink rate before queuing next scene to load
            rate = .1f;
            Invoke("BeginGame", 3);
        }
    }

    void BeginGame()
    {
        // Go to next level in scene index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Blinks an image on the title screen
    IEnumerator Blink(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(rate);

            if (lit)
            {
                pressStart.color = Color.white;
                lit = false;
            }
            else
            {
                pressStart.color = new Color(.8f, .8f, .8f);
                lit = true;
            }
        }
    }
}
