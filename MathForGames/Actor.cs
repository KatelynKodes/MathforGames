using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{

    class Actor
    {
        private string _name;
        private bool _started;
        private Collider _collider;
        private Matrix3 _transform = Matrix3.Identity;
        private Matrix3 _translate = Matrix3.Identity;
        private Matrix3 _rotation = Matrix3.Identity;
        private Matrix3 _scale = Matrix3.Identity;
        private Sprite _sprite;

        public bool Started
        {
            get { return _started; }
        }

        public Vector2 Position
        {
            get { return new Vector2(_transform.M02, _transform.M12); }
            set 
            { 
                _transform.M02 = value.X;
                _transform.M12 = value.Y;
            }
        }

        public Sprite Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
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

        public Actor(float x, float y, string name = "Actor", string path = "") :
            this(new Vector2 {X = x, Y = y}, name, path){ }

        public Actor(Vector2 position, string name = "Actor", string path = "")
        {
            Position = position;
            _name = name;

            if (path != "")
            {
                _sprite = new Sprite(path);
            }
        }

        public virtual void Start()
        {
            _started = true;
        }

        public virtual void Update(float deltaTime)
        {
            Console.WriteLine(GetName + ": (" + Position.X + "," + Position.Y + ")");
        }

        public virtual void Draw()
        {
            if (_sprite != null)
            {
                _sprite.Draw(_transform);
            }
        }

        public void End()
        {

        }

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

        /// <summary>
        /// Sets the scale of the actor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetScale(float x, float y)
        {
            _scale.M00 = x;
            _scale.M11 = y;
        }

        /// <summary>
        /// Scales the actor by a given amount
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Scale(float x, float y)
        { 
        }

        /// <summary>
        /// Sets the position of the actor
        /// </summary>
        /// <param name="Translationx"></param>
        /// <param name="Translationy"></param>
        public void SetTranslation(float Translationx, float Translationy)
        {
            
        }

        /// <summary>
        /// Translates the actor by a given amount.
        /// </summary>
        /// <param name="translationX"></param>
        /// <param name="translationY"></param>
        public void Translate(float translationX, float translationY)
        {
            
        }

        /// <summary>
        /// Sets the rotation of the actor
        /// </summary>
        /// <param name="scaleX"></param>
        /// <param name="scaleY"></param>
        public void SetRotation(float scaleX, float scaleY)
        {

        }

        /// <summary>
        /// Adds a rotation to the given transforms rotation
        /// </summary>
        /// <param name="radians"></param>
        public void Rotate(float radians)
        {
            
        }
    }
}