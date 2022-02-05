using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float Damage = 1f;
    [SerializeField] private float ByeByeTime = 10f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Bullet Damage - Enemy Health
        Destroy(gameObject);
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
