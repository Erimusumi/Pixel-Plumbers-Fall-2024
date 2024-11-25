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
    private List<Rectangle> redRectangles;  // List to store red rectangles

    public Layer(int display_tilesize, int num_tile_per_row, int pixel_tilesize, string filepath)
    {
        this.display_tilesize = display_tilesize;
        this.num_tile_per_row = num_tile_per_row;
        this.pixel_tilesize = pixel_tilesize;
        this.filepath = filepath;
        this.tile_array = new Dictionary<Vector2, int>();
        this.redRectangles = new List<Rectangle>();
    }

    // Load the layre from the CSV file
    public void LoadLayer()
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

    // Draw the layer and add red rectangles to the list if conditions are met
    public void Draw(SpriteBatch spriteBatch, Texture2D textureAtlas, Vector2 cameraPosition)
    {
        redRectangles.Clear();
        foreach (var item in tile_array)
        {
            // Calculate the destination rectangle for the tile
            Rectangle drect = new(
                (int)(item.Key.X * display_tilesize - cameraPosition.X),
                (int)(item.Key.Y * display_tilesize - cameraPosition.Y),
                display_tilesize,
                display_tilesize
            );

            // Calculate the source rectangle for the tile in the texture atlas
            int x = item.Value % num_tile_per_row;
            int y = item.Value / num_tile_per_row;

            Rectangle src = new(
                x * pixel_tilesize,
                y * pixel_tilesize,
                pixel_tilesize,
                pixel_tilesize
            );

            // Draw the tile from the texture atlas
            spriteBatch.Draw(textureAtlas, drect, src, Color.White);

            // Add a 16x16 red rectangle if the value is 112 or between 38 and 55
            if ((item.Value == 112 || item.Value == 98 || item.Value == 114 || (item.Value >= 38 && item.Value <= 55))
        && item.Value != 6 && item.Value != 26 && item.Value != 42)
            {
                // Create a fixed 16x16 red rectangle
                Rectangle redRect = new Rectangle(
                    drect.X,
                    drect.Y,
                    16,
                    16
                );

                // Add the red rectangle to the list
                redRectangles.Add(redRect);

                spriteBatch.Draw(
                     textureAtlas,    
                     redRect,        
                     null,            
                     Color.Red,       
                     0f,              
                     Vector2.Zero,    
                     SpriteEffects.None,
                     0f             
                 );
            }
        }
    }

    // Function to return the list of red rectangles for collision handling
    public List<Rectangle> GetRedRectangles()
    {
        return redRectangles;
    }
}
