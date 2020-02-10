﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MiniMiner
{
    public class GestorDePantallas : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        PantallaDeBienvenida bienvenida;
        PantallaDeJuego juego;

        public enum MODO { BIENVENIDA, JUEGO };
        public MODO modoActual { get; set; }

        public GestorDePantallas()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            graphics.ApplyChanges();

            juego = new PantallaDeJuego(1024, 768);
            bienvenida = new PantallaDeBienvenida(this);

            modoActual = MODO.BIENVENIDA;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            juego.CargarContenidos(Content);
            bienvenida.CargarContenidos(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                    || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                if (modoActual == MODO.JUEGO)
                {
                    modoActual = MODO.BIENVENIDA;
                    juego.CargarContenidos(Content);
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.F11))
            {
                graphics.IsFullScreen = !graphics.IsFullScreen;
                graphics.ApplyChanges();
            }

            switch (modoActual)
            {
                case MODO.JUEGO: juego.Actualizar(gameTime); break;
                case MODO.BIENVENIDA: bienvenida.Actualizar(gameTime); break;
            }
            if (juego.Terminado)
                modoActual = MODO.BIENVENIDA;

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            switch (modoActual)
            {
                case MODO.JUEGO: juego.Dibujar(gameTime, spriteBatch); break;
                case MODO.BIENVENIDA: bienvenida.Dibujar(gameTime, spriteBatch); break;
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}