using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float speed = 2f;

    [SerializeField] Transform bompPlayer;

    [SerializeField] float minX, maxX, minY, maxY;

    
    void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        Vector3 nextPos = new Vector3(Mathf.Clamp(bompPlayer.position.x, minX, maxX), Mathf.Clamp(bompPlayer.position.y, minY, maxY), transform.position.z);

        transform.position = Vector3.Lerp(transform.position, nextPos, speed * Time.deltaTime);
    }
}
