﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StickXNAEngine.Graphic {
    public class StaticSprite : Sprite {
        Texture2D tex;
        Rectangle src;
        Point origin;

        public StaticSprite(Texture2D tex) : this(tex, new Point(0, 0)) { }

        public StaticSprite(Texture2D tex, Point origin) : this(tex, origin, new Rectangle(0, 0, tex.Width, tex.Height)) { }

        public StaticSprite(Texture2D tex, Point origin, Rectangle src) {
            this.tex = tex;
            this.origin = origin;
            this.src = src;
        }

        public Rectangle Size {
            get { return new Rectangle(0, 0, src.Width, src.Height); }
        }

        public override void Draw(SpriteBatch sb, Point loc, Vector2 scale) {
            sb.Draw(tex, new Rectangle(loc.X - (int)(origin.X * scale.X), loc.Y - (int)(origin.Y * scale.Y), (int)(src.Width * scale.X), (int)(src.Height * scale.Y)), src, this.Tint); 
        }
    }
}
