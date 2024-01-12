using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int skillId; //스킬 스프라이트 결정 아이디
    public float damage;
    public int penetrate; //관통 횟수 -> 0이라면 한번 부딪히면 끝, -1이면 무한
    public float bulletSpeed; //투사체 속도
    public float atkRange;
    public Transform target;

    Rigidbody2D rb;
    private Vector3 initialDirection;
    private Transform initialLocation;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Init(PlayerData playerData)
    {
        skillId = playerData.skillId;
        damage = playerData.damage;
        penetrate = playerData.penetrate;
        bulletSpeed = playerData.bulletSpeed;
        atkRange = playerData.atkRange;
    }

    private void OnEnable() //Start로하면 재활용될때 target정보가 업데이트되지 않음
    {
        initialLocation = GameManager.Inst.player.fireArea;
        target = GameManager.Inst.player.target;
        initialDirection = target.position - initialLocation.position;
    }

    private void Update()
    {
        /*if(target == null || !target.gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            return;
        }*/

        if (gameObject.activeSelf)
        {
            rb.velocity = initialDirection.normalized * bulletSpeed;
            gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, initialDirection);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy") || penetrate == -1) return; 
        //관통력이 기본 -1이라면 무한관통

        penetrate--;
        if (penetrate == -1)
        {
            rb.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }
    }
}