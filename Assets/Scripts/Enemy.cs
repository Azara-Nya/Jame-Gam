using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float EnemyHealth = 2f;

    private Transform Player;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float Speed = 4f;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        if (EnemyHealth == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.fixedDeltaTime);
        }
    }
}
