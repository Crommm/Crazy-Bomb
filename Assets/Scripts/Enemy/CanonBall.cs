using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBall : MonoBehaviour
{
    [SerializeField] float speedCanonBall = 5f;

    void Update()
    {
        transform.Translate(Vector3.right * speedCanonBall * Time.deltaTime);
    }
}
