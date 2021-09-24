using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace GameServer {
    class Player {
        public int id;
        public string username;
        public int gold;

        public Vector3 position;
        public Quaternion rotation;

        private float moveSpeed = 5f / Constants.TICKS_PER_SEC;
        private bool[] inputs;

        public Player(int _id, string _username, Vector3 _position) {
            this.id = _id;
            this.username = _username;
            this.position = _position;
            this.rotation = Quaternion.Identity;

            inputs = new bool[4];
        }

        public void Update() {
            Vector2 _inputDirection = Vector2.Zero;
            if (inputs[0])
                _inputDirection.Y += 1;

            if (inputs[1])
                _inputDirection.Y -= 1;

            if (inputs[2])
                _inputDirection.X += 1;

            if (inputs[3])
                _inputDirection.X -= 1;

            Move(_inputDirection);
        }

        private void Move(Vector2 _inputDirection) {
            Vector3 _up = new Vector3(0, 1, 0);
            Vector3 _right = new Vector3(-1, 0, 0);

            Vector3 _moveDirection = _right * _inputDirection.X + _up * _inputDirection.Y;
            position += _moveDirection * moveSpeed;

            ServerSend.PlayerPosition(this);
            //ServerSend.PlayerRotation(this);
        }

        private void MoveFPS(Vector2 _inputDirection) {
            Vector3 _forward = Vector3.Transform(new Vector3(0, 0, 1), rotation);
            Vector3 _right = Vector3.Normalize(Vector3.Cross(_forward, new Vector3(0, 1, 0)));

            Vector3 _moveDirection = _right * _inputDirection.X + _forward * _inputDirection.Y;
            position += _moveDirection * moveSpeed;

            ServerSend.PlayerPosition(this);
            ServerSend.PlayerRotation(this);
        }

        public void SetInput(bool[] _inputs) {
            inputs = _inputs;
        }
    }
}
