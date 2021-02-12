using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform player;
    public Transform target;
    public Vector3 offset;

    private void Update()
    {
        target = player.gameObject.transform;
        transform.position = target.position + offset;
    }
}
