using UnityEngine;

public static class EventHelper
{
    public static void AutoSubscribe(MonoBehaviour obj)
    {
        if (obj is IEventSubscriber s) s.SubscribeEvents();
    }

    public static void AutoUnSubscribe(MonoBehaviour obj)
    {
        if(obj is IEventSubscriber s) s.UnSubscribeEvents();
    }
}
