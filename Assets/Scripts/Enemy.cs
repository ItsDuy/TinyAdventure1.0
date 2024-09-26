using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("AnhDuy/Enemy")]

public class Enemy : MonoBehaviour, ICanTakeDamage
{   private Animator anim;
    private int isDeadId;
    [SerializeField]public int MaxHealth  = 50;
    public int CurrentHealth { get; private set; }
    public static Enemy Instance { get; private set; }
    
    void Start()
    {
        CurrentHealth = MaxHealth;
        anim=GetComponent<Animator>();
        isDeadId=Animator.StringToHash("isDead");
    }
    
   
    public void TakeDamage(GameObject source, int amount)
    {
        if (source.tag == "Player")
        {
            if (amount < 0)
                throw new System.ArgumentException("Damage amount cannot be negative.");

            CurrentHealth -= amount;

            if (CurrentHealth < 0)
                CurrentHealth = 0;
            
           
            Debug.Log($"Enemy took {amount} damage from Player. Current Health: {CurrentHealth}");

            
            if (CurrentHealth == 0)
            {
                
                Die();
                StartCoroutine(WaitFor1SecondBeforeDelete());
            }
        }
    }
    

    void Die()
    {
        Debug.Log("Enemy died.");
        anim.SetTrigger(isDeadId);
    }
    IEnumerator WaitFor1SecondBeforeDelete()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
