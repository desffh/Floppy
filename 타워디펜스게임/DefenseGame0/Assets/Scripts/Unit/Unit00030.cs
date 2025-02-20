using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit00030 : UnitStat
{
    //new private string name = "눈사람 아저씨";

    private int cost;

    private int health;

    private int defense;

    private int damage;

    private float attackspeed;

    private float movespeed;

    protected override void Start()
    {
        maxHealth = 50;
        base.Start(); // 부모 클래스의 Start 호출

    }
    // 애니메이션 이벤트에서 호출
    protected override void Die()
    {
        base.Die(); // 기본 Die 동작 실행
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
        Debug.Log("00030유닛 Attack");
    }


    public Unit00030()
    {
        cost = 4;
        health = 100;
        defense = 0;
        damage = 5;
        attackspeed = 5;
        movespeed = 0;
    }
}
