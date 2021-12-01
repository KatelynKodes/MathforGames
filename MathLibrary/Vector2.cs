﻿using System;

namespace MathLibrary
{
    public struct Vector2
    {
        // Variables
        public float X;
        public float Y;

        /// <summary>
        /// Vetor2 Base constructor
        /// </summary>
        /// <param name="xValue"></param>
        /// <param name="yValue"></param>
        public Vector2(float xValue, float yValue)
        {
            X = xValue;
            Y = yValue;
        }

        /// <summary>
        /// Returns the length of the vector by returning X * X + Y * Y
        /// </summary>
        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(X * X + Y * Y);
            }
        }

        /// <summary>
        /// Creates a new vector2 of this vector2, then makes that new Vector2 value
        /// call the Normalize method and returns the Vector2 value of the Normalized method called.
        /// </summary>
        public Vector2 Normalized
        {
            get
            {
                Vector2 value = this;
                return value.Normalize();
            }
        }

        /// <summary>
        /// Returns a float of the vector2's X values being multiplied together
        /// and added to the Vector2's Y values being multiplied together.
        /// </summary>
        /// <param name="lhs">The left hand side of the operation</param>
        /// <param name="rhs">THe right hand side of the operation</param>
        /// <returns>The dot product of the first vector on to the second</returns>
        public static float DotProduct(Vector2 lhs, Vector2 rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y);
        }

        /// <summary>
        /// Finds the distance from the first vector to the second
        /// </summary>
        /// <param name="lhs">The starting point</param>
        /// <param name="rhs">The ending point</param>
        /// <returns>A scalar representing the distance</returns>
        public static float Distance(Vector2 lhs, Vector2 rhs)
        {
            return (rhs - lhs).Magnitude;
        }

        /// <summary>
        /// Returns a Vector2 that contains x and y values that are sums of two Vector2 x and Y values
        /// </summary>
        /// <param name="lhs"> Vector2 on the left hand side </param>
        /// <param name="rhs"> Vector2 on the right hand side </param>
        /// <returns></returns>
        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            //Adds the x and y values of the left and right hand sides.
            //Returning new a new vector 2 with those values as the x and y coordinates
            return new Vector2 { X = lhs.X + rhs.X, Y = lhs.Y + rhs.Y };
        }

        /// <summary>
        /// Returns a Vector2 that contains x and y values that are differences of two Vector2 x and Y values
        /// </summary>
        /// <param name="lhs"> Vector2 on the left hand side </param>
        /// <param name="rhs"> Vector2 on the right hand side </param>
        /// <returns></returns>
        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            //Subtracts the x and y values of the left and right hand sides.
            //Returning new a new vector 2 with those values as the x and y coordinates
            return new Vector2 { X = lhs.X - rhs.X, Y = lhs.Y - rhs.Y };
        }

        /// <summary>
        /// Multiplication with a scaler
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="scaler"></param>
        /// <returns> A new vector with multiplied variables </returns>
        public static Vector2 operator *(Vector2 vector, float scaler)
        {
            // Multiplies the x and y values of a given vector by a scaler
            //Returns new a new vector 2 with those values as the x and y coordinates
            return new Vector2 { X = vector.X * scaler, Y = vector.Y * scaler };
        }

        /// <summary>
        /// Division with a scaler
        /// </summary>
        /// <param name="vector"> The vector being divided </param>
        /// <param name="scaler"> The scaler the vector is being divided by</param>
        /// <returns> A new vector with divided variables </returns>
        public static Vector2 operator /(Vector2 vector, float scaler)
        {
            //Divides the x and y values of a given vector by a scaler
            //Returns new a new vector 2 with those values as the x and y coordinates
            return new Vector2 { X = vector.X / scaler, Y = vector.Y / scaler };
        }

        //Equals
        public static bool operator ==(Vector2 checkingVector, Vector2 vectorChecked)
        {
            // Checks if the x and y variables of one vector2 are exactly the same as another vector2's x and y variables
            if (checkingVector.X == vectorChecked.X && checkingVector.Y == vectorChecked.Y)
            {
                //...returns true
                return true;
            }

            //..otherwise, returns false
            return false;
        }

        //Not Equals
        public static bool operator !=(Vector2 checkingVector, Vector2 vectorChecked)
        {
            // Checks if the x or y variables of one vector are not equal to another vector2's x or y variables
            if (checkingVector.X != vectorChecked.X || checkingVector.Y != vectorChecked.Y)
            {
                //...returns true
                return true;
            }

            //...returns false
            return false;
        }

        /// <summary>
        /// Returns a vector2 containg an instance of a vector divided by the magnitude
        /// </summary>
        /// <returns> The result of the normalization. Returns an empty vector2 if the magnitude is zero</returns>
        public Vector2 Normalize()
        {
            if (Magnitude == 0)
            {
                return new Vector2();
            }
            return this / Magnitude;
        }
    }
}
