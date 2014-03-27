using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BitSits_Framework
{
    /// <summary>
    /// The pause menu comes up over the top of the game,
    /// giving the player options to resume or quit.
    /// </summary>
    class PauseMenuScreen : MenuScreen
    {
        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public PauseMenuScreen()
            : base("Paused", new Vector2(350, 50))
        {
            // Flag that there is no need for the game to transition
            // off when the pause menu is on top of it.
            IsPopup = true;
        }

        public override void LoadContent()
        {
            // Create our menu entries.
            MenuEntry resumeGameMenuEntry = new MenuEntry(this, "Resume Game", new Vector2(300, 450));
            MenuEntry quitGameMenuEntry = new MenuEntry(this, "Back to Main Menu", new Vector2(250, 500));

            // Hook up menu event handlers.
            resumeGameMenuEntry.Selected += OnCancel;
            quitGameMenuEntry.Selected += QuitGameMenuEntrySelected;

            // Add entries to the menu.
            MenuEntries.Add(resumeGameMenuEntry);
            MenuEntries.Add(quitGameMenuEntry);
        }

        #endregion

        #region Handle Input


        /// <summary>
        /// Event handler for when the Quit Game menu entry is selected.
        /// </summary>
        void QuitGameMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            LoadingScreen.Load(ScreenManager, false, null, new QuickMenuScreen());
        }


        #endregion

        #region Draw


        /// <summary>
        /// Draws the pause menu screen. This darkens down the gameplay screen
        /// that is underneath us, and then chains to the base MenuScreen.Draw.
        /// </summary>
        public override void Draw(GameTime gameTime)
        {
            ScreenManager.FadeBackBufferToBlack(TransitionAlpha * 2 / 3);

            ScreenManager.SpriteBatch.Begin();
            ScreenManager.SpriteBatch.Draw(ScreenManager.GameContent.tutorial, Vector2.Zero,
                new Color(Color.White, TransitionAlpha));
            ScreenManager.SpriteBatch.End();

            base.Draw(gameTime);
        }


        #endregion
    }
}
