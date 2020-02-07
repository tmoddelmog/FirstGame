using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonoGameWindowsStarter
{
    class Ball
    {
        Game1 game;
        Texture2D texture;
        public BoundingCircle bounds;
        public Vector2 velocity;

        public Ball(Game1 game)
        {
            this.game = game;
        }

        public void Initialize()
        {
            bounds.Radius = 25;
            bounds.X = game.GraphicsDevice.Viewport.Width / 2;
            bounds.Y = game.GraphicsDevice.Viewport.Height / 2;

            velocity = new Vector2(
                (float)game.rand.NextDouble(),
                (float)game.rand.NextDouble()
            );
            // velocity = new Vector2(-1, -1);
            velocity.Normalize();
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("ball");
        }

        public void Update(GameTime gameTime)
        {
            var viewport = game.GraphicsDevice.Viewport;

            bounds.Center += 0.5f * (float)gameTime.ElapsedGameTime.TotalMilliseconds * velocity;

            if (bounds.Center.Y < bounds.Radius)
            {
                velocity.Y *= -1;
                float delta = bounds.Radius - bounds.Y;
                bounds.Y += 2 * delta;
            }
            if (bounds.Center.Y > viewport.Height - bounds.Radius)
            {
                velocity.Y *= -1;
                float delta = viewport.Height - bounds.Radius - bounds.Y;
                bounds.Y += 2 * delta;
            }
            if (bounds.X < 0)
            {
                velocity = Vector2.Zero;
            }
            if (bounds.X > viewport.Width - bounds.Radius)
            {
                velocity.X *= -1;
                float delta = viewport.Width - bounds.Radius - bounds.X;
                bounds.X += 2 * delta;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bounds, Color.White);
        }
    }
}
