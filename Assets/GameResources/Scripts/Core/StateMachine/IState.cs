namespace GameResources.Scripts.Core.StateMachine
{
    /// <summary>
    /// Интерфейс для реализации входа
    /// </summary>
    public interface IState : IExitableState
    {
        void Enter();
    }
    
    /// <summary>
    /// Интерфейс для реализации входа c параметром
    /// </summary>
    public interface IPayloadedState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }
    
    /// <summary>
    /// Интерфейс для реализации выхода
    /// </summary>
    public interface IExitableState
    {
        void Exit();
    }
    
    
}