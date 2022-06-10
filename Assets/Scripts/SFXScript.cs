using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXScript : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip hitClip;
    [SerializeField] AudioClip destroyClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayHit()
    {
       
        audioSource.PlayOneShot(hitClip);
    }

    public void PlayDestroy()
    {
        audioSource.PlayOneShot(destroyClip);
    }
}
