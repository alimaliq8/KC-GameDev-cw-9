using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class octopusmove : MonoBehaviour
{
    Rigidbody2D Rb;
    public float speed;

    public Transform groundposs;
    public LayerMask ground;
    public float rad;
    // Start is called before the first frame update
    void Start()
    {
        Rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        patrol();
    }
    void patrol()
    {
        Rb.velocity = new Vector2 (speed, 0f);

        bool isgrounded = Physics2D.OverlapCircle(groundposs.position, rad, ground);

        if (!isgrounded)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            speed *= -1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
