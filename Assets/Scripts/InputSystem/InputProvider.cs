using Zenject;

namespace InputSystem
{
    public class InputProvider
    {
        public InputSystem_Actions InputSystemActions { get; }
        
        [Inject]
        public InputProvider()
        {
            InputSystemActions = new InputSystem_Actions();
            InputSystemActions.Enable();
        }
    }
}