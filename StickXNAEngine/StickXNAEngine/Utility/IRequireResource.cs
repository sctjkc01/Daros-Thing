﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace StickXNAEngine.Utility {
    public interface IRequireResource {
        void LoadRes(ContentManager cm);
    }
}
