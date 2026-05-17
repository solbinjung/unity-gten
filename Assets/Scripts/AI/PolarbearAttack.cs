using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarbearAttack : MonoBehaviour
{
    public Transform player;
    public int damage = 1;

    AudioSource _AudioSource;
    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.transform == player)
        {
            _AudioSource.Play();
            Player playerHp = other.GetComponent<Player>();
            if(playerHp != null)
            {
                playerHp.TakeDamage(damage);
            }
        }
    }
}
