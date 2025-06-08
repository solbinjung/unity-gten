using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour  // PolarBear�� Trash�� ����
{
    public int maxHp = 1;
    private int curHp = 1;

    public GameObject destroyTrashPrefab;  // frozenBearPrefab�� frozenTrashPrefab���� ����

    Rigidbody _Rigidbody;
    UnityEngine.AI.NavMeshAgent nmAgent;

    private bool isDestroy = false;

    void Start()
    {
        nmAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        _Rigidbody = GetComponent<Rigidbody>();

        curHp = maxHp;
    }

    void Update()
    {
    }

    void Destroy()
    {
        if (isDestroy)
        {
            // Instantiate the frozen trash prefab at the same position and rotation as the current trash
            GameObject destroyTrash = Instantiate(destroyTrashPrefab, transform.position, transform.rotation);

            // Destroy the current trash object
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        curHp -= damage;

        Debug.Log("Trash took damage. Current Health: " + curHp);
        if (curHp <= 0)
        {
            isDestroy = true;
            Destroy();
        }
    }
}