using MediatR;

namespace Food.Abstractions
{
    public interface ICommand : IRequest
    {
        
    }

    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
        
    }
    
    public interface ICommandHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse> 
        where TRequest : IRequest<TResponse>
    {
        
    }
}