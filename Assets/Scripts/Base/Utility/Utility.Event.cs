using System;
using System.Reflection;

namespace Base.Utility
{
    public static partial class Utility
    {
        public static class Event
        {
            public static void VerifyWhenAddEvent(Delegate eventHandler, object target, MethodInfo methodInfo)
            {
                if (eventHandler == null || target == null)
                {
                    return;
                }

                var list = eventHandler.GetInvocationList();
                foreach (var item in list)
                {
                    if (item.Target != target)
                    {
                        continue;
                    }

                    throw new GameDKException(
                        $"{target.GetType().FullName}:{methodInfo.Name} had already been added to this event");
                }
            }

            public static void VerifyWhenRemoveEvent(Delegate eventHandler, object target, MethodInfo methodInfo)
            {
                if (eventHandler == null || target == null)
                {
                    return;
                }

                var list = eventHandler.GetInvocationList();
                foreach (var item in list)
                {
                    if (item.Target == target)
                    {
                        return;
                    }
                }

                throw new GameDKException(
                    $"{target.GetType().FullName}:{methodInfo.Name} had not already been added to this event");
            }
        }
    }
}