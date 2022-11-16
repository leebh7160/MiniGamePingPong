using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private Transform PlayerObject;
    private float PlayerSpeed = 0.01f;

    public Player(Transform playerObject)
    {
        PlayerObject = playerObject;
    }

    public void OnMovePlayer()
    {
        MovePlayerTo();
    }

    private void MovePlayerTo()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(PlayerObject.position);
        pos.x += Input.GetAxis("Horizontal") * PlayerSpeed;

        if (pos.x < 0.1f) pos.x = 0.1f;
        if (pos.x > 0.9f) pos.x = 0.9f;

        PlayerObject.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
