using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csCheckpoints : MonoBehaviour
{
    private GameObject cpObj;
    public Vector3 cp;

    private Player player;

    void Start()
    {
        cp = gameObject.transform.position;
    }

    void Update()
    {
        if(gameObject.transform.position.y<-20f)
        {
            Player playerHp = GetComponent<Player>();
            if (playerHp != null)
            {
                playerHp.TakeDamage(1);
            }
            gameObject.transform.position = cp;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("CheckPoints"))
        {
            cpObj = other.gameObject;
            cp = cpObj.transform.position;
            Destroy(cpObj);
        }
    }
}
