using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip : MonoBehaviour
{
    bool faceRight = false;
    SpriteRenderer sprite;

    Animator anim;

    public GameObject bulletPrefabs;
    GameObject Bullet;
    public float Bulletspeed;

    void Start()
    {
        sprite=GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        flipe();
        playeranimations();
        fire();
    }
    void flipe()
    {
        if (Input.GetKeyDown(KeyCode.D) && faceRight == false)
        {
            sprite.flipX = false;
            faceRight = true;
        }
        else if (Input.GetKeyDown(KeyCode.A) && faceRight == true)
        {
            sprite.flipX = true;
            faceRight = false;
        }
    }
    void playeranimations()
    {
        float speed = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump");
        }
    }
    void fire()
    {
        if (Input.GetMouseButtonDown(0)&& faceRight == true)
        {
           Bullet=Instantiate(bulletPrefabs, transform.position,transform.rotation);
            Bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(Bulletspeed, 0f);
            Destroy(Bullet, 3f);
        }
        else if (Input.GetMouseButtonDown(0) && faceRight == false)
        {
            Bullet = Instantiate(bulletPrefabs, transform.position, transform.rotation);
            Bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-Bulletspeed, 0f);
            Destroy(Bullet, 3f);
        }
    }
}
