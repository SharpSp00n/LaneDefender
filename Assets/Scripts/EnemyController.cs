using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform Player;
    private Rigidbody2D rb2d;
    public GameManager GM;
    public AudioClip Crash;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "BulletBox")
        {

            GM.updateScore();
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(Crash, transform.position);
        }
        else if (collision.transform.tag == "PlayerBox")
        {

            GM.updateLives();
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(Crash, transform.position);
        }
    }
}
