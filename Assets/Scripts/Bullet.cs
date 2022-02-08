using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float ByeByeTime = 10f;
    [SerializeField] private AudioSource AudioM;
    [SerializeField] private AudioClip Hurt;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Henry")
        {
            StartCoroutine(Sound());
        }
        if (other.gameObject.tag == "Caroline")
        {
            StartCoroutine(Sound());
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

    IEnumerator Sound()
    {
        AudioM.PlayOneShot(Hurt, 0.5f);
        yield return new WaitForSeconds(Hurt.length);
        Destroy(gameObject);
    }
}
