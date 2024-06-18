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
        //����PureMVC�����Controller��Proxies��Mediators�ĳ�ʼ������
        TimeFacade.GetInstance().Launch();
    }
}
