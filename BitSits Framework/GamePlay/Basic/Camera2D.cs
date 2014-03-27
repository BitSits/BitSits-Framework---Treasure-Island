using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace BitSits_Framework
{
    /// <summary>
    /// Very basic sample program for demonstrating a 2D Camera
    /// Controls are WASD for movement, QE for rotation, and ZC for zooming.
    /// </summary>
    class Camera2D
    {
        Vector2 viewportSize;
        bool ManualCamera = false, isMovingUsingScreenAxis = true;

        public Vector2 Position, ScrollArea, ScrollBar, Origin;
        public float Rotation, Scale = 1, Speed = 0;

        public Vector2 Velocity;


        public Camera2D(Vector2 viewportSize)
        {
            this.viewportSize = ScrollArea = viewportSize;

            ScrollBar = new Vector2(10);

            Origin = Position = viewportSize / 2;
        }

        public Matrix Transform
        {
            get
            {
                return Matrix.CreateTranslation(new Vector3(-Position, 0))
                    * Matrix.CreateRotationZ(-Rotation) * Matrix.CreateScale(new Vector3(Scale, Scale, 0))
                    * Matrix.CreateTranslation(new Vector3(Origin, 0));
            }
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void HandleInput(InputState input, int playerIndex)
        {
            if (ManualCamera)
            {
                //translation controls WASD
                if (input.CurrentKeyboardStates[0].IsKeyDown(Keys.A)) Position.X += Speed;
                if (input.CurrentKeyboardStates[0].IsKeyDown(Keys.D)) Position.X -= Speed;
                if (input.CurrentKeyboardStates[0].IsKeyDown(Keys.S)) Position.Y -= Speed;
                if (input.CurrentKeyboardStates[0].IsKeyDown(Keys.W)) Position.Y += Speed;

                //rotation controls QE
                if (input.CurrentKeyboardStates[0].IsKeyDown(Keys.Q)) Rotation += 0.01f;
                if (input.CurrentKeyboardStates[0].IsKeyDown(Keys.E)) Rotation -= 0.01f;

                //zoom/scale controls CZ
                if (input.CurrentKeyboardStates[0].IsKeyDown(Keys.C)) Scale += 0.001f;
                if (input.CurrentKeyboardStates[0].IsKeyDown(Keys.Z)) Scale -= 0.001f;
            }
        }
    }
}
