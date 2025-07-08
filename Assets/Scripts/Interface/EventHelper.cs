using UnityEngine;

public static class EventHelper
{
    public static void AutoSubscribe(MonoBehaviour obj)
    {
        if (obj is IEventSubscriber Object) Object.SubscribeEvents();
    }

    public static void AutoUnSubscribe(MonoBehaviour obj)
    {
        if(obj is IEventSubscriber Obj) Obj.UnSubscribeEvents();
    }
}
