using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUnitAnime : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        // 자기 자신의 에니메이터 컴포넌트 가져오기 
        animator = GetComponent<Animator>(); // animator 변수를 Player의 Animator 속성으로 초기화
    }


}
