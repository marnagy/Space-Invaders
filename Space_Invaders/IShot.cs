using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Invaders
{
    public interface IShot
    {
        char GetType();
        double GetAngle();
        Point GetPoint();
        bool Multiply();
        List<IShot> GetShots();
        void Update();
    }
}
