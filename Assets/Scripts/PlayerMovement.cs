using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D PlayerRb;
    [SerializeField] private float MoveSpeed = 5f;
    [SerializeField] Animator Player;
    [SerializeField] Animator GameOver;
    public float health = 3f;
    private Camera cam;
    Vector2 Movement;
    Vector2 MousePos;

    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {

        if (health <= 0)
        {
            //Play Death Animation
            GameOver.SetBool("GameOverB", true);
            Destroy(gameObject);
        }
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");

        MousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        PlayerRb.MovePosition(PlayerRb.position + Movement * MoveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = MousePos - PlayerRb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        PlayerRb.rotation = angle;
    }
}
