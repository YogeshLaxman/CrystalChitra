﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopWall : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag=="Laser")
        {
            Destroy(collision.gameObject);
        }
    }
}
