using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SightCheck//µû·Î »©±â
{
    XSight = 0, YSight = 1
}


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private BallMove Ball;

    [SerializeField]
    private Transform PlayerTransform;

    private Player Player;
    private Camera mainCamera;



    void Start()
    {
        Player = new Player(PlayerTransform);
        mainCamera = Camera.main;

        Ball.OnMoveTo();
    }

    void Update()
    {
        Player.OnMovePlayer();
    }
}
