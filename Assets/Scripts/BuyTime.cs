using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BuyTime : MonoBehaviour
{
    private int m_money;
    private int m_time;
    public Button timeButton;
    public Text moneyText;
    public void LoadMoney()
    {
        m_money = PlayerPrefs.GetInt("Money");
        m_time = PlayerPrefs.GetInt("Time");
        UpdateButtons();
        UpdateMoneyText();
    }

    void UpdateButtons()
    {
        if (m_money >= m_time + 1)
            timeButton.interactable = true;
        else
            timeButton.interactable = false;

        timeButton.GetComponentInChildren<Text>().text = string.Format("Add Time\n{0}<size=10>s</size> -> {1}<size=10>s</size>\n{1}<size=10>G</size>", m_time, m_time + 1);
    }

    public void BoughtTime()
    {
        m_time += 1;
        m_money = m_money - m_time;
        UpdateMoneyText();
        PlayerPrefs.SetInt("Time", m_time);
        PlayerPrefs.SetInt("Money", m_money);
        UpdateButtons();
    }

    void UpdateMoneyText()
    {
        moneyText.text = m_money.ToString();
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("Money", m_money);
        SceneManager.LoadScene(1);
    }
}
