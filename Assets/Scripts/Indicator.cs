using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public GameObject Target;
    Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        var newPosition = _mainCamera.WorldToScreenPoint(Target.transform.position);
        newPosition.y = transform.position.y;
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }
}
