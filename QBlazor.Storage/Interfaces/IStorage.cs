using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QBlazor
{
    public interface ILocalStorage : IStorage
    {
        //string type => "local";
    }

    public interface ISessionStorage : IStorage
    {
        //string type => "session";
    }

    public interface IStorage
    {
        Task Clear();

        Task<bool> Contains<T>(Expression<Func<T>> expression);

        Task<bool> Contains<T>(string key);

        Task<T> Get<T>(Expression<Func<T>> expression);

        Task<T> Get<T>(string key);

        Task<string> Key(int index);

        Task<int> Length();

        Task Remove<T>(Expression<Func<T>> expression);

        Task Remove<T>(string key);

        Task Set<T>(Expression<Func<T>> expression);

        Task Set<T>(string key, object value);
    }
}