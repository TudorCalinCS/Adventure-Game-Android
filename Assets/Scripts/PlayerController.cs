using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    public Joystick joystick;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float _speed;
    [Header("Animator&settings")]
    public float delay = 0.3f;
    public bool blockAttack;
    public Animator animator;
    public string AnimationAttackString;
    public InventoryUI invUi;
    public Transform attackleft;
    public Transform attackright;
    public Transform attackup;
    public Transform attackdown;
    private float currentSpeed;
   [SerializeField] private Transform attackPoint;
    public LayerMask enemyLayer;
    //public AudioClip footstep;
    public AudioSource audioSource;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        //joystick = FindObjectOfType<Joystick>();
    }
    Vector2 vector2;
    void Update()
    {
        float horizontal = joystick.Horizontal;
        if (joystick.Horizontal > 0.2f)
        {
            horizontal += 0.2f;
            if (horizontal > 0.85f)
                horizontal = 0.85f;
        }
        else if (joystick.Horizontal < -0.2f)
        {
            horizontal += -0.2f;
            if (horizontal < -0.85f)
                horizontal = -0.85f;
        }
        
       
        float vertical = joystick.Vertical;
        if (Math.Abs(vertical) > 0.2f)
        {
            if (vertical > 0)
                vertical += 0.2f;
            else vertical -= 0.2f;
            if (vertical > 0.85f)
                vertical = 0.85f;
            if (vertical < -0.85f)
                vertical = -0.85f;
        }
        vector2.x = horizontal;
        vector2.y = vertical;
        //rb.velocity = new Vector3(horizontal*_speed,vertical*_speed);
        rb.MovePosition(rb.position + vector2 * _speed*Time.fixedDeltaTime);
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetFloat("Speed", vector2.sqrMagnitude);
        currentSpeed = vector2.sqrMagnitude;
        if (vector2.sqrMagnitude != 0)
        {
            AudioClip audioclp = audioSource.GetComponent<AudioClip>();
            if (audioSource.isPlaying == false)
                audioSource.Play();
        }

        ///IDLE POSITION
        //FRONT H-1 V0  POZ=1
        if (vector2.y<-0.5 && -0.2<vector2.x && 0.2 > vector2.x)
        //if(horizontal>Math.Abs(vertical) &&Math.Abs(horizontal)>0.5)
        {

            //lastAnimation = animationFront;
            animator.SetInteger("Position", 1);
            animator.SetFloat("PositionF", (animator.GetInteger("Position")));
            attackPoint = attackdown;
        }

        //BACK H1 V0  POZ=2
        if (vector2.y > 0.5 && -0.2 < vector2.x && 0.2 > vector2.x)
        //if(horizontal<vertical&&horizontal<0)
        {

            //lastAnimation = animationBack;
            animator.SetInteger("Position", 2);
            animator.SetFloat("PositionF", (animator.GetInteger("Position")));
            attackPoint = attackup;
        }
        //RIGHT H0 V1  POZ=3
        if (vector2.x > 0.5 && -0.2 < vector2.y && 0.2 > vector2.y)
        {

            //lastAnimation = animationRight;
            animator.SetInteger("Position", 3);
            animator.SetFloat("PositionF", (animator.GetInteger("Position")));
            attackPoint = attackright;
        }

        //LEFT
        //RIGHT H0 V1  POZ=4
        if (vector2.x < -0.5 && -0.2 < vector2.y && 0.2 > vector2.y)
        {

            //lastAnimation = animationLeft;
            animator.SetInteger("Position", 4);
            animator.SetFloat("PositionF", (animator.GetInteger("Position")));
            attackPoint = attackleft;
        }
        /**
        if (currentSpeed < 0.0001)
        {
            animator.Play(lastAnimation);
        }
        */
       

    }
    public void Attack()
    {
        if (blockAttack)
            return;
        animator.Play(AnimationAttackString);
        blockAttack = true;
        StartCoroutine(DelayAttack());

        float itemDamage = invUi.selectedItem.damage;
        Debug.Log("Item dmg=" + itemDamage.ToString());
        float itemRadius=invUi.selectedItem.radius;
       Collider2D[] hitEnemies= Physics2D.OverlapCircleAll(attackPoint.position, itemRadius,enemyLayer);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("I hit " + enemy.name);
            enemy.GetComponent<Enemy>().takeDamage(((int)itemDamage));
        }
    }
    /**
    private void OnDrawGizmosSelected()
    {
        itemRadius = invUi.selectedItem.radius;
        if (attackPoint == null || invUi.selectedItem == null)
            return;
        
        Gizmos.DrawWireSphere(attackPoint.position, itemRadius);
    }*/
    

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        blockAttack = false;
    }
}
