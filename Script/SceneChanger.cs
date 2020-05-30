
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    public Animator myAnimator;

    void Start()
    {
        myAnimator = FindObjectOfType<Animator>();
    }

    public void TriggerFade()
    {
        myAnimator.SetTrigger("FadeOut");
    }
    
    
}
