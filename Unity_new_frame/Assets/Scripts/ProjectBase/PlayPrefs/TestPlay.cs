using UnityEngine;
using System.Collections;

public class PlayerInfo
{
    public int age = 10;
    public string name = "哈哈哈";
    public float hight = 164.51f;
    public bool sex = true;
    private bool sex1 = true;
    public void okok()
    {
    }
    private void okok1()
    {
    }
}
public class TestPlay : MonoBehaviour
{
   

    void Start()
    {
        PlayerInfo p = new PlayerInfo();
        PlayPrefsDataMgr.GetInstance().SaveData(p, "111");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
