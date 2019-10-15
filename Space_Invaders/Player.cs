﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Space_Invaders
{
    public class Player
    {
        byte lives;
        bool alive, show;
        bool leftKeyDown = false, rightKeyDown = false;
        int shotSpeed;
        public int score { get; private set; }
        public int counter { get; private set; }
        BasicShot shot;
        Rectangle rect;
        Stopwatch stopwatch;

        MovementDirection movement;
        Keys shootKeyCode = Keys.J, leftKeyCode = Keys.A, rightKeyCode = Keys.D;
        //x,y are in the left-upper corner
        public Player(int x, int y, int w, int h, int shotSpeed)
        {
            rect = new Rectangle(x, y, w, h);
            movement = MovementDirection.dontMove;
            shot = null;
            alive = true;
            show = true;
            this.shotSpeed = shotSpeed;
            score = 0;
            counter = 0;
            stopwatch = new Stopwatch();
            stopwatch.Reset();
        }
        public Rectangle GetRectangle()
        {
            return rect;
        }
        public void SetLives(int number)
        {
            lives = (byte)number;
        }
        public bool Show()
        {
            if (stopwatch.IsRunning && stopwatch.ElapsedMilliseconds < 2000)
            {
                counter += 1;
                if (counter == 5)
                {
                    show = !show;
                    counter = 0;
                }
            }
            else
            {
                stopwatch.Reset();
                show = true;
                counter = 0;
            }
            return show;
        }
        public Point GetPoint()
        {
            Point point = new Point();
            point.X = rect.Left + (rect.Width / 2);
            point.Y = rect.Top + (rect.Height / 2);
            return point;
        }
        public IShot GetShot()
        {
            return shot;
        }
        public void DestroyShot()
        {
            shot = null;
        }
        public void RaiseScore(int i)
        {
            score += i;
        }
        public bool IsAlive()
        {
            return alive;
        }
        public void Move(int x, int y = 0)
        {
            rect.X += x;
            rect.Y += y;
        }
        public MovementDirection GetMovement()
        {
            return movement;
        }
        public void resolveKey(Keys keyCode) //needed for ressolving non-letter keys(for example Space)
        {
            switch (keyCode)
            {
                case Keys.D:
                    movement = MovementDirection.moveRight;
                    rightKeyDown = true;
                    break;
                case Keys.A:
                    movement = MovementDirection.moveLeft;
                    leftKeyDown = true;
                    break;
                case Keys.J:
                    if (shot == null)
                    {
                        shot = new BasicShot( rect.Left + rect.Width / 2, rect.Top, 0, 15);
                    }
                    break;
            }
        }
        public void stopMoving(Keys keyCode)
        {
            switch (keyCode)
            {
                case Keys.A:
                    leftKeyDown = false;
                    if (rightKeyDown)
                    {
                        movement = MovementDirection.moveRight;
                    }
                    else
                    {
                        movement = MovementDirection.dontMove;
                    }
                    break;
                case Keys.D:
                    rightKeyDown = false;
                    if (leftKeyDown)
                    {
                        movement = MovementDirection.moveLeft;
                    }
                    else
                    {
                        movement = MovementDirection.dontMove;
                    }
                    break;
                default:
                    //not a key for moving
                    break;
            }
        }
        public void RemoveLife()
        {
            if (!stopwatch.IsRunning)
            {
                lives -= 1;
                stopwatch.Start();
                if (lives == 0)
                {
                    alive = false;
                }
            }
        }
        public int GetLives()
        {
            return lives;
        }
    }
}
