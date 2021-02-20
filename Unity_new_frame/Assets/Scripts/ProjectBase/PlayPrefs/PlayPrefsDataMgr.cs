using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayPrefsDataMgr : BaseManager<PlayPrefsDataMgr>
{
    private static PlayPrefsDataMgr instance = new PlayPrefsDataMgr();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public static PlayPrefsDataMgr Instance
    {
        get
        {
            return instance;
        }
    }
    /// <summary>
    /// 储存数据
    /// </summary>
    /// <param name="data"></param>
    /// <param name="keyName"></param>
    public void SaveData(object data, string keyName)
    {
        //就是要通过 Type 得到传入数据对象的所有的 字段
        //然后结合 PlayerPrefs来进行存储

        Type dataType = data.GetType();
        //得到所有的字段
        FieldInfo[] infos = dataType.GetFields();


        #region 第二步 自己定义一个key的规则 进行数据存储
        //我们存储都是通过PlayerPrefs来进行存储的
        //保证key的唯一性 我们就需要自己定一个key的规则

        //我们自己定一个规则
        // keyName_数据类型_字段类型_字段名
        #endregion

        #region 第三步 遍历这些字段 进行数据存储
        string saveKeyName = "";
        FieldInfo info;
        for (int i = 0; i < infos.Length; i++)
        {
            //对每一个字段 进行数据存储
            //得到具体的字段信息
            info = infos[i];
            //通过FieldInfo可以直接获取到 字段的类型 和字段的名字
            //字段的类型 info.FieldType.Name
            //字段的名字 info.Name;

            //要根据我们定的key的拼接规则 来进行key的生成
            //Player1_PlayerInfo_Int32_age
            saveKeyName = keyName + "_" + dataType.Name +
              "_" + info.FieldType.Name + "_" + info.Name;

            //现在得到了Key 按照我们的规则
            //接下来就要来通过PlayerPrefs来进行存储
            //如何获取值
            //info.GetValue(data)
            //封装了一个方法 专门来存储值 
            SaveValue(info.GetValue(data), saveKeyName);
        }
        #endregion
    }

    private void SaveValue(object value, string keyName)
    {
        //直接通过PlayerPrefs来进行存储了
        //就是根据数据类型的不同 来决定使用哪一个API来进行存储
        //PlayerPrefs只支持3种类型存储 
        //判断 数据类型 是什么类型 然后调用具体的方法来存储
        Type fieldType = value.GetType();

        //类型判断
        //是不是int
        if (fieldType == typeof(int))
        {
            Debug.Log("存储int" + keyName);
            PlayerPrefs.SetInt(keyName, (int)value);
        }
        else if (fieldType == typeof(float))
        {
            Debug.Log("存储float" + keyName);
            PlayerPrefs.SetFloat(keyName, (float)value);
        }
        else if (fieldType == typeof(string))
        {
            Debug.Log("存储string" + keyName);
            PlayerPrefs.SetString(keyName, value.ToString());
        }
        else if (fieldType == typeof(bool))
        {
            Debug.Log("存储bool" + keyName);
            //自己顶一个存储bool的规则
            PlayerPrefs.SetInt(keyName, (bool)value ? 1 : 0);
        }
    }
    /// <summary>
    /// 读取数据
    /// </summary>
    /// <param name="type">想要读取的数据的类型</param>
    /// <param name="keyName">数据对象的唯一key，自己控制</param>
    /// <returns></returns>
    public object LoadData(Type type,string keyName)
    {
        //这里本可以用object当形参的，但是这样做的话，需要调用者传入一个new好的对象
        //用type就解决了上面的问题，直接传入这个类，然后在这内部去new一个对象,这样可以让外面少写一行代码
      
        return null;
    }
}
