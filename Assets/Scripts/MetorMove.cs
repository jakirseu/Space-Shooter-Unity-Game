using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetorMove : MonoBehaviour
{

    private ParticleSystem particle;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    private AudioSource audioSource;

    public float speed = 2;
 

    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();

    }


    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    
    

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        
        if ((other.gameObject.tag == "Bullet"))
        {

            Score.score += 2;

            Destroy(other.gameObject);
            StartCoroutine(Break());

            
        }
    
    }


    private IEnumerator Break()
    {
        audioSource.Play();

        spriteRenderer.enabled = false;
        boxCollider2D.enabled = false;

        yield return new WaitForSeconds(1);


        Destroy(gameObject);

    }


}
