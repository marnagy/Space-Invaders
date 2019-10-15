using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Space_Invaders
{
    public interface IBoss : IEnemy
    {
        int GetMaxLifes();
        void Move(int dim, int bounds, Point playerPoint);
        int GetLifes();
        void RemoveLife();
        List<IShot> Shoot(Player player);
    }
}
