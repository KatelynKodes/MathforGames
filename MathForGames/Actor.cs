using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace MathForGames
{
    class Actor
    {
        private char _icon;
        private string _name;
        private Vector2 _position;
        private bool _started;

        public bool Started
        {
            get { return _started;}
        }

        public Vector2 GetPosition
        {
            get { return _position; }
            set { _position = value; }
        }

        public Actor(char CharIcon, Vector2 Position, string name = "Actor")
        {
            _icon = CharIcon;
            _position = Position;
            _name = name;
        }

        public virtual void Start()
        {
            _started = true;
        }

        public virtual void Update()
        {
            _position.X = _position.X + 1;
        }

        public virtual void Draw()
        {
            Console.SetCursorPosition((int)GetPosition.X, (int)GetPosition.Y);
            Console.Write(_icon);
        }

        public void End()
        {
            
        }
    }
}
