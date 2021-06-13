using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCoin : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collected!");
            audioSource.clip = audioClip;
            audioSource.Play();
            Destroy(gameObject);
        }
    }
}