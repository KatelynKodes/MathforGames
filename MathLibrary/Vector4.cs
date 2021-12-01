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

        /// <summary>
        /// Returns the length of the vector by returning X * X + Y * Y + Z * Z
        /// </summary>
        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt((X * X) + (Y * Y) + (Z * Z) + (W * W));
            }
        }

        /// <summary>
        /// Creates a new vector4 of this vector4, then makes that new Vector4 value
        /// call the Normalize method and returns the Vector4 value of the Normalized method called.
        /// </summary>
        public Vector4 Normalized
        {
            get 
            {
                Vector4 value = this;
                return value.Normalize();
            }
        }

        /// <summary>
        /// Vetor4 Base constructor
        /// </summary>
        /// <param name="x">x value </param>
        /// <param name="y">y value </param>
        /// <param name="z">z value </param>
        /// <param name="w">w value </param>
        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Adds two vector4's together
        /// </summary>
        /// <param name="lhs">The lefthand side of the equation</param>
        /// <param name="rhs">The righthand side of the equation</param>
        /// <returns>A new vector3 containing X, Y, and Z values that were added together between two
        /// vector3's</returns>
        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z, lhs.W + rhs.W);
        }

        /// <summary>
        /// Subtracts a vector4 from another
        /// </summary>
        /// <param name="lhs">The lefthand side of the equation</param>
        /// <param name="rhs">The righthand side of the equation</param>
        /// <returns>A new vector3 containing X, Y, and Z values that were created by subtracting each value
        /// from it's correlating value</returns>
        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z, lhs.W - rhs.W);
        }

        /// <summary>
        /// Multiplication of a vector 4 with a scaler
        /// </summary>
        /// <param name="lhs"> The lefthand side of the equation</param>
        /// <param name="scaler"> The righthand side of the equation</param>
        /// <returns> A new vector4 who's values consist of the solutions to multiplying a vector4 to a scaler
        /// </returns>
        public static Vector4 operator *(Vector4 lhs, float rhs)
        {
            return new Vector4(lhs.X * rhs, lhs.Y * rhs, lhs.Z * rhs, lhs.W * rhs);
        }

        /// <summary>
        /// Multiplication of a vector 4 and a scaler, reversed
        /// </summary>
        /// <param name="lhs"> The lefthand side of the equation </param>
        /// <param name="rhs"> The righthand side of the equation</param>
        /// <returns></returns>
        public static Vector4 operator *(float lhs, Vector4 rhs)
        {
            return new Vector4(lhs * rhs.X, lhs * rhs.Y, lhs * rhs.Z, lhs * rhs.W);
        }

        /// <summary>
        /// Multiplication of a vector 4 and another vector4
        /// </summary>
        /// <param name="lhs"> The lefthand side of the equation </param>
        /// <param name="rhs"> The righthand side of the equation</param>
        /// <returns></returns>
        public static Vector4 operator *(Matrix4 lhs, Vector4 rhs)
        {
            float newX = (lhs.M00 * rhs.X) + (lhs.M01 * rhs.Y) + (lhs.M02 * rhs.Z) + (lhs.M03 * rhs.W);
            float newY = (lhs.M10 * rhs.X) + (lhs.M11 * rhs.Y) + (lhs.M12 * rhs.Z) + (lhs.M13 * rhs.W);
            float newZ = (lhs.M20 * rhs.X) + (lhs.M21 * rhs.Y) + (lhs.M22 * rhs.Z) + (lhs.M23 * rhs.W);
            float newW = (lhs.M30 * rhs.X) + (lhs.M31 * rhs.Y) + (lhs.M32 * rhs.Z) + (lhs.M33 * rhs.W);

            return new Vector4(newX, newY, newZ, newW);
        }

        /// <summary>
        /// Division with a scaler
        /// </summary>
        /// <param name="lhs"> The lefthand side of the equation</param>
        /// <param name="scalar"> The righthand side of the equation</param>
        /// <returns> A new vector3 who's values consist of the solutions to dividing a vector3 by a scaler
        /// </returns>
        public static Vector4 operator /(Vector4 lhs, float scalar)
        {
            return new Vector4(lhs.X/scalar, lhs.Y/scalar, lhs.Z/scalar, lhs.W/scalar);
        }

        /// <summary>
        /// Returns a float of the vector4's X values being multiplied together
        /// and added to the Vector4's Y values being multiplied together.
        /// then being added to the two vector4's Z values being multiplied together
        /// </summary>
        /// <param name="lhs">The left hand side of the operation</param>
        /// <param name="rhs">THe right hand side of the operation</param>
        /// <returns>The dot product of the first vector on to the second</returns>
        public static float DotProduct(Vector4 lhs, Vector4 rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y) + (lhs.Z * rhs.Z) + (lhs.W * rhs.W);
        }

        /// <summary>
        /// Finds the distance between two vectors 
        /// </summary>
        /// <param name="lhs">The left hand side of the operation</param>
        /// <param name="rhs">THe right hand side of the operation</param>
        /// <returns> Returns the magnitude of one vector subtracted from another </returns>
        public static float Distance(Vector4 lhs, Vector4 rhs)
        {
            return (lhs-rhs).Magnitude;
        }

        /// <summary>
        /// Returns a vector2 containg an instance of a vector divided by the magnitude
        /// </summary>
        /// <returns> The result of the normalization. Returns an empty vector2 if the magnitude is zero</returns>
        public Vector4 Normalize()
        {
            if (Magnitude == 0)
            {
                return new Vector4();
            }

            return this /= Magnitude;
        }

        /// <summary>
        /// Returns a new vector3 with the three values being equal to the result of the addition of the multiplication
        /// of the two remaining values with the negative result of that multiplication
        /// </summary>
        /// <param name="lhs"> The lefthand side of the equation </param>
        /// <param name="rhs"> The righthand side of the equation </param>
        /// <returns> A new Vector3 </returns>
        public static Vector4 CrossProduct(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4
            {
                X = (lhs.Y * rhs.Z) - (lhs.Z * rhs.Y),
                Y = (lhs.Z * rhs.X) - (lhs.X * rhs.Z),
                Z = (lhs.X * rhs.Y) - (lhs.Y * rhs.X),
                W = 0
            };
        }
    }
}
