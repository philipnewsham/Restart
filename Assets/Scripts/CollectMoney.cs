using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollectMoney : MonoBehaviour
{
    public int money;
    public Text moneyText;
    private AudioSource m_audioSource;
	void Start ()
    {
        m_audioSource = GetComponent<AudioSource>();
        LoadMoney();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Coin")
        {
            money += 1;
            m_audioSource.Play();
            UpdateText();
            Destroy(other.gameObject);
        }
    }

    void UpdateText()
    {
        moneyText.text = money.ToString();
    }
    void LoadMoney()
    {
        if (PlayerPrefs.HasKey("Money"))
            money = PlayerPrefs.GetInt("Money");
        else
            money = 0;

        UpdateText();
    }

    public void SaveMoney()
    {
        PlayerPrefs.SetInt("Money", money);
    }
}
