﻿using static DNAI.AStar.AStar;

namespace Assets.Scripts.Pacman
{
    public static class Extensions
    {
        public static string Display(this Position p)
        {
            return p.X + " " + p.Y + " " + p.Z;
        }
    }
}