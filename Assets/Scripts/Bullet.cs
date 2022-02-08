using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float ByeByeTime = 10f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Henry")
        {
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Caroline")
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (ByeByeTime > 0)
        {
            ByeByeTime -= Time.fixedDeltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
