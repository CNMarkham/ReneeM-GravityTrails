using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject portal;
    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        portal = GameObject.Find("Portal");
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
            portal.GetComponent<Teleport>().enemyCount--;
            Destroy(gameObject);
            Destroy(collision.gameObject);
            
            //collectableCounter.text = throwableCounter.ToString();
        }
       // if (collision.gameObject.tag == "Player" && enemyCount == 0)
        //{
        //    SceneManager.LoadScene(1);
       // }
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
