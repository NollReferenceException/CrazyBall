using System;
using UnityEngine;
using System.Collections;

public class FollowingCamera : MonoBehaviour, IRestartable
{
    [SerializeField] private Transform followableObject;

    [SerializeField] private float smooth;

    private Vector3 _startingDistance;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
        _startingDistance = transform.position - followableObject.transform.position;
        gameObject.GetComponent<Camera>().transform.LookAt(followableObject);
    }

    private void LateUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 position = transform.position;
        float tempPositionY = position.y;

        position = Vector3.Lerp(position, followableObject.position + _startingDistance, smooth * Time.deltaTime);

        position = new Vector3(position.x, tempPositionY, position.z);

        transform.position = position;
    }

    public void RestartThisObject()
    {
        transform.position = startPosition;
    }
}