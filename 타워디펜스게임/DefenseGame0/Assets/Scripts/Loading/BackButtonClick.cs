using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButtonClick : MonoBehaviour
{
    [SerializeField] Button stage1;

    [SerializeField] Button stage2;

    [SerializeField] GameObject QuitMenu;

    private void Awake()
    {
        // 버튼 첫 시작 비활성화 
        stage1.gameObject.SetActive(false);
        stage2.gameObject.SetActive(false);

        QuitMenu.SetActive(false);
    }

    public void OnQuit()
    {
        QuitMenu.SetActive(true);

    }

    public void OnQuitYes()
    {
        Application.Quit();

        // 에디터에서 확인용
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Debug.Log("O");

    }

    public void OnQuitNo()
    {
        QuitMenu.SetActive(false);
        Debug.Log("X");

    }

    public void Stage1Click()
    {
        stage1.gameObject.SetActive(true);
        stage1.interactable = true;
    }
    public void Stage2Click()
    {
        stage2.gameObject.SetActive(true);
        stage2.interactable = true;
    }

    public void OnBackButtonClick()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void Stage1StartClick()
    {
        SceneManager.LoadScene("GameScene1");
        Time.timeScale = 1.0f;

    }
    public void Stage2StartClick()
    {
        SceneManager.LoadScene("GameScene2");
        Time.timeScale = 1.0f;

    }


}
