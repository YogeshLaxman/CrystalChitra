
using UnityEngine;

public class SceneFaderScript : MonoBehaviour {

    public Animator myAnimator;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FadeOut()
    {
        myAnimator.SetTrigger("FadeOutTigger");
    }
}
