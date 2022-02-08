using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooty : MonoBehaviour
{
    private Transform Player;
    private bool IsInvisPlayer = false;
    private bool IsInvis = false;
    private bool shooting = false;
    [SerializeField] private float Health = 1f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float Speed = 3.5f;
    [SerializeField] private float DamageTaken = 1f;
    [SerializeField] private float InfTime = 0.1f;
    [SerializeField] private float stoppingDistance = 15f;
    [SerializeField] private float FireInterval = 3f;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private float InfTimePlayer = 2f;
    [SerializeField] private Rigidbody2D ShootieShoot;
    [SerializeField] private Transform ShootingPoint;
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private SpriteRenderer ESprite;
    [SerializeField] private GameObject SFX;
    [SerializeField] private AudioSource Master;
    PlayerMovement PM;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        if (!PauseMenu.GameIsPause)
        {
            Vector3 lookDir = Player.position - transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            ShootieShoot.rotation = angle;
            if (Health <= 0)
            {
                Score.Points += 1;
                Destroy(gameObject);
            }
            else
            {
                if (Vector2.Distance(transform.position, Player.position) > stoppingDistance)
                {
                    Vector2 direction = (Player.position - transform.position).normalized;
                    ESprite.flipX = direction.x > 0;
                    transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.fixedDeltaTime);
                    // ShootieShoot.transform.position = Vector2.MoveTowards(ShootieShoot.transform.position, Player.position, Speed * Time.fixedDeltaTime);
                }
                else
                {
                    if (shooting == false)
                    {
                        StartCoroutine(Shooter());

                    }
                }
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


    IEnumerator Shooter()
    {
        shooting = true;
        yield return new WaitForSeconds(FireInterval);
        GameObject bullet = Instantiate(BulletPrefab, ShootingPoint.position, ShootingPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(ShootingPoint.up * bulletSpeed, ForceMode2D.Impulse);
        shooting = false;
    }

    IEnumerator InvisPlayer()
    {
        IsInvisPlayer = true;
        yield return new WaitForSeconds(InfTimePlayer);
        IsInvisPlayer = false;
    }

}