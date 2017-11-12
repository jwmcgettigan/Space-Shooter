using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnReachingBottom : MonoBehaviour {
   

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "fallingObject")
        {
            Destroy(col.gameObject);
        }
    }
}
