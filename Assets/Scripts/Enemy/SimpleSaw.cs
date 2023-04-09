using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SimpleSaw : MonoBehaviour
{
    private Rigidbody2D rigid;
    [SerializeField] float speed, rotateSpeed;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.gravityScale = 0;
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
    
    }

    private void FixedUpdate()
    {
        Move();
       
    }
    private void Move()
    {
        rigid.velocity = new Vector2(speed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")||!other.gameObject.CompareTag("Ground"))
        {
            speed = -speed;
        }
    }

}
