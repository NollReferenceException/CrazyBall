using UnityEngine;
using System.Collections;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private Transform followableObject;

    [SerializeField] private float smooth;

    private Vector3 _startingDistance;

    private void Start()
    {
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
}