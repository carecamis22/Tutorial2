using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;

    public Text score;

    public GameObject WinTextObject;

    public GameObject YouLoseObject;

    public Text livesText;

    private int lives = 3;

    public AudioClip musicClipOne;

    public AudioClip musicClipTwo;

    public AudioSource musicSource;

    private int scoreValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        WinTextObject.SetActive(false);
        livesText.text = lives.ToString();
        YouLoseObject.SetActive(false);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);

        }

       if (collision.collider.tag == "Enemy")
        {
            lives -= 1;
            livesText.text = lives.ToString();
            Destroy(collision.collider.gameObject);

        }

        if (scoreValue == 8)
        {
            WinTextObject.SetActive(true);
            musicSource.clip = musicClipTwo;
            musicSource.Play();
        }
        if (scoreValue == 4)
        {
            transform.position = new Vector2(56.0f, 6.2f);
        
        }


        if (lives == 0)
        {
            YouLoseObject.SetActive(true);
        }

    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse); //the 3 in this line of code is the player's "jumpforce," and you change that number to get different jump behaviors.  You can also create a public variable for it and then edit it in the inspector.
            }
        }

    }
}