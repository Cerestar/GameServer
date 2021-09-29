using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer {
    class ServerSend {

        #region TCP
        private static void SendTCPData(int _clientID, Packet _packet) {
            _packet.WriteLength();
            Server.clients[_clientID].tcp.SendData(_packet);
        }

        private static void SendTCPDataToAll(Packet _packet) {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++) {
                Server.clients[i].tcp.SendData(_packet);
            }
        }

        private static void SendTCPDataToAll(int _exceptClientID, Packet _packet) {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++) {
                if (i != _exceptClientID) {
                    Server.clients[i].tcp.SendData(_packet);
                }
            }
        }

        #endregion

        #region UDP
        private static void SendUDPData(int _clientID, Packet _packet) {
            _packet.WriteLength();
            Server.clients[_clientID].udp.SendData(_packet);
        }

        private static void SendUDPDataToAll(Packet _packet) {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++) {
                Server.clients[i].udp.SendData(_packet);
            }
        }

        private static void SendUDPDataToAll(int _exceptClientID, Packet _packet) {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++) {
                if (i != _exceptClientID) {
                    Server.clients[i].udp.SendData(_packet);
                }
            }
        }
        #endregion

        #region Packets

        public static void Welcome(int _clientID, string _msg) {
            using (Packet _packet = new Packet((int)ServerPackets.welcome)) {
                _packet.Write(_msg);
                _packet.Write(_clientID);

                SendTCPData(_clientID, _packet);
            }
        }

        public static void SpawnPlayer(int _toClient, Player _player) {
            using (Packet _packet = new Packet((int)ServerPackets.spawnPlayer)) {
                _packet.Write(_player.id);
                _packet.Write(_player.username);
                _packet.Write(_player.position);

                SendTCPData(_toClient, _packet);
            }
        }

        public static void PlayerPosition(Player _player) {
            using (Packet _packet = new Packet((int)ServerPackets.playerPosition)) {
                _packet.Write(_player.id);
                _packet.Write(_player.position);

                SendUDPDataToAll(_packet);
            }
        }

        #endregion
    }
}
