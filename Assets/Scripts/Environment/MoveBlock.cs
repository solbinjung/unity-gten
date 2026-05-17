using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    public float startTime;
    public float minX, maxX;

    [Range(1, 10)]
    public float moveSpeed;

    private int sign = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= startTime)
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime * sign, 0, 0);
        }
            
        if(transform.position.x <= minX || transform.position.x >= maxX)
        {
            sign *= -1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
