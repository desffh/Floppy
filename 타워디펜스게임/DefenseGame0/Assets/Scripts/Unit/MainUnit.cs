using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 상속받은 자식 클래스
public class MainUnit : UnitStat
{
    private int cost;

    private int health;

    private int defense;

    private int damage;

    private float attackspeed;

    private float movespeed;

    [SerializeField] GameResult gameResult;

    

    private void Awake()
    {
        
    }
    protected override void Start()
    {
        maxHealth = 50;
        base.Start(); // 부모 클래스의 Start 호출

    }

    protected override void Die()
    {
        StartCoroutine(EndGame());
    }

    // 죽음 애니메이션 실행
    protected override void PlayDeathAnimation()
    {
        if (animator != null)
        {
            // 애니메이션 나오는 중
            animator.SetTrigger("Die"); // Die 트리거 설정

            Die();
        }

    }
    protected IEnumerator EndGame()
    {
        // 2초 뒤에 팝업창 뜨기 
        yield return new WaitForSeconds(2.0f);
        Time.timeScale = 0;
        gameResult.Lose();

    }

    protected override int Cost
    {
        get { return cost; }
        set { cost = value; }
    }

    public override int Health
    {
        get { return health; }
        set { health = value; }
    }

    protected override int Defense
    {
        get { return defense; }
        set { defense = value; }
    }
    protected override int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    protected override float AttackSpeed
    {
        get { return attackspeed; }
        set { attackspeed = value; }
    }
    protected override float MoveSpeed
    {
        get { return movespeed; }
        set { movespeed = value; }
    }


    public override void Attack()
    {
        Debug.Log("Main유닛 Attack");
    }


    public MainUnit()
    {
        cost = 3;
        health = 50;
        defense = 0;
        damage = 5;
        attackspeed = 3;
        movespeed = 0;
    }

}
