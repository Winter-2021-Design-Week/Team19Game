using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    public bool levelOver;

    // Timer and score variables
    public Text timer, budget, finalReadout;
    int sec, milli;

    public Image readoutPanel;

    public int currentCash = 0, maxCash, maxTime, currentItems = 0;

    // Start is called before the first frame update
    void Start()
    {
        readoutPanel.gameObject.SetActive(false);

        levelOver = false;

        currentCash = 0;

        budget.text = "Try to reach your $" + maxCash + " budget!";
    }

    // Update is called once per frame
    void Update()
    {
        // Game over by timeout
        if (Time.timeSinceLevelLoad >= maxTime && levelOver == false)
        {
            timer.text = "0.000";
            levelOver = true;
            ReadLoss();
        }
        // Win, if out of the store before timeout (levelOver is set true by another gameobject)
        else if (Time.timeSinceLevelLoad < maxTime && levelOver == true)
        {
            ReadScore();
        }

        // HUD timer update
        if (Time.timeSinceLevelLoad <= maxTime && levelOver == false)
        {
            // Time unit calculations
            sec = (int)Time.timeSinceLevelLoad;
            milli = (int)(Time.timeSinceLevelLoad * 1000) % 1000;

            // Timer's visual update
            timer.text = $"{maxTime - 1 - sec}.{(1000 - milli) % 1000:000}";
        }
    }

    public void AddCash(int amount)
    {
        currentItems++;
        currentCash += amount;
    }

    void ReadScore()
    {
        // Show final score
        readoutPanel.gameObject.SetActive(true);

        // Over budget means no points
        if (currentCash > maxCash)
        {
            finalReadout.color = Color.red;
            finalReadout.text = "You went over your budget!\nNo points for you!";
        }
        else
        {
            finalReadout.text = "You spent:\n$" + currentCash + "/$" + maxCash + "\n" + (((float)currentCash / maxCash) * 100).ToString("0.00") + "% of your budget\n× " + currentItems + " items";
            finalReadout.text += $"\nwith {maxTime - 1 - sec}.{(1000 - milli) % 1000:000} seconds to spare!";
            finalReadout.text += "\nScore: " + (((float)currentCash / maxCash) * 100) * currentItems;

            // If over budget
            if ((float)currentCash / maxCash > 1)
            {
                finalReadout.text += "\nToo bad! You're over budget.";
            }
            else if ((float)currentCash / maxCash == 1)
            {
                finalReadout.text += "\nNice! You're right on budget.";
            }
            else if ((float)currentCash / maxCash > .5f && (float)currentCash / maxCash < 1)
            {
                finalReadout.text += "\nPretty good! You're close to budget.";
            }
            else
            {
                finalReadout.text += "\nNo good. You're way under budget.";
            }
        }

        // End level in 10 seconds
        Invoke("EndLevel", 10);
    }

    void ReadLoss()
    {
        // Show final score
        readoutPanel.gameObject.SetActive(true);
        finalReadout.color = Color.red;        
        finalReadout.text = "You didn't cash out!\nNo points for you!";

        // End level in 5 seconds
        Invoke("EndLevel", 5);
    }

    void EndLevel()
    {
        // Just to be safe, cancel all invokes
        CancelInvoke();

        // Temporary level call
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
