using PureMVC.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeShowCommand : PureMVC.Patterns.SimpleCommand
{

    public override void Execute(INotification notification)
    {
      
        //��ȡ��ǰʱ��
        TimeDataProxy timeData = Facade.RetrieveProxy(TimeDataProxy.NAME) as TimeDataProxy;
        if (timeData != null)
        {
            timeData.GetNowTime();
            Debug.Log("================TimeShowCommand");
        }


    }
}
