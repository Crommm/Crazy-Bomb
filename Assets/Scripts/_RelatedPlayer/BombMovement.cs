using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMovement : MonoBehaviour
{
    private Rigidbody2D rigid;

    public float currentSpeed;
    [SerializeField] float maxSpeed = 25f;

    [SerializeField] float breakValue = 10f;

   
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
       
    }
    void Update()
    {   
        ClickedLeftMouse();
        ClickedRightMouse();  
    }

    private void FixedUpdate()
    { 
        MoveForwardBomb();
        MoveReverseBomb();
    }
    public bool ClickedLeftMouse()
    {
        if (Input.GetMouseButton(0))
        {
            currentSpeed += Time.deltaTime;

            return true;
        }
        else
            return false;

    }
    public bool ClickedRightMouse()
    {
        if (Input.GetMouseButton(1))
        {
            currentSpeed -= Time.deltaTime* breakValue;

            return true;
        }
        else
            return false;
    }
    private void MoveForwardBomb()
    {
        if (ClickedLeftMouse())
        {

            rigid.AddForce(new Vector2(currentSpeed, rigid.position.y));

            if (currentSpeed >= maxSpeed)
            {
                currentSpeed = 0;
            }
        }
    }
    private void MoveReverseBomb()
    {
        if (ClickedRightMouse())
        {

            rigid.AddForce(new Vector2(-currentSpeed, rigid.position.y));

            if (currentSpeed <= 0)
            {
                currentSpeed = 0;
            }
        }
    }

  

}
