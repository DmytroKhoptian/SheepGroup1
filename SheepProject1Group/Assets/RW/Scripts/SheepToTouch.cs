using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation))]
[RequireComponent(typeof(BoxCollider))]
public class SheepToTouch : MonoBehaviour
{
    private new Animation animation;

    private void Start()
    {
        animation = GetComponent<Animation>();
    }

    private void OnMouseDown()
    {
        animation.Play();
    }


}
