using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    private Rigidbody rb;
    [SerializeField] private GameObject heartEffect;
    [SerializeField] private SoundManager soundManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        SenoMovement senoMovement = other.GetComponent<SenoMovement>();

        if(senoMovement != null)                                       //(other.gameObject.tag == "Seno")
        {
            soundManager.PlaySheepHitClip();
            rb.isKinematic = false;
            GetComponent<BoxCollider>().enabled = false;
            rb.AddForce(Vector3.up * jumpForce);
            Destroy(gameObject, 0.5f);
            Destroy(other.gameObject);

           GameObject effect = Instantiate(heartEffect, transform.position, heartEffect.transform.rotation);
           Destroy(effect, 1f);
        }
    }
}
