using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult : MonoBehaviour
{
    [SerializeField] GameObject ClearPanel;

    [SerializeField] GameObject LosePanel;

    public int currentstage; // 현재 스테이지 번호


    // 첫 셋팅 비활성화
    private void Awake()
    {
        ClearPanel.SetActive(false);
        LosePanel.SetActive(false);

        currentstage = 1;

    }

    // 승리 패널이 나왔을 경우, 다음 스테이지 오픈
    public void Victory()
    {
        ClearPanel.SetActive(true);

        PlayerPrefs.SetInt("StageReached", currentstage); // 키값과 현재 스테이지 번호 저장
        PlayerPrefs.Save(); // 저장된 데이터를 실제 파일에 저장

        Debug.Log("Saved Stage: " + currentstage); // 현재 저장된 스테이지 출력

        // 다음 스테이지로 증가
        currentstage++;
    }

    public void Lose()
    {
        LosePanel.SetActive(true);
    }
}
