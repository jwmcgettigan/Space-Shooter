using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    
    float speed;

    void Start()
    {
        speed = 12.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        godown();

    }

    void godown()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

}
