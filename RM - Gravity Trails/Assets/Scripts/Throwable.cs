using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Throwable : MonoBehaviour
{
    public Text collectableCounter;
    public GameObject objectThrown;
    public Vector3 offset;
    public int throwableCounter;
    void Start()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            throwableCounter++;
            collectableCounter.text = throwableCounter.ToString();
            Destroy(collision.gameObject);
        }
    }

    
    

    private void DestroyThrowable()
    {
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && throwableCounter > 0 )
        {
            throwableCounter--;
            offset = transform.localScale.x * new Vector3(1, 0, 0);
            Vector3 throwablePosition = transform.position + offset;
            Instantiate(objectThrown, throwablePosition, transform.rotation);
            collectableCounter.text = throwableCounter.ToString();

        }
        //Instantiate(objectThrown, throwablePosition, transform.rotation);
    }
}
