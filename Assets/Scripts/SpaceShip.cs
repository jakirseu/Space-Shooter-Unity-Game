using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{

    public float speed = 2;
    private Rigidbody2D rb2d;
    public GameObject bulletPrefab;
    public GameManager gameManager;
    private ParticleSystem particle;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    private AudioSource audioSource;
    private float screenCenterX;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;
        particle = GetComponentInChildren<ParticleSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();

        screenCenterX = Screen.width * 0.5f;

        StartCoroutine(Launch());
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.C))
        {
           // Launch();
        }
    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
     //   float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);




        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            

            Vector2 touchPosition = Input.GetTouch(0).position;
            double halfScreen = Screen.width / 2.0;

            //Check if it is left or right?
            if (touchPosition.x < halfScreen)
            {
                transform.Translate(Vector3.left * 5 * Time.deltaTime);
            }
            else if (touchPosition.x > halfScreen)
            {
                transform.Translate(Vector3.right * 5 * Time.deltaTime);
            }

        }

    }



    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            
            StartCoroutine(Break());
            Destroy(other.gameObject);


        }


    }

    private IEnumerator Break()
    {
        particle.Play();
       // audioSource.Play();
        spriteRenderer.enabled = false;
        boxCollider2D.enabled = false;
        
        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);

        gameManager.GameOver();
      

        
    }


    private IEnumerator Launch()
    {
        yield return new WaitForSeconds(.5f);

        GameObject newBullet = Instantiate(bulletPrefab, rb2d.position + Vector2.up * 1.5f, Quaternion.identity);

        

        StartCoroutine(Launch());

        Destroy(newBullet, 5);
    }

}
