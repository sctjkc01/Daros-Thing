﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace StickXNAEngine.Graphic {
    public abstract class Sprite {
        Color tint;

        public Color Tint {
            get { return tint; }
            set { tint = value; }
        }

        public Sprite() {
            tint = Color.White;
        }

        /// <summary>
        /// Draw this sprite.
        /// </summary>
        /// <param name="sb">The SpriteBatch to draw with.</param>
        /// <param name="loc">The location to draw this at.</param>
        /// <param name="scale">What scale to use.</param>
        public abstract void Draw(SpriteBatch sb, Point loc, float scale = 1.0f);
    }
}