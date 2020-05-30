using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {
    private Animator myAnimator;
    [SerializeField] AudioClip shieldDestroySound;

    [SerializeField] [Range(0, 1)] float soundVolume = 0.7f;
    

    void Start()
    {
        myAnimator = FindObjectOfType<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        StartCoroutine(TriggerDestroyAnimation());
        
    }
    IEnumerator TriggerDestroyAnimation()
    {
        myAnimator.SetTrigger("BrokenShield");
        AudioSource.PlayClipAtPoint(shieldDestroySound, Camera.main.transform.position, soundVolume);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
