using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rg;
    public float Speed_Player;

    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            rg.velocity = new Vector3(Speed_Player, rg.velocity.y, 0f);
        }

        else if (Input.GetAxis("Horizontal") < 0)
        {
            rg.velocity = new Vector3(-Speed_Player, rg.velocity.y, 0f);
        }
        else
        {
            rg.velocity = new Vector3(0f, rg.velocity.y, 0f);
        }
    }
}
