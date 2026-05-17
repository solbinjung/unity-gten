using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    GameObject polarbear;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Polarbear"))
        {
            Debug.Log("Collision with PolarBear");

            PolarBear polarbearHp = other.GetComponent<PolarBear>();
            if (polarbearHp != null)
            {
                
                polarbearHp.TakeDamage(damage);
                Debug.Log("Damage Dealt to PolarBear");
            }
            
        }
        Destroy(gameObject);
    }
}
