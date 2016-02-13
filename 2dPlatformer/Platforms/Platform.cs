using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dPlatformer.Platforms
{
    class Platform
    {
        public PlatformType Type { get; private set; }
        public Texture2D Sprite { get; private set; }

        public Platform(PlatformType type, Texture2D sprite)
        {
            Type = type;
            Sprite = sprite;
        }
    }
}
