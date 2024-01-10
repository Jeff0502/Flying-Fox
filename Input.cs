using Microsoft.Xna.Framework.Input;

namespace FlyingFox
{
    internal class Input
    {
        private static KeyboardState oldState;

        private static KeyboardState newState;

        public bool GetState(Keys key)
        {
            return newState.IsKeyDown(key);
        }

        public static bool WasKeyPressed(Keys key)
        {
            newState = Keyboard.GetState();

            bool oldKeyState = oldState.IsKeyDown(key);

            bool newKeyState = newState.IsKeyDown(key);

            oldState = newState;

            if (oldKeyState == false && newKeyState == true)
                return true;

            else
                return false;
        }
    }
}
