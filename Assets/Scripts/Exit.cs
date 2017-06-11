using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Exit : MonoBehaviour
{
    public Timer timerScript;
    public GameObject completedPanel;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            timerScript.StopTimer();
            completedPanel.SetActive(true);
        }
    }
    public void ReduceTime()
    {
        int time = PlayerPrefs.GetInt("Time");
        time -= 1;
        PlayerPrefs.SetInt("Time", time);
        SceneManager.LoadScene(1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
