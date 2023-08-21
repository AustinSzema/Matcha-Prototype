using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public GameObject bullet;

    [SerializeField]
    private Rigidbody2D rb;


    [SerializeField]
    private float speed;

    //[SerializeField]
    //private float bulletSpeed;

    public PlayerInputActions playerControls;

    private InputAction move;
    private InputAction fire;

    public bool isFacingRight = true;
    //true = 1
    //false = 0

    private SpriteRenderer sprite;

    private Vector2 moveDirection;

    private void Awake()
    {

        playerControls = new PlayerInputActions();
    }


    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        //Debug.Log(move.ReadValue<Vector2>());
        //Debug.Log(isFacingRight);

        if(moveDirection.x < 0f)
        {
            isFacingRight = false;
            sprite.flipX = true;
        }
        if(moveDirection.x > 0f)
        {
            isFacingRight = true;
            sprite.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * speed;
    }


    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();


        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
    }


    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
    }

    private void Fire(InputAction.CallbackContext context)
    {
        Vector3 bulletPosition = transform.position + new Vector3(transform.localScale.x, 0f, 0f);

        if (isFacingRight)
        {
            bulletPosition = transform.position + new Vector3(transform.localScale.x, 0f, 0f);
        }
        if (!isFacingRight)
        {
            bulletPosition = transform.position + new Vector3(transform.localScale.x * -1f, 0f, 0f);
        }





        Instantiate(bullet, bulletPosition, Quaternion.identity);

        /*
        if (isFacingRight)
        {
            bulletSpeed = Mathf.Abs(bulletSpeed);
        }
        if(!isFacingRight)
        {
            bulletSpeed = Mathf.Abs(bulletSpeed) * -1f;
        }

        Vector2 bulletForce = new Vector2(bulletSpeed, 0f);

        bullet.GetComponent<Rigidbody2D>().AddForce(bulletForce);
        */
    }

}
