using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject GameObject;

    private void Awake()
    {
        GameObject = GetComponent<GameObject>();
    }


}
