public interface IStateSwitcher
{
    void SwitchState<State>() where State : IState;     // Интерфейс переклюючателя состояний
                                                        // State - тип который будем реализовывать/
                                                        // <State> а не <T> - ограничивает интерфейс только этим типом
}
