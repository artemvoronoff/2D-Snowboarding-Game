using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    bool hasFallen;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    [SerializeField] float loadDelay = 0.5f;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Ground" && !hasFallen)
        {
            Fallen();
            hasFallen = true;
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    void Fallen()
    {
        FindObjectOfType<PlayerController>().DisableControls();
        crashEffect.Play();
        GetComponent<AudioSource>().PlayOneShot(crashSFX);
        Invoke("ReloadScene", loadDelay);
    }

}
