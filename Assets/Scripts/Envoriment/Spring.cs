using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] float upforce = 1500f;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Player")
        {
           Rigidbody2D rigid= other.gameObject.GetComponent<Rigidbody2D>();
            anim.SetTrigger("UpForce");
            rigid.AddForce(new Vector3(0, upforce, 0));
        }
    }
}
