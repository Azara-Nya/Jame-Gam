using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform Player;
    private bool IsInvis = false;
    private bool IsInvisPlayer = false;
    [SerializeField] private float Health = 2f;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float Speed = 4f;
    [SerializeField] private float DamageTaken = 1f;
    [SerializeField] private float InfTime = 0.1f;
    [SerializeField] private float InfTimePlayer = 2f;
    [SerializeField] private SpriteRenderer ESprite;
    PlayerMovement PM;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        PM = FindObjectOfType<PlayerMovement>();
    }
    void Update()
    {
        if (!PauseMenu.GameIsPause)
        {
            if (Health <= 0)
            {
                Score.Points += 1;
                Destroy(gameObject);
            }
            else
            {
                Vector2 direction = (Player.position - transform.position).normalized;
                ESprite.flipX = direction.x > 0;
                transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.fixedDeltaTime);
            }
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

        if (other.CompareTag("Player"))
        {
            if (IsInvisPlayer == false)
            {
                PM.health -= 1;
                //Play Attack Animation
                StartCoroutine(InvisPlayer());
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (IsInvisPlayer == false)
            {
                PM.health -= 1;
                //Play Attack Animation
                StartCoroutine(InvisPlayer());
            }
        }
    }
    IEnumerator Invis()
    {
        IsInvis = true;
        yield return new WaitForSeconds(InfTime);
        IsInvis = false;
    }

    IEnumerator InvisPlayer()
    {
        IsInvisPlayer = true;
        yield return new WaitForSeconds(InfTimePlayer);
        IsInvisPlayer = false;
    }
}
