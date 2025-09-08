using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour

{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private GameObject explosion;
    [SerializeField] private float timer;
    void Start()
    {
        rb2d.linearVelocity = Vector2.right * 5;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.transform.tag == "Kill Box")
        {

            Destroy(gameObject);

        }
        if (collision.transform.tag == "EnemyBox")
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
           

        }
    }

        // Update is called once per frame
        void Update()
    {
        

    }
}
