using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    
    [Header("Damage&Health")]
    public Color damageColour;
    public Color deadColour;
    public int enemyDamage;
    public int maxHealth;
    int currentHealth;
    public float rangeTrigger;
    public float attackTrigger;
    public LayerMask playerLayer;
    public float speed;
    public Transform attackbitePoint;
    private bool isDying=false;
    [SerializeField]private Transform player;
    [Header("Knockback")]
    public bool canTakeKnockBack;
    [SerializeField]private float strenght = 16, delay = 0.15f;
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    private bool isInKnockBack=false;
    [Header("Animation")]
    public Animator animator;
    public int isFacingLeft;//1 pentru stanga, -1 pentru dreapta
    void Start()
    {
        currentHealth = maxHealth;
        rb = this.GetComponent<Rigidbody2D>();
        sp = this.GetComponent<SpriteRenderer>();
    }
    public void Update()
    {
        searchForPlayer();
        if (isDying == true)
        {
            sp.color = deadColour;
        }
    }
    public void takeDamage(int damage)
    {
        changeColour();
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        if(canTakeKnockBack)
        PlayKnockBack();
        
    }

    private void Die()
    {
        Debug.Log(this.gameObject.name + " is dead");
        animator.SetTrigger("toDie");
        isDying = true;
        sp.color = deadColour;
    }
    public void doDestroy()
    {
        Destroy(this.gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        
        Gizmos.DrawWireSphere(this.gameObject.transform.position, rangeTrigger);
        Gizmos.DrawWireSphere(attackbitePoint.transform.position, attackTrigger);
    }
    public void searchForPlayer()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(this.gameObject.transform.position, rangeTrigger, playerLayer);
        if(playerCollider!=null&&isDying==false&&isInKnockBack==false)
        {
           // float distance = Vector3.Distance(transform.position - playerCollider.transform.position);
            transform.position = Vector2.MoveTowards(transform.position, playerCollider.transform.position, speed * Time.deltaTime);
            animator.SetTrigger("chasingPlayer");
            Debug.Log("Player on enemy radius");
            TryAttackPlayer();
            facePlayer();
        }
        else
        {   
            animator.ResetTrigger("chasingPlayer");
        }
    }

    public void TryAttackPlayer()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(attackbitePoint.transform.position, attackTrigger, playerLayer);
        if (playerCollider != null)
        {
            animator.SetTrigger("doAttack");
        }
        else animator.ResetTrigger("doAttack");
    }
    public void performAttack()
    {
        player.GetComponent<CharacterStats>().TakeDamage(enemyDamage);
    }
    public void facePlayer()
    {
        Vector3 scale = transform.localScale;
        if (player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x)*-1*isFacingLeft;
        }
        else
        scale.x = Mathf.Abs(scale.x)*isFacingLeft;
        transform.localScale = scale;
    }
    public void PlayKnockBack()
    {   //StopCoroutine(ResetKnockback());
        StopAllCoroutines();
        isInKnockBack = true;
        Debug.Log("Play KnockBack");
        
        Vector2 direction = (transform.position - player.transform.position).normalized;
        rb.AddForce(direction * strenght, ForceMode2D.Impulse);
        StartCoroutine(ResetKnockback());
    }
    private IEnumerator ResetKnockback()
    {
        yield return new WaitForSeconds(delay);
        rb.velocity = Vector3.zero;
        isInKnockBack = false;
    }
    public void changeColour()
    {
        StartCoroutine(changeColourDelay());
        
    }
    private IEnumerator changeColourDelay()
    {
        sp.color = damageColour;
        yield return new WaitForSeconds(0.2f);
        sp.color = Color.white;
    }
}
