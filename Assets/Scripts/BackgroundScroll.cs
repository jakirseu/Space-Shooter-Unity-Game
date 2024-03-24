using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float speed = .2f;
    

    void Update()
    {   

        GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, speed * Time.deltaTime);
        
    }
}
