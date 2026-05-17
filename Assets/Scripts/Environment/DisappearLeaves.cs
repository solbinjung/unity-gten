using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearLeaves : MonoBehaviour
{
    public float disappearTime = 1f;
    public float respawnTime = 3f;

    bool isPlayerOnPlatform = false;

    void Start()
    {
    }

    void Update()
    {
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && !isPlayerOnPlatform)
        {
            isPlayerOnPlatform = true;
            StartCoroutine(DisappearAndRespawn());
        }
    }
    IEnumerator DisappearAndRespawn()
    {
        
        yield return new WaitForSeconds(disappearTime);
        gameObject.SetActive(false);

        Invoke("Respawn", respawnTime);
        isPlayerOnPlatform = false;
    }
    void Respawn()
    {
        gameObject.SetActive(true);
    }
}
