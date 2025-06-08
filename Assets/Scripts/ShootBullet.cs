using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject spot;

    public float speed = 50;

    Animator m_Animator;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            m_Animator.SetTrigger("doShoot");
            Invoke("Shooting", 0.7f);
        }
    }

    void Shooting()
    {
        GameObject bullet = Instantiate(bulletPrefab, spot.transform.position, Quaternion.identity);

        bullet.GetComponent<Rigidbody>().AddForce(spot.transform.forward * speed * 100f);
        Destroy(bullet, 5f);
    }
}
