using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework;



public class Ground
{
    private List<Rectangle> emptyRectangles;

    public Ground(List<Rectangle> emptyRects)
    {
        this.emptyRectangles = emptyRects;
    }

    public void addEmptyGround(Rectangle emptyFloorRectangle)
    {
        emptyRectangles.Add(emptyFloorRectangle);

    }
    public void removeEmptyGround(Rectangle emptyFloorRectangle)
    {
        emptyRectangles.Remove(emptyFloorRectangle);
    }

    public List<Rectangle> emptyGroundList()
    {
        return emptyRectangles;
    }
    public void clearEmptyRectangleList()
    {
        emptyRectangles.Clear();
    }

}

