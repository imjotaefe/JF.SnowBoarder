using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    [SerializeField] private float torqueAmount;
    [SerializeField] private SurfaceEffector2D surface;
    [SerializeField] private float boostSpeed;
    [SerializeField] private float baseSpeed;
    private bool _canMove = true;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surface = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (!_canMove) return;
        RotatePlayer();
        RespondToBoost();
    }

    public void DisableControls()
    {
        _canMove = false;
    }

    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surface.speed = baseSpeed + boostSpeed;
            return;
        }

        surface.speed = baseSpeed;
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
