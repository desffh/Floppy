using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadTester : MonoBehaviour
{

    private void Awake()
    {
        // PlayerPrefs 초기화
        PlayerPrefs.DeleteAll();  // 모든 PlayerPrefs 초기화
        PlayerPrefs.Save();  // 변경사항 저장

        Debug.Log("PlayerPrefs 초기화됨!");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadingSceneController.LoadScene("LobbyScene");
        }
    }
}
