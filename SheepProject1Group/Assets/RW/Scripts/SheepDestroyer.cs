using UnityEngine;

public class SheepDestroyer : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;

    private void OnTriggerEnter(Collider other)
    {
        SheepController sheepController = other.GetComponent<SheepController>();

        if (sheepController != null)
        {
            soundManager.PlayDropClip();
            other.GetComponent<Rigidbody>().isKinematic = false;
            Destroy(other.gameObject, 3f);
        }
    }
}
