using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDataProxy : PureMVC.Patterns.Proxy
{
    public new static string NAME = "TimeDataProxy";

    public TimeDataModel TimeData;

    public TimeDataProxy(string name)
        : base(name, null)
    {
        TimeData = new TimeDataModel();
    }

    internal void GetNowTime()
    {
        TimeData.Hour=DateTime.Now.Hour;
        TimeData.Minute=DateTime.Now.Minute;
        TimeData.Seconds=DateTime.Now.Second;

        SendNotification(TimeFacade.UPDATE_TIME_DATA);
    }
}
