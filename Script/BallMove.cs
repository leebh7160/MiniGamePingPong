using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed = 10;

    private float TouchAngle_X = 1;
    private float TouchAngle_Y = 1;
    private Vector2 moveLocation = new Vector2();


    #region �� �����̱�

    public void OnMoveTo()
    {
        StartCoroutine(MoveTo());
    }

    private void OnBallAngle(SightCheck sightCheck)
    {
        if (sightCheck == SightCheck.XSight) TouchAngle_X *= -1;
        if (sightCheck == SightCheck.YSight) TouchAngle_Y *= -1;
    }
    private void OnSightAngle(SightCheck sightCheck)
    {
        if (sightCheck == SightCheck.XSight) TouchAngle_X *= -1;
        if (sightCheck == SightCheck.YSight) TouchAngle_Y *= -1;
    }

    private void OnPlayerAngle(SightCheck sightCheck)
    {
        if (sightCheck == SightCheck.YSight) TouchAngle_Y *= -1;
    }

    private IEnumerator MoveTo()
    {
        float moveX = 0;
        float moveY = -3.5f;

        while (true)
        {
            moveX += (Time.deltaTime * MoveSpeed) * TouchAngle_X;
            moveY += (Time.deltaTime * MoveSpeed) * TouchAngle_Y;

            moveLocation = new Vector2(moveX, moveY);

            this.gameObject.transform.position = moveLocation;

            BallOutOfSight();
            yield return null;
        }
    }
    #endregion

    #region �� ȭ�� ������ �����°� Ȯ��
    private void BallOutOfSight()
    {
        Vector2 pos = Camera.main.WorldToViewportPoint(this.transform.position);

        if (pos.x < 0.05f || pos.x > 0.95f) OnSightAngle(SightCheck.XSight);
        if (pos.y < 0.05f || pos.y > 0.95f) OnSightAngle(SightCheck.YSight);
    }
    #endregion

    #region �� ���� �΋H����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.enabled == true)
            OnPlayerAngle(SightCheck.YSight);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.enabled == true)
            OnBallAngle(SightCheck.XSight);
    }
    #endregion

    private int TouchWall()
    {
        return -1;
    }
}
