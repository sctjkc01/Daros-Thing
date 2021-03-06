﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StickXNAEngine.Graphic;
using StickXNAEngine.Utility;
using Microsoft.Xna.Framework.Content;

namespace DarosGame {
    public abstract class GameObject : IUpdating, IRequireResource, IComparable<GameObject> {
        protected Point location;
        protected int width, height;

        public Rectangle CollisionBox {
            get { return new Rectangle(location.X - (width/2), location.Y - (height/2), width, height); }
        }

        public Point Loc {
            get { return location; }
            set { location = value; }
        }

        public GameObject() {
            PostProcessing.Add((IRequireResource)this);
            PostProcessing.Add((IUpdating)this);
        }

        public abstract void Draw(SpriteBatch sb);

        public abstract void Update(GameTime gt);
        public abstract void LoadRes(ContentManager cm);

        public int CompareTo(GameObject other) {
            return this.Loc.Y.CompareTo(other.Loc.Y);
        }
    }

    public abstract class SimpleGameObject : GameObject {
        protected StaticSprite sprite;

        public override void Draw(SpriteBatch sb) {
            sprite.Draw(sb, new Point(location.X - StaticVars.Camera.X, location.Y - StaticVars.Camera.Y));
        }
    }

    public abstract class Mob : GameObject {
        protected Dictionary<Direction, Sprite> walk = new Dictionary<Direction, Sprite>(), stand = new Dictionary<Direction, Sprite>();
        protected Boolean walking = false;
        protected Direction facing = Direction.SOUTH;

        public override void Draw(SpriteBatch sb) {
            try {
                if(facing != Direction.DENNIS) {
                    if(walking) {
                        walk[facing].Draw(sb, new Point(location.X - StaticVars.Camera.X, location.Y - StaticVars.Camera.Y));
                    } else {
                        stand[facing].Draw(sb, new Point(location.X - StaticVars.Camera.X, location.Y - StaticVars.Camera.Y));
                    }
                }
            } catch(KeyNotFoundException) {
                // Ignore
            }
        }
    }

    public interface IInteractive {
        void Interact();
    }

    public interface ISpecificFacing {
        bool RightFacing(Direction dir);
    }
}
