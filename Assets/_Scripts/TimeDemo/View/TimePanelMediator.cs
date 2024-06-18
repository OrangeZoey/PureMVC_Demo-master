using PureMVC.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePanelMediator : PureMVC.Patterns.Mediator
{
    public new const string NAME = "TimePanelMediator";

    private TimePanelView View;

    TimeDataProxy timeData;

    public TimePanelMediator(object viewComponent) : base(NAME, viewComponent)
    {

        //前提只有ViewComponent初始化成功，才可以进行UI的操作
        //绑定事件
        View = ((GameObject)ViewComponent).GetComponent<TimePanelView>();
        Debug.Log("panel mediator");
        timeData = Facade.RetrieveProxy(TimeDataProxy.NAME) as TimeDataProxy;

        //绑定按钮事件
        View.Button_Show.onClick.AddListener(OnClickShow);

    }

    /// <summary>
    /// 监听消息
    /// </summary>
    /// <param name="notification"></param>
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case TimeFacade.REFRESH_BONUS_UI:
                //此处业务逻辑可以放在Command中实现，Mediator的功能尽量简单
                Debug.Log("REFRESH_BONUS_UI");

                //显示当前的窗本
                if (!View.isActiveAndEnabled)
                {
                    View.gameObject.SetActive(true);
                }
                break;
            case TimeFacade.UPDATE_TIME_DATA:
                {
                    //更新UI
                    if (timeData != null)
                    {
                        View.Text_Time.text = string.Format(timeData.TimeData.Hour + ":" + timeData.TimeData.Minute + ":" + timeData.TimeData.Seconds);
                    }

                }
                break;
        }
    }


    private void OnClickShow()
    {
        Debug.Log("show time");
        //为了测试功能，使用command方式实现
        SendNotification(TimeFacade.SHOW);
    }

    /// <summary>
    /// 事件监听 
    /// 不可以为Null，否则无法注册
    /// </summary>
    /// <returns></returns>
    public override IList<string> ListNotificationInterests()
    {
        IList<string> list = new List<string>()
            {
                TimeFacade.REFRESH_BONUS_UI,
                TimeFacade.UPDATE_TIME_DATA,
               // MyFacade.UPDATE_PLAYER_DATA
            };

        return list;
    }

}
