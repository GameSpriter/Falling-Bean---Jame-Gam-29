using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionKill : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
