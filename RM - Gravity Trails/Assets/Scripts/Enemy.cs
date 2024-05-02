using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maximumXPosition;
    public int minimumXPosition;
    public float yForce;
    public float xForce;
    public float xDirection;
    public float yDirection;
    private Rigidbody2D enemyRigidBody;
    public float speed;
    public Text collectableCounter;
    public int throwableCounter;
    public Teleport enemycount;
    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Vector2 jumpForce = new Vector2(xForce * xDirection, yForce);
            enemyRigidBody.AddForce(jumpForce);
        }
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("hit a wall");
            float temp = xDirection * -1;
            xDirection = temp;
            Vector2 jumpForce = new Vector2(xForce * xDirection, yForce);
            enemyRigidBody.AddForce(jumpForce);
        }
        if(collision.gameObject.tag == "ThrowingObject")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            enemycount.enemyCount--;
            //collectableCounter.text = throwableCounter.ToString();
        }
    }


    
    private void FixedUpdate()
    {
        /*
        if (transform.position.x <= minimumXPosition)
        {
            xDirection = 1;
            enemyRigidBody.AddForce(Vector2.right * xForce);
        }
        if (transform.position.x >= maximumXPosition)
        {
            xDirection = -1;
            enemyRigidBody.AddForce(Vector2.left * xForce);
        }
        */
    }
}
