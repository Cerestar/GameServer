using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace GameServer {
    enum Gender { 
        MALE,
        FEMALE
    }

    enum DIRECTION {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    enum StatusEffect {
        POISON,
        STUN,
        GUARD,          //0.5 Damage Ignored
        SLOWHEAL,       //tick healing
        GUARDBREAK      //1.5 Damage taken
    }

    class Character {
        private int id;
        private string charName;
        private Gender gender;

        public int level;

        public float health;
        public float mana;
        public bool[] statusEffect;

        //Currency
        public int gold;

        //inventory - array of items in inv
        //paperdoll - array of items in paperdoll

        public Vector3 position;
        public DIRECTION rotation;

        private float moveSpeed = 5f / Constants.TICKS_PER_SEC;
        private bool[] inputs;

        public Character(int _id, string _charName, Gender _gender, Vector3 _spawnLoc) {
            id = _id;
            charName = _charName;
            gender = _gender;

            level = 0;

            statusEffect = new bool[Enum.GetNames(typeof(StatusEffect)).Length]; //length of enum

            gold = 0;

            position = _spawnLoc;
            rotation = DIRECTION.DOWN;
        }


        public void Update() {
            Vector2 _inputDirection = GetInputDirection();

            //Move(_inputDirection);
        }

        public Vector2 GetInputDirection() {
            Vector2 _inputDirection = Vector2.Zero;
            if (inputs[0])
                _inputDirection.Y += 1;

            if (inputs[1])
                _inputDirection.Y -= 1;

            if (inputs[2])
                _inputDirection.X += 1;

            if (inputs[3])
                _inputDirection.X -= 1;

            return _inputDirection;
        }

        public void AddStatusEffect(StatusEffect se) {
            statusEffect[(int)se] = true;
        }

        public void RemoveStatusEffect(StatusEffect se) {
            statusEffect[(int)se] = false;
        }
        

    }
}
