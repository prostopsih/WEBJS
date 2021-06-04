using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLab5.Models;

namespace WebLab5.Services
{
    public class ChatService
    {
        public static List<ChatRoom> rooms = new List<ChatRoom>();

        public List<ChatRoom> GetRooms()
        {
            return rooms;
        }

        public ChatRoom GetRoom(string name)
        {
            return rooms.FirstOrDefault(x => x.Name == name);
        }

        public bool AddRoom(ChatRoom room)
        {
            if(!rooms.Any(x => x.Name == room.Name))
            {
                rooms.Add(room);
                return true;
            }
            return false;
        }

        public bool RenameRoom(string oldName, string newname, string userName)
        {
            var room = rooms.FirstOrDefault(x => x.Name == oldName);

            if(room == null || room.Owner != userName)
            {
                return false;
            }

            room.Name = newname;
            return true;
        }

        public bool RemoveRoom(string roomName, string userName)
        {
            var room = rooms.FirstOrDefault(x => x.Name == roomName);

            if (room == null || room.Owner != userName)
            {
                return false;
            }

            rooms.RemoveAll(x => x.Name == roomName);
            return true;
        }

        public bool JoinRoom(string roomName, string userName)
        {
            var room = rooms.FirstOrDefault(x => x.Name == roomName);
            if(room == null || rooms.Any(x => x.Members.Any(x => x == userName)))
            {
                return false;
            }

            room.Members.Add(userName);
            return true;
        }

        public bool LeaveRoom(string roomName, string userName)
        {
            var room = rooms.FirstOrDefault(x => x.Name == roomName);
            if (room == null || !room.Members.Any(x => x == userName))
            {
                return false;
            }

            room.Members.RemoveAll(x => x == userName);
            return true;
        }

        public IEnumerable<ChatMessage> GetLastMessagesList(string roomName, int count = 10)
        {
            var room = rooms.FirstOrDefault(x => x.Name == roomName);

            return room.Messages.TakeLast(count);
        }

        public IEnumerable<string> GetMembersList(string roomName)
        {
            var room = rooms.FirstOrDefault(x => x.Name == roomName);

            return room.Members;
        }

        public ChatMessage AddMessage(string roomName, string userName, string message)
        {
            var room = rooms.FirstOrDefault(x => x.Name == roomName);

            if(room.Members.Any(x => x == userName))
            {
                var msg = new ChatMessage { Author = userName, Text = message, Timestamp = DateTime.UtcNow.ToString("o") };
                room.Messages.Add(msg);
                return msg;
            }

            return null;
        }
    }
}
