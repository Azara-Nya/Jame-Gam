using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D PlayerRb;
    [SerializeField] private float MoveSpeed = 5f;
    Vector2 Movement;

    void Update()
    {
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");

        PlayerRb.MovePosition(PlayerRb.position + Movement * MoveSpeed * Time.fixedDeltaTime);
    }
}
