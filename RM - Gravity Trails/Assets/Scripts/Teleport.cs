using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Teleport : MonoBehaviour
{
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
