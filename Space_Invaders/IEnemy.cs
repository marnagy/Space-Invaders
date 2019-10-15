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
    public interface IEnemy
    {
        Rectangle GetRect();
        void Move(int x, int y = 0);
        List<IShot> Shoot();
    }
}
