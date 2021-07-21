using UnityEngine;

public class SheepDestroyer : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private GameEvent droppedSheepEvent;

   private void OnTriggerExit(Collider other)
    {
        SheepController sheepController = other.GetComponent<SheepController>();

        if (sheepController != null)
        {
            soundManager.PlayDropClip();
            other.GetComponent<Rigidbody>().isKinematic = false;
            Destroy(other.gameObject, 3f);

            scoreManager.DropSheep();

            droppedSheepEvent.Raise();
        }
    }
}
