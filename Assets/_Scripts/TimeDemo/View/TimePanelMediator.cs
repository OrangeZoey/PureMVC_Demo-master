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

        //ǰ��ֻ��ViewComponent��ʼ���ɹ����ſ��Խ���UI�Ĳ���
        //���¼�
        View = ((GameObject)ViewComponent).GetComponent<TimePanelView>();
        Debug.Log("panel mediator");
        timeData = Facade.RetrieveProxy(TimeDataProxy.NAME) as TimeDataProxy;

        //�󶨰�ť�¼�
        View.Button_Show.onClick.AddListener(OnClickShow);

    }

    /// <summary>
    /// ������Ϣ
    /// </summary>
    /// <param name="notification"></param>
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case TimeFacade.REFRESH_BONUS_UI:
                //�˴�ҵ���߼����Է���Command��ʵ�֣�Mediator�Ĺ��ܾ�����
                Debug.Log("REFRESH_BONUS_UI");

                //��ʾ��ǰ�Ĵ���
                if (!View.isActiveAndEnabled)
                {
                    View.gameObject.SetActive(true);
                }
                break;
            case TimeFacade.UPDATE_TIME_DATA:
                {
                    //����UI
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
        //Ϊ�˲��Թ��ܣ�ʹ��command��ʽʵ��
        SendNotification(TimeFacade.SHOW);
    }

    /// <summary>
    /// �¼����� 
    /// ������ΪNull�������޷�ע��
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
