using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialEditor : MonoBehaviour {
    private const string blurSize = "_Size";
    private const int Value = 0;
    public Image m_Image;
    //Set this in the Inspector
    //public Sprite m_Sprite;
   
    void Start()
    {
        //Fetch the Image from the GameObject
        m_Image = GetComponent<Image>();
        m_Image.material.SetFloat(blurSize, value: Value);
       // BlurIn();
    }
    
    public void BlurIn()
    {
        m_Image.material.SetFloat(blurSize, 2);
       /* float startTime = Time.time;
        float t= Time.time - startTime;
        while(t<=6)
        {
            m_Image.material.SetFloat(blurSize, t);
        }*/
    }
    public void BlurOut()
    {
        m_Image.material.SetFloat(blurSize, 0);
        /* float startTime = Time.time;
         float t= Time.time - startTime;
         while(t<=6)
         {
             m_Image.material.SetFloat(blurSize, t);
         }*/
    }
}
