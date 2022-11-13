using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 5;
    public float maxDistance = 10;

    private Vector2 startPosition;
    private float conquaredDistance = 0;
    private Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Initializes()
    {
        startPosition = transform.position;
        rigidbody.velocity = transform.up * speed;
    }

    private void Update()
    {
        conquaredDistance = Vector2.Distance(transform.position, startPosition);
        if (conquaredDistance > maxDistance)
        {
            DisableObject();
        }
    }

    private void DisableObject()
    {
        rigidbody.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision name : " + collision.name);
        var damagable = collision.GetComponent<Damageble>();
        if (damagable != null) damagable.Hit(damage);
        DisableObject();
    }
}
