using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace GameServer {
    class ServerHandle {
        public static void WelcomeReceived(int _clientID, Packet _packet) {
            int _clientIDCheck = _packet.ReadInt();
            string _username = _packet.ReadString();

            Console.WriteLine($"{Server.clients[_clientID].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player {_clientID}.");

            if (_clientID != _clientIDCheck) {
                Console.WriteLine($"Player \"{_username}\" (ID: {_clientID}) has assumed the wrong client ID ({_clientIDCheck})!");
            }

            Server.clients[_clientID].SendIntoGame(_username);
        }

        public static void PlayerMovement(int _clientID, Packet _packet) {
            bool[] _inputs = new bool[_packet.ReadInt()];

            for (int i = 0; i < _inputs.Length; i++) 
                _inputs[i] = _packet.ReadBool();

            Quaternion _rotation = _packet.ReadQuaternion();

            Server.clients[_clientID].player.SetInput(_inputs, _rotation);
        }
    }
}
