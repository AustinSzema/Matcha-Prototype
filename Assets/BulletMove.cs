using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{

    [SerializeField]
    private float bulletSpeed;


    private bool facingRight;

    private Rigidbody2D rb;

    private Color bulletColor;









    public GameObject[] playerList;



    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        bulletColor = GetComponent<SpriteRenderer>().color;

        playerList = GameObject.FindGameObjectsWithTag("Main Player");

        foreach (GameObject player in playerList)
        {
            facingRight = player.GetComponent<PlayerController>().isFacingRight;
        }




        if (facingRight)
        {
            bulletSpeed = Mathf.Abs(bulletSpeed);
        }

        if (!facingRight)
        {
            bulletSpeed = bulletSpeed * -1f;
        }

    }

    private void Update()
    {




        Vector2 bulletForce = new Vector2(bulletSpeed, 0f);

        rb.velocity = bulletForce;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = bulletColor;
        }

        if(collision.gameObject.tag != "Main Player" && collision.gameObject.tag != "Bullet")
        {
            Destroy(gameObject);
        }
    }

}
