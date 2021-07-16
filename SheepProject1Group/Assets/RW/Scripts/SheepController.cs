using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    private Rigidbody rb;
    [SerializeField] private GameObject heartEffect;
    [SerializeField] private SoundManager soundManager;


    private SheepProperty sheepProperty;
    [SerializeField] private Vector3 diraction;


    private void Awake()
    {
        //Debug.Log("Создалась овца с именем: " + sheepProperty.SheepName);

        rb = GetComponent<Rigidbody>();    
    }


    private void Update()
    {
        transform.Translate(diraction * sheepProperty.SheepSpeed * Time.deltaTime);
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



    public void SetPropertyToSheep(SheepProperty sheepProperty)
    {
        this.sheepProperty = sheepProperty;

        transform.localScale = new Vector3(sheepProperty.SheepSize, sheepProperty.SheepSize, sheepProperty.SheepSize);

    }
}
