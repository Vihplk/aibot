using System.Threading.Tasks;

namespace AIBot.Core.Service.Interface
{
    public interface IService <T>
    {
        Task<T> Read(int request);
        Task<T> Create(T item);
        Task<T> Update(T item);
    }
}
