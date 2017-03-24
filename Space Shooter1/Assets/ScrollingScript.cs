using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour
{

    public float Speed = 0.35f;

    void Start()
    {       
        
        
    }
    void Update()
    {
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", Vector2.up * this.Speed * Time.time);        
    }

}
