using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour {
    private GameObject m_player;
	// Use this for initialization
	void Start ()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(m_player.transform.position.x, m_player.transform.position.y, -10);
	}
}
