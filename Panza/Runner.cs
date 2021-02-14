using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Collections.Generic;

namespace org.flauschhaus.Panza {

public class Runner : Game {

private GraphicsDeviceManager _graphics;
private SpriteBatch _spriteBatch;
private List<Tank> _tanks;

public Runner()
{
  _graphics = new GraphicsDeviceManager(this);
  Content.RootDirectory = "Content";
  IsMouseVisible = true;
}

protected override 
void Initialize()
{
  _tanks = new List<Tank>();
  _tanks.Add(new Tank() {
    FileName="tank01",
    Position=new Vector2(50,50)
  });
  _tanks.Add(new Tank() {
    FileName="tank02",
    Position=new Vector2(300,50)
  });

  base.Initialize();
}

protected override 
void LoadContent()
{
  _spriteBatch = new SpriteBatch(GraphicsDevice);

  foreach(Tank tank in _tanks)
  {
    tank.Sprite = Content.Load<Texture2D>(tank.FileName);
  }
}

protected override
void Update(GameTime gameTime)
{
  if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
      Keyboard.GetState().IsKeyDown(Keys.Escape))
    Exit();

  // TODO: Add your update logic here

  base.Update(gameTime);
}

protected override 
void Draw(GameTime gameTime)
{
  GraphicsDevice.Clear(Color.CornflowerBlue);

  _spriteBatch.Begin();
  foreach(Tank tank in _tanks)
    _spriteBatch.Draw(tank.Sprite, tank.Position, Color.White);
  _spriteBatch.End();

  base.Draw(gameTime);
}

} // Runner

} // ns
