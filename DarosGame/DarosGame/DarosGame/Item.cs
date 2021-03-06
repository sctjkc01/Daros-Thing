﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StickXNAEngine.Graphic;
using StickXNAEngine.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DarosGame {
    namespace Item {
        public enum ItemFlags {
            OLD, NEW, CRUDE, GOLD, METAL, STONE, WOOD
        }

        public class GroundItem : SimpleGameObject, IInteractive {
            private Item item;

            public GroundItem(Item item, Point loc) {
                this.item = item;
                location = loc;
                width = 0;
                height = 0;
            }

            public override void Update(Microsoft.Xna.Framework.GameTime gt) {
                // Does not update.
            }

            public override void LoadRes(Microsoft.Xna.Framework.Content.ContentManager cm) {
                // No extra resload
            }

            public void Interact() {
                Convo.Conversation.curr = new Convo.VolatileMethodBlurb("You found a " + item.Name + "!", delegate {
                    try {
                        StaticVars.player.Stats.Inv.Add(item);

                        //Item picked up; remove from room.
                        PostProcessing.updating.Remove(this);
                        StaticVars.CurrRoom.Objects.Remove(this);
                    } catch(Exception) {
                        Convo.Conversation.curr.Next = new Convo.VolatileBlurb("Unfortunately, your pockets are too full.  Drop something first.");
                    }
                });
            }

            public override void Draw(SpriteBatch sb) {
                item.Sprite.Draw(sb, new Point(location.X - StaticVars.Camera.X, location.Y - StaticVars.Camera.Y), new Vector2(0.5f, 0.5f));
            }
        }

        public abstract class Item : IRequireResource {
            public delegate void OnUse();

            protected string name, desc;

            protected OnUse function;
            protected StaticSprite sprite;

            protected List<ItemFlags> flags;

            protected bool consumed = false;

            public String Name {
                get { return name; }
            }

            public String Desc {
                get { return desc; }
            }

            public StaticSprite Sprite {
                get { return sprite; }
            }

            public bool Use() {
                function();
                return consumed;
            }

            public Item() {
                PostProcessing.Add((IRequireResource)this);
            }

            public abstract void LoadRes(Microsoft.Xna.Framework.Content.ContentManager cm);
        }



        public class Orange : Item {

            public Orange() {
                name = "Orange";
                desc = "Just an orange.";
            }

            public override void LoadRes(Microsoft.Xna.Framework.Content.ContentManager cm) {
                sprite = new StaticSprite(cm.Load<Texture2D>("test/orange"));
            }
        }

        public class LoadedDice : Item {
            public LoadedDice() {
                name = "Loaded Dice";
                desc = "tbd";
            }

            public override void LoadRes(Microsoft.Xna.Framework.Content.ContentManager cm) {
                sprite = new StaticSprite(cm.Load<Texture2D>("Items/I - Loaded Dice"));
            }
        }

        public class PrettyOkayAlloy : Item {
            public PrettyOkayAlloy() {
                name = "Pretty Okay Alloy";
                desc = "tbd";
            }

            public override void LoadRes(Microsoft.Xna.Framework.Content.ContentManager cm) {
                sprite = new StaticSprite(cm.Load<Texture2D>("Items/I - Pretty Okay Alloy"));
            }
        }

        public class WreckedRobotHead : Item {
            public WreckedRobotHead() {
                name = "Wrecked Robot Head";
                desc = "tbd";
            }

            public override void LoadRes(Microsoft.Xna.Framework.Content.ContentManager cm) {
                sprite = new StaticSprite(cm.Load<Texture2D>("Items/I - Wrecked Robot Head"));
            }
        }
    }
}
