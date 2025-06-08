using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointActive : MonoBehaviour
{
    public GameObject player;
    bool m_IsPlayerEnter;

    void Update()
    {
        if (m_IsPlayerEnter)
        {
            // Assuming ThrowSnow is a script attached to the player GameObject
            csCheckpoints csCheckpointsScript = player.GetComponent<csCheckpoints>();

            if (csCheckpointsScript != null)
            {
                // Enable the ThrowSnow component
                csCheckpointsScript.enabled = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;

            m_IsPlayerEnter = true;
        }
    }
}
