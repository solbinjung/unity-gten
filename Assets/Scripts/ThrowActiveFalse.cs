using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowActiveFalse : MonoBehaviour
{
    public GameObject player;
    bool m_IsPlayerEnter;

    void Update()
    {
        if (m_IsPlayerEnter)
        {
            // Assuming ThrowSnow is a script attached to the player GameObject
            ThrowSnow throwSnowScript = player.GetComponent<ThrowSnow>();

            if (throwSnowScript != null)
            {
                // Enable the ThrowSnow component
                throwSnowScript.enabled = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Assuming "player" is a reference to the player GameObject
            player = other.gameObject;

            m_IsPlayerEnter = true;
        }
    }
}
