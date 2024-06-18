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
    /// 静态初始化 
    /// </summary>
    static TimeFacade()
    {
        m_instance = new TimeFacade();
    }

    /// <summary>
    /// 获取单例
    /// </summary>
    /// <returns></returns>
    public static TimeFacade GetInstance()
    {
        return m_instance as TimeFacade;
    }

    /// <summary>
    /// 启动MVC
    /// </summary>
    public void Launch()
    {
        //通过command命令启动游戏
        SendNotification(TimeFacade.START_UP);
    }

    /// <summary>
    /// 初始化Controller，完成Notification和Command的映射
    /// </summary>
    protected override void InitializeController()
    {
        base.InitializeController();
        //注册Command
        RegisterCommand(START_UP, typeof(StartUpTimeCommand));

        ///可以写到启动命令里。       
        RegisterCommand(SHOW, typeof(TimeShowCommand));

        Debug.Log("初始化Controller，完成Notification和Command的映射");
        
    }

    /// <summary>
    /// 初台化View,Initializes the view.
    /// View在Model和Controll之后运行
    /// UI的创建我放到Command中执行
    /// </summary>
    protected override void InitializeView()
    {
        base.InitializeView();

        Debug.Log("初台化View,Initializes the view.");
    }

    /// <summary>
    /// 注册Proxy
    /// </summary>
    protected override void InitializeFacade()
    {
        base.InitializeFacade();

        Debug.Log("注册Proxy");
    }

    /// <summary>
    /// 初始化Model 数据模型  Proxy
    /// </summary>
    protected override void InitializeModel()
    {
        base.InitializeModel();
        //也可以放在Command中

        Debug.Log("初始化Model 数据模型  Proxy");

        RegisterProxy(new TimeDataProxy(TimeDataProxy.NAME));
    }

}
