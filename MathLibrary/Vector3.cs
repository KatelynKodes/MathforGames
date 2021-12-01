using System;

namespace MathLibrary
{
    public struct Vector3
    {
        public float X;
        public float Y;
        public float Z;

        /// <summary>
        /// Vetor3 Base constructor
        /// </summary>
        /// <param name="xvalue"></param>
        /// <param name="yvalue"></param>
        /// <param name="zvalue"></param>
        public Vector3(float xvalue, float yvalue, float zvalue)
        {
            X = xvalue;
            Y = yvalue;
            Z = zvalue;
        }

        /// <summary>
        /// Returns the length of the vector by returning X * X + Y * Y + Z * Z
        /// </summary>
        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
            }
        }

        /// <summary>
        /// Creates a new vector3 of this vector3, then makes that new Vector2 value
        /// call the Normalize method and returns the Vector3 value of the Normalized method called.
        /// </summary>
        public Vector3 Normalized
        {
            get
            {
                Vector3 value = this;
                return value.Normalize();
            }
        }

        /// <summary>
        /// Returns a float of the vector3's X values being multiplied together
        /// and added to the Vector3's Y values being multiplied together.
        /// then being added to the two vector3's Z values being multiplied together
        /// </summary>
        /// <param name="lhs">The left hand side of the operation</param>
        /// <param name="rhs">THe right hand side of the operation</param>
        /// <returns>The dot product of the first vector on to the second</returns>
        public static float DotProduct(Vector3 lhs, Vector3 rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y) + (lhs.Z * rhs.Z);
        }

        /// <summary>
        /// Checks the distance between two vector 3's
        /// </summary>
        /// <param name="lhs">lefthand side of the equation</param>
        /// <param name="rhs">righthand side of the equation</param>
        /// <returns>The magnitude of the subtraction between both vector3's</returns>
        public static float Distance(Vector3 lhs, Vector3 rhs)
        {
            return (rhs - lhs).Magnitude;
        }

        /// <summary>
        /// Adds two vector3's together
        /// </summary>
        /// <param name="lhs">The lefthand side of the equation</param>
        /// <param name="rhs">The righthand side of the equation</param>
        /// <returns>A new vector3 containing X, Y, and Z values that were added together between two
        /// vector3's</returns>
        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
        }

        /// <summary>
        /// Subtracts a vector3 from another
        /// </summary>
        /// <param name="lhs">The lefthand side of the equation</param>
        /// <param name="rhs">The righthand side of the equation</param>
        /// <returns>A new vector3 containing X, Y, and Z values that were created by subtracting each value
        /// from it's correlating value</returns>
        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
        }

        /// <summary>
        /// Multiplication with a scaler
        /// </summary>
        /// <param name="lhs"> The lefthand side of the equation</param>
        /// <param name="scaler"> The righthand side of the equation</param>
        /// <returns> A new vector3 who's values consist of the solutions to multiplying a vector3 to a scaler
        /// </returns>
        public static Vector3 operator *(Vector3 lhs, float rhs)
        {
            return new Vector3(lhs.X * rhs, lhs.Y * rhs, lhs.Z * rhs);
        }

        /// <summary>
        /// Multiplication with a scaler, reverse order
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector3 operator *(float lhs, Vector3 rhs)
        {
            return new Vector3(lhs * rhs.X, lhs * rhs.Y, lhs * rhs.Z);
        }

        /// <summary>
        /// Multiplication of a matrix3 and a vector3
        /// </summary>
        /// <param name="lhs"> The matrix3 </param>
        /// <param name="rhs"> The Vector3 </param>
        /// <returns></returns>
        public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
        {
            float newX = (lhs.M00 * rhs.X) + (lhs.M01 * rhs.Y) + (lhs.M02 * rhs.Z);
            float newY = (lhs.M10 * rhs.X) + (lhs.M11 * rhs.Y) + (lhs.M12 * rhs.Z);
            float newZ = (lhs.M20 * rhs.X) + (lhs.M21 * rhs.Y) + (lhs.M22 * rhs.Z);
            return new Vector3(newX, newY, newZ);
        }

        /// <summary>
        /// Division with a scaler
        /// </summary>
        /// <param name="lhs"> The lefthand side of the equation</param>
        /// <param name="scaler"> The righthand side of the equation</param>
        /// <returns> A new vector3 who's values consist of the solutions to dividing a vector3 by a scaler
        /// </returns>
        public static Vector3 operator /(Vector3 lhs, float scaler)
        {
            return new Vector3(lhs.X / scaler, lhs.Y / scaler, lhs.Z / scaler);
        }

        /// <summary>
        /// Checks if two vector3's are exactly the same
        /// </summary>
        /// <param name="lhs">The lefthand side of the equation</param>
        /// <param name="rhs">The righthand side of the equation</param>
        /// <returns>True if all three values are the same </returns>
        public static bool operator ==(Vector3 lhs, Vector3 rhs)
        {
            if (lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if two vector3's are not equal to each other
        /// </summary>
        /// <param name="lhs">The lefthand side of the equation</param>
        /// <param name="rhs">The righthand side of the equation</param>
        /// <returns> True if one variable in one Vector3 is not equal to the same variable in the other Vector3</returns>
        public static bool operator !=(Vector3 lhs, Vector3 rhs)
        {
            if (lhs.X != rhs.X || lhs.Y != rhs.Y || lhs.Z != rhs.Z)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns a vector2 containg an instance of a vector divided by the magnitude
        /// </summary>
        /// <returns> The result of the normalization. Returns an empty vector2 if the magnitude is zero</returns>
        public Vector3 Normalize()
        {
            if (Magnitude == 0)
            {
                return new Vector3();
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
        public static Vector3 CrossProduct(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3
            {
                X = (lhs.Y * rhs.Z)-(lhs.Z * rhs.Y),
                Y = (lhs.Z * rhs.X)-(lhs.X * rhs.Z),
                Z = (lhs.X * rhs.Y)-(lhs.Y * rhs.X)
            };
        }
    }
}
