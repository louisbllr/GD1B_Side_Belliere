using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouv : MonoBehaviour
{
    [SerializeField]
    private KeyCode leftKey = KeyCode.LeftArrow, rightKey = KeyCode.RightArrow, upKey = KeyCode.UpArrow, downKey = KeyCode.DownArrow;

    [SerializeField]
    private Rigidbody2D rgbd;
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;

    public bool isGrounded;
    [SerializeField] Transform checkGround;
    [SerializeField] LayerMask whatIsGround;
    public CoinManager cm;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }


    void Move()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal")* moveSpeed * Time.fixedDeltaTime, rgbd.velocity.y);
        rgbd.velocity = movement;
    }
    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(checkGround.position, 2.2f, whatIsGround);
        if (isGrounded)
        {
            if (Input.GetKeyDown(upKey))
                rgbd.velocity = new Vector2(rgbd.velocity.x, jumpForce);
        }


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            cm.coinCount++;
        }
    }
}
