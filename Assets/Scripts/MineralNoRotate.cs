using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralNoRotate : MonoBehaviour
{
    public float speed = 2;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;


    private void Awake()
    {

        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;



    }

    void OnCollisionEnter2D(Collision2D other)
    {

        Score.score++;

        StartCoroutine(Break());

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
