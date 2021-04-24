using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FindConfiner : MonoBehaviour
{

    public CinemachineConfiner confiner;

    void Start()
    {
        confiner.m_BoundingShape2D = GameObject.FindGameObjectWithTag("Confiner").GetComponent<Collider2D>();
    }
    
}
