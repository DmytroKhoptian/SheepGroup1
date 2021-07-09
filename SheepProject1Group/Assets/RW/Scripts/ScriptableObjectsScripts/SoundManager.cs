using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/AudioManager")]
public class SoundManager : ScriptableObject
{
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip sheepHitClip;
    [SerializeField] private AudioClip sheepDropClip;
    [SerializeField] private Vector3 cameraPosition;

   
   
    private void PlaySound(AudioClip audioClip)
    {
        cameraPosition = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(audioClip, cameraPosition);
    }
    public void PlayShootClip()
    {
        PlaySound(shootClip);
    }
    public void PlaySheepHitClip()
    {
        PlaySound(sheepHitClip);
    }
    public void PlayDropClip()
    {
        PlaySound(sheepDropClip);
    }

}
