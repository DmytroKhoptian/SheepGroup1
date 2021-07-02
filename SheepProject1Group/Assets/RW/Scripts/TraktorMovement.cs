using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TractorState { Move, Stop };

public class TraktorMovement : MonoBehaviour
{
    
    [SerializeField] private float speed;
    [SerializeField] private GameObject seno;
    [SerializeField] private float fireRate;
    private float nextFire;

    private Transform spawnPoint;
    [SerializeField] private Transform senoContainer;

    private float direction;
    private TractorState tractorState = TractorState.Stop;


    private void Awake()
    {
        spawnPoint = transform.GetChild(1);
    }


    void Update()
    {
        MoveTractor();
       // nextFire -= Time.deltaTime;
    }

    public void MoveRight()
    {
        direction = 1f;
        tractorState = TractorState.Move;
    }
    public void MoveLeft()
    {
        direction = -1f;
        tractorState = TractorState.Move;
    }
    public void StopMove()
    {
        tractorState = TractorState.Stop;
    }
    public void Fire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject seno = Instantiate(this.seno, spawnPoint.position, this.seno.transform.rotation);
            seno.transform.SetParent(senoContainer);
            Destroy(seno, 10f);     
        }
    }

    private void MoveTractor()
    {
        if (tractorState == TractorState.Move)
        {
            if (((transform.position.x >= -22f) && (direction == -1f)) || ((transform.position.x <= 22f) && (direction == 1f)))
            {
                transform.Translate(Vector3.right * speed * direction * Time.deltaTime);
            }
        }
    }

}
