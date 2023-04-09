using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public float minspeed = 2f, maxSpeed = 5f;
    public float minRotatespeeed = 10f, maxRoteteSpeed = 60f;

    void Update()
    {
        transform.Translate(Vector2.down * Random.Range(minspeed, maxSpeed) * Time.deltaTime);
        transform.GetChild(0).Rotate(Vector3.forward * Random.Range(minRotatespeeed, maxRoteteSpeed) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.SetActive(false);    
    }
}
