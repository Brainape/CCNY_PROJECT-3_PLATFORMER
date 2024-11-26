using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement Variables
    Rigidbody2D rb;
    public float jumpForce;
    public float speed;
    public bool inAir;
    public GameManager gameManager;
    public Animator anim;

    public AudioSource soundEffects;
    public AudioClip coinSound;
    public AudioClip bounce;
    public AudioClip death;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPosition = transform.position;

        //variables to mirror the player
        Vector3 newScale = transform.localScale;
        float currentScale = Mathf.Abs(transform.localScale.x); //take absolute value of the current x scale, this is always positive


        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition.x -= speed;
            newScale.x = -currentScale;
        }

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition.x += speed;
            newScale.x = currentScale;
        }

        if (inAir == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            inAir = true;

        }

        transform.position = newPosition;
        transform.localScale = newScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            inAir = false;
            Debug.Log("collison");
            anim.SetBool("onFloor", true);
            soundEffects.PlayOneShot(bounce, 0.4f);
        }

        if (collision.gameObject.tag == "Death")
        {
            Debug.Log("DEATH");
            gameManager.deathTime = true;
            gameManager.deathCount += 1;
            soundEffects.PlayOneShot(death, 0.4f);

            Destroy(gameObject);

        }


    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            anim.SetBool("onFloor", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            gameManager.score += 1;
            GameObject coin = collision.gameObject;
            soundEffects.PlayOneShot(coinSound, 0.4f);

            Destroy(coin);

           //there has to be a downside for shrinking
           //coin can make you shrink, coin can reset your size?
           //shrinking coins make controlls more slippery, and less momentum, maybe shorter jump?
        }
    }
    
    
    }