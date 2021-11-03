﻿using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    public enum Shape
    {
        CUBE,
        SPHERE
    }

    class Actor
    {
        private string _name;
        private bool _started;
        private Sprite _sprite;
        private Collider _collider;
        private Shape _shape;

        //transforms
        private Matrix4 _localTransform = Matrix4.Identity;
        private Matrix4 _globalTransform = Matrix4.Identity;
        private Matrix4 _translate = Matrix4.Identity;
        private Matrix4 _rotation = Matrix4.Identity;
        private Matrix4 _scale = Matrix4.Identity;

        //Parents and children
        private Actor[] _children = new Actor[0];
        private Actor _parent;

        public bool Started
        {
            get { return _started; }
        }

        public Vector3 LocalPosition
        {
            get { return new Vector2(_translate.M02, _translate.M12); }
            set{ SetTranslation(value.X, value.Y);}
        }

        public Vector3 WorldPosition
        {
            get { return new Vector3(_globalTransform.M03, _globalTransform.M13, _globalTransform.M23); }
            set 
            {
                if (_parent != null)
                {
                    Vector2 NewLocal = new Vector2(value.X - _parent.LocalTransform.M02/_parent._scale.M00, 
                                                   value.Y - _parent.LocalTransform.M12/_parent._scale.M11);
                    LocalPosition = NewLocal;
                }
                else
                {
                    LocalPosition = value;
                }
            }
        }

        public Matrix4 LocalTransform
        {
            get { return _localTransform; }
            private set { _localTransform = value; }
        }

        public Matrix4 GlobalTransform
        {
            get { return _globalTransform; }
            private set { _globalTransform = value; }
        }

        public Actor Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public Actor[] Children
        {
            get { return _children; }
        }

        public Vector3 Size
        {
            get 
            {
                float xScale = new Vector3(_scale.M00, _scale.M10, _scale.M20).Magnitude;
                float yScale = new Vector3(_scale.M01, _scale.M11, _scale.M21).Magnitude;
                float zScale = new Vector3(_scale.M02, _scale.M12, _scale.M22).Magnitude;

                return new Vector3(xScale, yScale, zScale);
            }
            set { SetScale(value.X, value.Y, value.Z); }
        }

        public string GetName
        {
            get { return _name; }
        }

        public Collider Collider
        {
            get { return _collider; }
            set { _collider = value; }
        }

        public Vector3 Forward
        {
            get { return new Vector3(_rotation.M00, _rotation.M10, _rotation.M22); }
        }

        public Actor(float x, float y, string name = "Actor", Shape shape = Shape.CUBE) :
            this(new Vector3 {X = x, Y = y}, name, shape){ }

        public Actor(Vector3 position, string name = "Actor", Shape shape = Shape.CUBE)
        {
            LocalPosition = position;
            _name = name;
            _shape = shape;
        }

        public virtual void Start()
        {
            _started = true;
        }

        public virtual void Update(float deltaTime)
        {
            UpdateTransforms();
        }

        public virtual void Draw()
        {
            System.Numerics.Vector3 position = new System.Numerics.Vector3(WorldPosition.X, WorldPosition.Y, WorldPosition.Z);
            switch (_shape)
            {
                case Shape.CUBE:
                    float Sizex = new Vector3(GlobalTransform.M00, GlobalTransform.M10, GlobalTransform.M20).Magnitude;
                    float Sizey = new Vector3(GlobalTransform.M01, GlobalTransform.M11, GlobalTransform.M21).Magnitude;
                    float Sizez = new Vector3(GlobalTransform.M02, GlobalTransform.M12, GlobalTransform.M22).Magnitude;

                    Raylib.DrawCube(position, Sizex, Sizey, Sizez, Color.RED);
                    break;
                case Shape.SPHERE:
                    Sizex = new Vector3(GlobalTransform.M00, GlobalTransform.M10, GlobalTransform.M20).Magnitude;
                    Raylib.DrawSphere(position, Sizex, Color.BLUE);
                    break;
            }
        }

        public void End()
        {

        }

        /// <summary>
        /// Updates both the local and global transforms of the actor
        /// </summary>
        public void UpdateTransforms()
        {
            _localTransform = _translate * _rotation * _scale;

            if (Parent != null)
            {
                GlobalTransform = Parent._globalTransform * _localTransform;
            }
            else
            {
                GlobalTransform = LocalTransform;
            }
        }

        //Adding and removing children

        /// <summary>
        /// Adds a child to an actor
        /// </summary>
        /// <param name="childToAdd"> The child to add to an actor </param>
        public void AddChild(Actor childToAdd)
        {
            Actor[] TempChildren = new Actor[Children.Length + 1];

            for (int i = 0; i < Children.Length; i++)
            {
                TempChildren[i] = Children[i];
            }

            TempChildren[TempChildren.Length - 1] = childToAdd;

            childToAdd.Parent = this;

            _children = TempChildren;
        }

        /// <summary>
        /// Removes a child from the children array
        /// </summary>
        /// <param name="childToRemove"></param>
        public void RemoveChild(Actor childToRemove)
        {
            bool childRemoved = false;
            Actor[] TempChildren = new Actor[Children.Length - 1];

            int j = 0;
            for (int i = 0; i < Children.Length; i++)
            {
                if (Children[i] != childToRemove)
                {
                    TempChildren[j] = Children[i];
                    j++;
                }
                else
                {
                    childRemoved = true;
                }
            }

            if (childRemoved)
            {
                _children = TempChildren;
                childToRemove.Parent = null;
            }
        }


        //Collision

        /// <summary>
        /// Checks if this actor collided with another actor
        /// </summary>
        /// <param name="other">The actor to check for a collision against</param>
        /// <returns>true if the distance between the actors is less than the radii of the two combined</returns>
        public virtual bool CheckForCollision(Actor other)
        {
            //return false automatically if either actor doesn't have a collider initialized
            if (Collider == null || other.Collider == null)
            {
                return false;
            }

            return Collider.CheckCollider(other);   
        }

        public virtual void OnCollision(Actor actor)
        {
        }


        //Scale, Translation, and Rotation

        /// <summary>
        /// Sets the scale of the actor
        /// </summary>
        /// <param name="x">The value to scale on the x axis.</param>
        /// <param name="y">The value to scale on the y axis.</param>
        public void SetScale(float x, float y, float z)
        {
            _scale = Matrix4.CreateScale(new Vector3(x,y,z));
        }

        /// <summary>
        /// Scales the actor by a given amount
        /// </summary>
        /// <param name="x">The value to scale on the x axis.</param>
        /// <param name="y">The value to scale on the y axis.</param>
        public void Scale(float x, float y, float z)
        {
            _scale *= Matrix4.CreateScale(new Vector3(x,y,z));
        }

        /// <summary>
        /// Sets the position of the actor
        /// </summary>
        /// <param name="Translationx">The new x position</param>
        /// <param name="Translationy">The new y position</param>
        public void SetTranslation(float Translationx, float Translationy, float Translationz)
        {
            _translate = Matrix4.CreateTranslation(Translationx, Translationy, Translationz);
        }

        /// <summary>
        /// Translates the actor by a given amount.
        /// </summary>
        /// <param name="translationX">The amount to move on the x</param>
        /// <param name="translationY">The amount to move on the y</param>
        public void Translate(float translationX, float translationY, float translationZ)
        {
            _translate *= Matrix4.CreateTranslation(translationX, translationY, translationZ);
        }

        /// <summary>
        /// Sets the rotation of the actor
        /// </summary>
        /// <param name="radians">The angle of the new rotation in radians.</param>
        public void SetRotation(float radianX, float radianY, float radianZ)
        {
            Matrix4 RotationX = Matrix4.CreateRotationX(radianX);
            Matrix4 RotationY = Matrix4.CreateRotationY(radianY);
            Matrix4 RotationZ = Matrix4.CreateRotationZ(radianY);

            _rotation = RotationX * RotationY * RotationZ;
        }

        /// <summary>
        /// Adds a rotation to the given transforms rotation
        /// </summary>
        /// <param name="radians">The angle in radians to turn.</param>
        public void Rotate(float radians)
        {
            Matrix4 RotationX = Matrix4.CreateRotationX(radianX);
            Matrix4 RotationY = Matrix4.CreateRotationY(radianY);
            Matrix4 RotationZ = Matrix4.CreateRotationZ(radianY);

            _rotation *= RotationX * RotationY * RotationZ;
        }


        /// <summary>
        /// Rotates actor to face the given position
        /// </summary>
        /// <param name="position"></param>
        public void LookAt(Vector2 position)
        {
            /*Find the direction the actor should look in
            Vector2 Direction = (position - LocalPosition).Normalized;

            //Use dotproduct to find the angle the actor needs to rotate
            float dotProd = Vector2.DotProduct(Direction, Forward);
            float angle = (float)Math.Acos(dotProd);

            //Find a perpendicular vector to the distance
            Vector2 perpDirection = new Vector2(Direction.Y, -Direction.X);

            //Find the dotProduct of the perpendicular vector and the current forward
            float perpDot = Vector2.DotProduct(perpDirection, Forward);

            //If the result isn't 0, change the sign of the angle to be either positive or negative
            if (perpDot != 0)
            {
                angle *= -perpDot / Math.Abs(perpDot);
            }

            Rotate(angle);*/
        }
    }
}