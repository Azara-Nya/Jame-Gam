using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float ByeByeTime = 5f;
    [SerializeField] PlayerMovement PM;
    private bool IsInvisPlayer = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (IsInvisPlayer == false)
            {
                PM.health -= 1;
                StartCoroutine(InvisPlayer());
            }
            Destroy(gameObject);
        }
    }
    void Start()
    {
        PM = FindObjectOfType<PlayerMovement>();
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
    IEnumerator InvisPlayer()
    {
        IsInvisPlayer = true;
        yield return new WaitForSeconds(0.1f);
        IsInvisPlayer = false;
    }
}