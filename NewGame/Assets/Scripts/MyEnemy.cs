using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemy : MonoBehaviour
{
    [SerializeField] private int _health;
      private void Die()
    {
        Destroy(gameObject);
    }
    public void Hurt(int damage)
    {
        print("Ouch: " +damage);

        _health -= damage; ;

        if (_health <= 0)
        {
            Die();
        }
    }

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
  


   
}

