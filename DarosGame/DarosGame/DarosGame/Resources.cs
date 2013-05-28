﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace DarosGame {
    public class Resources {
        public static SpriteFont font;

        public static void InitResources(ContentManager cm) {
            font = cm.Load<SpriteFont>("04b03");
        }
    }
}
