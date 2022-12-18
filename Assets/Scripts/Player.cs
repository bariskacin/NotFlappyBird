using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    CircleCollider2D myCollider;

    [SerializeField] float jumpHeight;

    bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }
        Die();
    }

    void OnJump(InputValue value)
    {
        if (!isAlive) { return; }
        Die();
        if (value.isPressed)
        {
            myRigidbody.velocity = Vector2.up * jumpHeight;
        }
    }

    void Die()
    {
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Pipe")))
        {
            isAlive = false;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
            FindObjectOfType<GameSession>().gameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<GameSession>().gameOver();
        isAlive = false;
    }
}
