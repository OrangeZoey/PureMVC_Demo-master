using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFacade : PureMVC.Patterns.Facade
{
    public const string START_UP = "start_up";


    public const string UPDATE_TIME_DATA = "update_time_data";
    public const string REFRESH_BONUS_UI = "refresh_bonus_ui";
    public const string SHOW = "show";


    /// <summary>
    /// ��̬��ʼ�� 
    /// </summary>
    static TimeFacade()
    {
        m_instance = new TimeFacade();
    }

    /// <summary>
    /// ��ȡ����
    /// </summary>
    /// <returns></returns>
    public static TimeFacade GetInstance()
    {
        return m_instance as TimeFacade;
    }

    /// <summary>
    /// ����MVC
    /// </summary>
    public void Launch()
    {
        //ͨ��command����������Ϸ
        SendNotification(TimeFacade.START_UP);
    }

    /// <summary>
    /// ��ʼ��Controller�����Notification��Command��ӳ��
    /// </summary>
    protected override void InitializeController()
    {
        base.InitializeController();
        //ע��Command
        RegisterCommand(START_UP, typeof(StartUpTimeCommand));

        ///����д�����������       
        RegisterCommand(SHOW, typeof(TimeShowCommand));

        Debug.Log("��ʼ��Controller�����Notification��Command��ӳ��");
        
    }

    /// <summary>
    /// ��̨��View,Initializes the view.
    /// View��Model��Controll֮������
    /// UI�Ĵ����ҷŵ�Command��ִ��
    /// </summary>
    protected override void InitializeView()
    {
        base.InitializeView();

        Debug.Log("��̨��View,Initializes the view.");
    }

    /// <summary>
    /// ע��Proxy
    /// </summary>
    protected override void InitializeFacade()
    {
        base.InitializeFacade();

        Debug.Log("ע��Proxy");
    }

    /// <summary>
    /// ��ʼ��Model ����ģ��  Proxy
    /// </summary>
    protected override void InitializeModel()
    {
        base.InitializeModel();
        //Ҳ���Է���Command��

        Debug.Log("��ʼ��Model ����ģ��  Proxy");

        RegisterProxy(new TimeDataProxy(TimeDataProxy.NAME));
    }

}
