using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageble : MonoBehaviour
{
    public int MaxHealth = 100;
    [SerializeField] private int health;

    public int Health
    {
        get { return health; }
        set { health = value;
            OnHealthChange?.Invoke((float)Health / MaxHealth);
        }
    }

    public UnityEvent OnDead;
    public UnityEvent<float> OnHealthChange;
    public UnityEvent OnHit, OnHeal;

    private void Start()
    {
        health = MaxHealth;
    }

    public void Hit(int damage)
    {
        Health -= damage;
        if (health <= 0)
        {
            OnDead?.Invoke();
        }
        else
        {
            OnHit?.Invoke();
        }
    }

    public void Heal(int healthBoost)
    {
        health += healthBoost;
        Health = Mathf.Clamp(health, 0, MaxHealth);
        OnHeal?.Invoke();
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        //health -= collision.GetComponent<Bullet>().damage;
        Hit(collision.GetComponent<Bullet>().damage);
    }*/
}
