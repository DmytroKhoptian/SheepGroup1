using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenoMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 diraction;

    private void Update()
    {
        transform.Translate(diraction * speed * Time.deltaTime);
    }
}
