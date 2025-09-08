using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid : MonoBehaviour
{
    private Transform Player;
    private Rigidbody2D rb2d;
    public AudioClip Crash;
    [SerializeField] private int HP = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.linearVelocity = Vector2.left * 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "BulletBox")
        {
            HP -= 1;
            if (HP <= 0)
            {
                GameManager.Instance.updateScore();
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(Crash, transform.position);
            }
        }
        else if (collision.transform.tag == "PlayerBox")
        {

            GameManager.Instance.updateScore();
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(Crash, transform.position);
        }
        else if (collision.transform.tag == "Kill Box")
        {

            GameManager.Instance.updateLives();
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(Crash, transform.position);

        }
    }
}
