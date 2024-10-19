using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Layer
{
    private int display_tilesize;
    private int num_tile_per_row;
    private int pixel_tilesize;
    private string filepath;
    private Dictionary<Vector2, int> tile_array;
    public Layer(int display_tilesize, int num_tile_per_row, int pixel_tilesize, string filepath)
    {
        this.display_tilesize = display_tilesize;
        this.num_tile_per_row = num_tile_per_row;
        this.pixel_tilesize = pixel_tilesize;
        this.filepath = filepath;
        this.tile_array = new Dictionary<Vector2, int>();
    }
    public void LoadMap()
    {
        StreamReader reader = new(filepath);

        int y = 0;
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            string[] items = line.Split(',');

            for (int x = 0; x < items.Length; x++)
            {
                if (int.TryParse(items[x], out int value))
                {
                    if (value > -1)
                    {
                        tile_array[new Vector2(x, y)] = value;
                    }
                }
            }

            y++;
        }
    }

    public void Draw(SpriteBatch spriteBatch, Texture2D textureAtlas)
    {
        spriteBatch.Begin();
        foreach (var item in tile_array)
        {
            Rectangle drect = new(
                (int)item.Key.X * display_tilesize,
                (int)item.Key.Y * display_tilesize,
                display_tilesize,
                display_tilesize
            );

            int x = item.Value % num_tile_per_row;
            int y = item.Value / num_tile_per_row;

            Rectangle src = new(
                x * pixel_tilesize,
                y * pixel_tilesize,
                pixel_tilesize,
                pixel_tilesize
            );

            spriteBatch.Draw(textureAtlas, drect, src, Color.White);
        }
        spriteBatch.End();
    }
}