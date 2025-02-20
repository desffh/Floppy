using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit3AttackGizmo : MonoBehaviour
{
    public Transform Pos;
    private Vector2 BoxSize = new Vector2(2.8f, 4.3f);
    private Vector2 Offset = new Vector2(0.8f, 0f);

    public float attackCooldown = 5.0f; // 공격 주기 (초 단위)
    private float lastAttackTime = -1.0f; // 마지막 공격 시점

    bool previousState = false; // 이전 상태를 저장

    public int damage = 6;

    Unit3Anime Unit3Anime;


    private void Start()
    {
        // 스크립트 가져오기

        Unit3Anime = GetComponent<Unit3Anime>();
    }

    void Update()
    {

        Vector2 boxCenter = (Vector2)Pos.position + Offset;

        // 카메라의 뷰포트 좌표를 가져오기
        Camera mainCamera = Camera.main;
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(boxCenter);


        if (viewportPosition.x >= 0 && viewportPosition.x <= 1 && viewportPosition.y >= 0 && viewportPosition.y <= 1)
        {
            // OverlapBoxAll(시작위치, 박스크기, 레이어)
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(boxCenter, BoxSize, 11);

            bool unitDetected = false;


            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.CompareTag("Monster"))
                {
                    Debug.Log("몬스터와 충돌");

                    // 공격 쿨다운 확인
                    if (Time.time - lastAttackTime >= attackCooldown)
                    {
                        // 충돌된 대상에서 UnitStat 가져오기
                        MonsterStat monsterStat = collider.GetComponent<MonsterStat>();

                        if (monsterStat != null)
                        {
                            if (monsterStat is Monster1Stat)
                            {
                                Monster1Stat monster1Stat = (Monster1Stat)monsterStat;
                                monster1Stat.TakeDamage(damage);
                            }

                            else if (monsterStat is Monster2Stat)
                            {
                                Monster2Stat monster2Stat = (Monster2Stat)monsterStat;
                                monster2Stat.TakeDamage(damage);
                            }

                            else if (monsterStat is Monster3Stat)
                            {
                                Monster3Stat monster3Stat = (Monster3Stat)monsterStat;
                                monster3Stat.TakeDamage(damage);
                            }
                            else if (monsterStat is Monster4Stat)
                            {
                                Monster4Stat monster4Stat = (Monster4Stat)monsterStat;
                                monster4Stat.TakeDamage(damage);
                            }
                        }

                        // 마지막 공격 시간 갱신
                        lastAttackTime = Time.time;
                    }

                    unitDetected = true;
                    break;
                }
            }
            // 이전 상태와 현재 상태가 다를 경우에만 애니메이션 호출
            if (unitDetected != previousState)
            {
                if (unitDetected)
                {
                    Unit3Anime.StartAttackCreation(); // 공격 애니메이션
                }
                else
                {
                    Unit3Anime.EndAttack(); // Idle 애니메이션
                }

                previousState = unitDetected; // 상태 업데이트
            }
        }
        else
        {
           // Debug.Log("충돌 범위가 카메라 화면 밖입니다.");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((Vector2)Pos.position + Offset, BoxSize);
    }
}
