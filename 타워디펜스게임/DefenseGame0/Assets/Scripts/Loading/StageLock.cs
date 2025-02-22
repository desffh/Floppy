using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StageLock : MonoBehaviour
{
    [SerializeField] Button[] buttons;

    // 현재 스테이지 번호
    public int stage = 0;

    private void Awake()
    {
 
        // 패널의 자식 게임 오브젝트들의 버튼 컴포넌트 가져오기
        // 버튼 배열
        //buttons = GetComponentsInChildren<Button>();

        // 현재 클리어 한 키값 가져오기
        stage = PlayerPrefs.GetInt("StageReached");

        Debug.Log("Loaded Stage: " + stage); // 로드된 스테이지 값 출력

        // 스테이지들의 버튼 컴포넌트 비활성화
        for (int i = stage + 1; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
    }

}
