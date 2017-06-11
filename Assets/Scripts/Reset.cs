using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Reset : MonoBehaviour
{


	void Update () {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.SetInt("Time", 1);
            PlayerPrefs.SetInt("Money", 0);
            SceneManager.LoadScene(1);
        }
	}
}
