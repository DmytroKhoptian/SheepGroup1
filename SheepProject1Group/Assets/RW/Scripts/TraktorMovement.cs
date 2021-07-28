using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum TractorState { Move, Stop };

public class TraktorMovement : MonoBehaviour
{
    
    [SerializeField] private float speed;
    [SerializeField] private GameObject seno;
    [SerializeField] private float fireRate;
    private float nextFire;

    private Transform spawnPoint;
    [SerializeField] private Transform senoContainer;

    public float direction;
    private TractorState tractorState = TractorState.Stop;
    [SerializeField] private SoundManager soundManager;
    public UnityEvent shootEvent;

    [SerializeField] private Animator animator;


    private void Awake()
    {
        spawnPoint = transform.GetChild(1);

        if(animator == null)
        {
            animator = transform.GetChild(0).GetComponent<Animator>();
        }
      
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
        animator.SetBool("IsMove", false);
    }
    public void Fire()
    {
        if (Time.time > nextFire)
        {
            soundManager.PlayShootClip();
            nextFire = Time.time + fireRate;
            GameObject seno = Instantiate(this.seno, spawnPoint.position, this.seno.transform.rotation);
            seno.transform.SetParent(senoContainer);
            Destroy(seno, 10f);

            shootEvent.Invoke();

            animator.SetTrigger("Fire");
        }
    }

    private void MoveTractor()
    {
        if (tractorState == TractorState.Move)
        {
            if (((transform.position.x >= -22f) && (direction == -1f)) || ((transform.position.x <= 22f) && (direction == 1f)))
            {
                transform.Translate(Vector3.right * speed * direction * Time.deltaTime);
                animator.SetInteger("Direction", (int)direction);
                animator.SetBool("IsMove", true);


            }
        }
    }

}
