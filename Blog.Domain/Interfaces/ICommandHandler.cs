using System.Threading.Tasks;
using Blog.Domain.Commands;

namespace Blog.Domain.Interfaces
{
    public interface ICommandHandler<in T> where T: ICommand
    {
        Task Handle(T command);
    }
}