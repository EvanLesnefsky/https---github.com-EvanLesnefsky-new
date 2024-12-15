using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private GameObject playerTarget;

    // Update is called once per frame
    void Update()
    {
        if (playerTarget != null)
        {
            transform.LookAt(playerTarget.transform.position);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTarget = other.gameObject;
        }
    }
}
