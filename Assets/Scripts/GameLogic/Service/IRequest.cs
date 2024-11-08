using System;
using System.Threading.Tasks;
using GameLogic.ReferencePool;
using UnityEngine.Profiling.Memory.Experimental;

namespace GameLogic.Service
{
    public interface IRequest : IReference
    {
        int Id { get; }
        string Uri { get; }
        string Method { get; }

        bool Authenticate { get; }
        bool Protection { get; }
        TaskCompletionSource<Response> TaskCompletionSource { get; }

        IRequest SetAuthenticate(bool authenticate);
        IRequest SetProtection(bool protection);
        IRequest SetUri(string uri);
        IRequest SetUri(string uri, params object[] param);
        IRequest SetField(string name, string value);
        IRequest SetField<T>(string name, params T[] value);
        IRequest SetField(string name, int value);
        IRequest SetField(string name, bool value);
        IRequest SetContentType(Type type);
        IRequest SetCallback(Action<Response> callback);
        IRequest SetForwardData(object data);

        MetaData GetUserData();
        RequestData GetRequestData();
    }
}