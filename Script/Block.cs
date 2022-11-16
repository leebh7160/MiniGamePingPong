using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private int BlockDurablity;

    private void Start()
    {
        switch (this.tag)
        {
            case "Green":
                BlockDurablity = 1;
                return;
            case "Blue":
                BlockDurablity = 2;
                return;
            case "Red":
                BlockDurablity = 3;
                return;
            case "Orange":
                BlockDurablity = 4;
                return;
            case "Purple":
                BlockDurablity = 5;
                return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ball")
        {
            BlockDurablity -= 1;
            CheckBlockDurablity();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Ball")
        {
            BlockDurablity -= 1;
            CheckBlockDurablity();
        }
    }

    private void CheckBlockDurablity()
    {
        if (BlockDurablity == 0)
            this.gameObject.SetActive(false);
    }
}
