using UnityEngine.EventSystems;
using UnityEngine;

public class ExitButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Application.Quit();
        Debug.Log("Выход");
    }
}
