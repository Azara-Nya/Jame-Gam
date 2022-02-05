using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Transform Player;
    private bool IsInvis = false;
    [SerializeField] private float Health = 2f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float Speed = 4f;
    [SerializeField] private float DamageTaken = 1f;
    [SerializeField] private float InfTime = 0.1f;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.fixedDeltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (IsInvis == false)
            {
                Health -= DamageTaken;
                //Play Damage Animation
                StartCoroutine(Invis());
            }
        }
    }
    IEnumerator Invis()
    {
        IsInvis = true;
        yield return new WaitForSeconds(InfTime);
        IsInvis = false;
    }
}