using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManuscritMenuManage : MonoBehaviour
{
    public PlayerScript player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerScript>();

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void BraceletUnlock1()
    {

    }

    public void BraceletUnlock2()
    {

    }

    public void BraceletUnlock3()
    {

    }

    public void MaxPV120()
    {
        if (player.maxHealth == 120)
        {
            player.SetMaxHealth(120);
        }
    }

    public void MaxPV140()
    {
        if (player.maxHealth == 120)
        {
            player.SetMaxHealth(140);
        }
    }

    public void MaxPV160()
    {
        if (player.maxHealth == 140)
        {
            player.SetMaxHealth(160);
        }
    }

    public void slowCast20()
    {

    }
    public void slowCast40()
    {

    }
    public void slowCast80()
    {

    }

    public void pageblanche1()
    {

    }

    public void pageblanche2()
    {

    }

    public void minimumlevelrune()
    {

    }

    public void lifegainonkill1()
    {

    }

    public void lifegainonkill2()
    {

    }

    public void lifegainonkill3()
    {

    }
}
