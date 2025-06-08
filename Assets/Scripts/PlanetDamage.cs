using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDamage : MonoBehaviour
{
    public Transform player;
    public int damage = 1;


    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            Player playerHp = other.GetComponent<Player>();
            if (playerHp != null)
            {
                playerHp.TakeDamage(damage);
            }
        }
    }
}

