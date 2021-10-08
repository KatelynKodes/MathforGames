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
            
        }

        public virtual void Update()
        {
            _position.X = GetPosition.X + 1;
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
