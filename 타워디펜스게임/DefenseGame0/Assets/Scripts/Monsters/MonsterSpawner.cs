using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public Transform[] spawnPoints; // 스폰위치 배열 

    //public GameObject Monster;


    [SerializeField] GameObject level1Monster;
    [SerializeField] GameObject level2Monster;
    [SerializeField] GameObject level3Monster;
    [SerializeField] GameObject level4Monster;



    // 몬스터를 순서별로 저장할 큐
    Queue<GameObject> monsterQueue = new Queue<GameObject>();

    private void Awake()
    {
        // level 1 몬스터 5개
        for(int i = 0; i < 5; i++)
        {
            monsterQueue.Enqueue(level1Monster);
        }
        // level 2 몬스터 3개
        for(int i = 0; i < 3; i++)
        {
            monsterQueue.Enqueue(level2Monster);
        }
        // level 3 몬스터 3개
        for (int i = 0; i < 3; i++)
        {
            monsterQueue.Enqueue(level3Monster);
        }
        // level 4 몬스터 3개
        for (int i = 0; i < 3; i++)
        {
            monsterQueue.Enqueue(level4Monster);
        }
        MonsterCount.Instance.monsterCount = monsterQueue.Count;
    }

    private void Start()
    {
        // SpawnMonster함수를 2초후에 5초마다 실행
        InvokeRepeating("SpawnMonster", 2, 5);
    }

    // 스폰 랜덤 위치 몬스터 생성
    void SpawnMonster()
    {
        int ran = Random.Range(0, spawnPoints.Length);

        if(monsterQueue.Count != 0)
        {
            // 큐에서 하나씩 빼기
            GameObject monsterSpawn = monsterQueue.Dequeue();
            
            GameObject myMonster =
                Instantiate(monsterSpawn, spawnPoints[ran].position, Quaternion.identity);
            
            myMonster.transform.SetParent(spawnPoints[ran]);

            // 목적지 설정
            var spawnPointComponent = spawnPoints[ran].GetComponent<SpawnPoint>();

            if (spawnPointComponent != null)
            {
                myMonster.GetComponent<MonsterController>().FinalDestination = spawnPointComponent.Destination;
            }
            else
            {
                Debug.LogError("SpawnPoint 컴포넌트를 찾을 수 없습니다.");
            }
            //MonsterCount.Instance.IncreaseCount(); // 몬스터 카운트 증가
        }
    }
}
