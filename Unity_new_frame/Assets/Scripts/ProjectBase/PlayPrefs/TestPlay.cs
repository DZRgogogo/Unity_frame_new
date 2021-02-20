using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInfo
{
    public int age = 10;
    public string name = "哈哈哈";
    public float hight = 164.51f;
    public bool sex = true;
    private bool sex1 = true;
    public List<int> list = new List<int>() { 1,2,3,4};
}
public class TestPlay : MonoBehaviour
{
   

    void Start()
    {
        PlayerInfo p = new PlayerInfo();
        PlayPrefsDataMgr.GetInstance().SaveData(p, "Dzr");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
