﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal interface IProjectile
{
    public void Update();
    public void Draw(SpriteBatch sb);
}

