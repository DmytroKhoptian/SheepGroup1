using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;


public class StartButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Animator animator;

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // SceneManager.LoadScene(1);
    }
}
