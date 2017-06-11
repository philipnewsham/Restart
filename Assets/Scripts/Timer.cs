using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private int m_time;
    private float m_countTime;
    private bool m_isCounting;

    public GameObject player;
    public GameObject endCamera;
    public GameObject gameUIPanel;
    public Text timerText;

    public CollectMoney collectMoney;
    public BuyTime buyTime;
	// Use this for initialization
	void Start () {
        LoadTime();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(m_isCounting)
        {
            m_countTime -= Time.deltaTime;
            int multTime = Mathf.FloorToInt(m_countTime * 100f);
            float time = multTime / 100f;
            timerText.text = time.ToString();
            if(m_countTime <= 0)
            {
                EndGame();
            }
        }
	}

    void LoadTime()
    {
        if (PlayerPrefs.HasKey("Time"))
            m_time = PlayerPrefs.GetInt("Time");
        else
            m_time = 1;

        m_countTime = m_time;
        m_isCounting = true;
    }

    void EndGame()
    {
        PlayerPrefs.SetInt("Time", m_time);
        timerText.text = m_time.ToString();
        m_isCounting = false;
        player.SetActive(false);
        gameUIPanel.SetActive(false);
        endCamera.SetActive(true);
        collectMoney.SaveMoney();
        GetComponent<BuyTime>().LoadMoney();
    }

    public void StopTimer()
    {
        m_isCounting = false;
    }
}
