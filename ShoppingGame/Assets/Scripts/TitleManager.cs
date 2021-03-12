using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    Image pressStart;

    [SerializeField]
    AudioSource jukebox;

    bool lit = false;
    float rate = .8f, fadeStart;

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
            fadeStart = Time.time;
            // Increase blink rate before queuing next scene to load
            rate = .1f;
            Invoke("BeginGame", 3);
        }

        // For fading music upon starting the game
        jukebox.volume = 1 - (Time.time - fadeStart) / (fadeStart + 1);
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
