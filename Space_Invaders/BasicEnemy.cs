using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Invaders
{
    public class BasicEnemy : IEnemy
    {
        Rectangle rect;
        byte? explodeCount = null;
        public BasicEnemy(int lvl, int x, int y, int w, int h)
        {
            rect = new Rectangle(x, y, w, h);
        }

        public void DestroyShot()
        {
            throw new NotImplementedException();
        }

        public void Explode()
        {
            throw new NotImplementedException();
        }

        public byte? GetExplodeCount()
        {
            return explodeCount;
        }
        public Rectangle GetRect()
        {
            return rect;
        }
        public void Move(int x, int y)
        {
            rect.X += x;
            rect.Y += y;
        }

        public List<IShot> Shoot()
        {
            List<IShot> shots = new List<IShot>();
            shots.Add(new BasicShot( rect.Left + rect.Width / 2, rect.Bottom, 0, -15));
            return shots;
        }
    }
}
