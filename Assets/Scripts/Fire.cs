using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private Transform ShootingPoint;
    [SerializeField] private GameObject BulletPrefab;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        if (!PauseMenu.GameIsPause && Input.GetButtonDown("Fire1"))
        {

            Fires();
        }

    }

    void Fires()
    {

        GameObject bullet = Instantiate(BulletPrefab, ShootingPoint.position, ShootingPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(ShootingPoint.up * bulletSpeed, ForceMode2D.Impulse);
    }
}
