using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rigid;
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] float radius=0.2f;
    [SerializeField]float jumpForce=1500f;
    private bool isGround;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
     
    }
    void Update()
    {
        CollisionCheck();
        JumpBomb();
    }

    void JumpBomb()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGround)
            {
                rigid.AddForce(Vector2.up * jumpForce);
            }
        }
    }
    void CollisionCheck()
    {
        isGround = Physics2D.OverlapCircle(groundCheckPoint.position, radius, groundLayerMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(groundCheckPoint.position, radius);
    }
}
