using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float maxHealth;
    public float exp;
    public RuntimeAnimatorController[] animCon;

    bool isWallHit = false;
    bool isLive = false;

    Rigidbody2D rb;
    Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();    
    }

    private void OnEnable()
    {
        isLive = true;
        health = maxHealth;
    }

    /// <summary>
    /// 몬스터 능력치 삽입
    /// </summary>
    /// <param name="data"></param>
    public void Init(SpawnData data)
    {
        anim.runtimeAnimatorController = animCon[data.spriteType];
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
        exp = data.exp;
    }

    private void Update()
    {
        if (!isWallHit)
        {
            // 아래로 이동
            Vector2 movement = Vector2.down * speed * Time.deltaTime;
            rb.MovePosition(rb.position + movement);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //벽과 충돌 로직
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("벽에 도달");
            speed = 0f;  // 벽에 도달하면 속도를 0으로 설정
            Destroy(rb);
            isWallHit = true;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            // "Enemy"와 충돌했을 때는 무시하고 그냥 겹치게 둠
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet")) return;

        health -= collision.GetComponent<Bullet>().damage;
        Debug.Log("피격");
        if(health > 0) //피격 후 생존
        {

        }
        else //죽었을 때
        {
            Dead();
        }
    }

    void Dead()
    {
        gameObject.SetActive(false);
    }
}