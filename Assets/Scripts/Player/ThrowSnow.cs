using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSnow : MonoBehaviour
{
    public GameObject snowPrefab;
    public GameObject spot;

    public float speed=5;

    Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_Animator.SetTrigger("doThrow");
            Invoke("Throw", 0.7f);
        }
    }
    void Throw()
    {
        GameObject snow = Instantiate(snowPrefab, spot.transform.position, Quaternion.identity);

        snow.GetComponent<Rigidbody>().AddForce(spot.transform.forward * speed * 100f);
        Destroy(snow, 5f);
    }
}
