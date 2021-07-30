using System.Collections;
 
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
            //Destroy(other.gameObject, 3f);
            StartCoroutine(DeactivateSheep(sheepController.gameObject));

            scoreManager.DropSheep();

            droppedSheepEvent.Raise();
        }
    }


    IEnumerator DeactivateSheep(GameObject sheep)
    {
        yield return new WaitForSeconds(3f);
        sheep.gameObject.SetActive(false);
    }
}
