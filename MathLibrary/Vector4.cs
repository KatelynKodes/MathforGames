using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    public struct Vector4
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public float Magnitude
        {
            get { return 0; }
        }

        public Vector4 Normalized
        {
            get { return new Vector4(); }
        }

        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public static float DotProduct(Vector4 lhs, Vector4 rhs)
        {
            return;
        }

        public static float Distance(Vector4 lhs, Vector4 rhs)
        {
            return;
        }
    }
}
