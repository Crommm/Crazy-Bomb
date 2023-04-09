using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] float attackRange = 3f;
    [SerializeField] GameObject canonPrefab;
    GameObject bomb;
    private float angle;
    private float fireTime;
    void Awake()
    {
        bomb = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnDrawGizmos()
    {
        GetComponent<CircleCollider2D>().radius = attackRange;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            RotateTowardPlayer();
            FireCanon();
        }
    }
    private void RotateTowardPlayer()
    {
        if (bomb == null)
        {
            return;
        }
        Vector3 targetPos = bomb.transform.position - transform.position;
        angle = Vector3.SignedAngle(transform.right, targetPos, transform.forward);
        transform.Rotate(0f, 0f, angle);

    }
    void FireCanon()
    {
        fireTime += Time.deltaTime;

        if (fireTime > Random.Range(2f, 4f))
        {
            GameObject projectile = Instantiate(canonPrefab, transform.position, transform.rotation);
            Destroy(projectile, 3f);
            fireTime = 0;
        }
    }

}
