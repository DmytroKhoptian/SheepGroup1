using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Rigidbody>().isKinematic = false;
        Destroy(other.gameObject, 3f);
    }
}
