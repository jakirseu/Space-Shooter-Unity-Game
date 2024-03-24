using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody2D rigidbody2d;
    public float speed = 1;
    
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }



}
