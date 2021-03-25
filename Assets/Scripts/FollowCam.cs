﻿
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.2f;
    private Vector3 _velocity = Vector3.zero;

    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(
            target.position.x, target.position.y, transform.position.z);

        transform.position = targetPosition;
    }
}
