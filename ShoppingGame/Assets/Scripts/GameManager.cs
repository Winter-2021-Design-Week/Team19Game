using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    public bool levelOver;

    // Timer and score variables
    public Text timer, finalReadout;

    public int currentCash, maxCash, maxTime;

    // Start is called before the first frame update
    void Start()
    {
        finalReadout.gameObject.SetActive(false);

        levelOver = false;

        currentCash = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Restart scene at time
        if (Time.timeSinceLevelLoad >= maxTime && levelOver == false)
        {
            levelOver = true;
            ReadScore();
        }
        else if (Time.timeSinceLevelLoad <= maxTime)
        {
            // Timer's visual update
            timer.text = (maxTime - Time.timeSinceLevelLoad).ToString("00:00");
        }
    }

    public void AddCash(int amount)
    {
        currentCash += amount;
    }

    void ReadScore()
    {
        // Show final score
        finalReadout.gameObject.SetActive(true);
        finalReadout.text = "You spent:\n$" + currentCash + "/$" + maxCash + "\nThat's\n" + (((float)currentCash / maxCash) * 100).ToString("00.00") + "%\nof your budget!";

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

        // End level in 5 seconds
        Invoke("EndLevel", 5);
    }

    void EndLevel()
    {
        // Just to be safe, cancel all invokes
        CancelInvoke();

        // Temporary level call
        SceneManager.LoadScene("TestLevel");
    }
}
