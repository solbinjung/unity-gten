using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PolarBear : MonoBehaviour
{
    public int maxHp = 3;
    private int curHp =3;
    
    public GameObject frozenBearPrefab;

    public Transform target;

    Rigidbody _Rigidbody;
    NavMeshAgent nmAgent;

    private bool isFrozen = false;
    
    void Start()
    {
        nmAgent = GetComponent<NavMeshAgent>();
        _Rigidbody = GetComponent<Rigidbody>();

        curHp = maxHp;
    }
     
    void Update()
    {
        nmAgent.SetDestination(target.position);
    }
    void Frozen()
    {
        if (isFrozen)
        {
            // Instantiate the frozen polar bear prefab at the same position and rotation as the current polar bear
            GameObject frozenBear = Instantiate(frozenBearPrefab, transform.position, transform.rotation);

            // Destroy the current polar bear object
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        curHp -= damage;

        Debug.Log("Polarbear took damage. Current Health: " + curHp);
        if (curHp <= 0)
        {
            isFrozen = true;
            Frozen();
        }
    }
}
