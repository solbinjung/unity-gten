using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject trash;
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
        if (other.CompareTag("Trash"))  // Trash에 닿으면
        {
            Debug.Log("Collision with Trash");

            Trash trashHp = other.GetComponent<Trash>();
            if (trashHp != null)
            {
                trashHp.TakeDamage(damage);
                Debug.Log("Damage Dealt to Trash");
            }
        }

        Destroy(gameObject);  // 충돌 후 Bullet 제거
    }
}
