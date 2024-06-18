using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeApp : MonoBehaviour
{
    private static TimeApp _instance;

    public static TimeApp GetInstance()
    {
        return _instance;
    }
    void Awake()
    {
        _instance = this;
        //启动PureMVC，完成Controller，Proxies，Mediators的初始化工作
        TimeFacade.GetInstance().Launch();
    }
}
