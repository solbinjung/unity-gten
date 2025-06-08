using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraActive : MonoBehaviour
{
    public GameObject player;
    public GameObject virtualCamera;
    bool m_IsPlayerEnter;

    void Update()
    {
        if (m_IsPlayerEnter)
        {
            virtualCamera.SetActive(false);
            virtualCamera.SetActive(true);
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
