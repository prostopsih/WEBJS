using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLab5.Helper;
using WebLab5.Models;
using WebLab5.Services;

namespace WebLab5.Hubs
{
    [AllowAnonymous]
    public class ChatHub : Hub
    {
        private readonly ChatService _chatService;
        private readonly AccountService _accountService;

        public ChatHub(ChatService chatService, AccountService accountService)
        {
            _chatService = chatService;
            _accountService = accountService;
        }

        public async Task GetToken(string ignoreIt, User user)
        {
            var token = _accountService.Register(user.Login, user.TelegramLogin, this.Context.ConnectionId);
            if (!String.IsNullOrEmpty(token))
            {
                await Clients.Caller.SendAsync(StringNamesHelper.SERVER_TOKEN, "Ignore it", token);
            }
        }

        public async Task GetRoomsList(string user, object ignoreIt)
        {
            var res = _chatService.GetRooms();
            await Clients.Caller.SendAsync(StringNamesHelper.SERVER_ROOMS_LIST, "Ignore it", res);
        }

        public async Task CreateRoom(string userToken, string roomName)
        {
            var user = _accountService.Getusername(userToken);
            var room = new ChatRoom { Name = roomName, Owner = user };
            if(_chatService.AddRoom(room))
            {
                await Clients.All.SendAsync(StringNamesHelper.SERVER_ROOM_CREATED, "Ignore it", room);
            }
        }

        public async Task RenameRoom(string userToken, RenameRoomModel renameRoomModel)
        {
            var user = _accountService.Getusername(userToken);
            if(_chatService.RenameRoom(renameRoomModel.OldRoomName, renameRoomModel.NewRoomName, user))
            {
                await Clients.All.SendAsync(StringNamesHelper.SERVER_ROOM_RENAMED, "Ignore it", renameRoomModel);
            }
        }

        public async Task RemoveRoom(string userToken, string roomName)
        {
            var user = _accountService.Getusername(userToken);
            var room = _chatService.GetRoom(roomName);
            if (_chatService.RemoveRoom(roomName, user))
            {
                await Clients.All.SendAsync(StringNamesHelper.SERVER_ROOM_REMOVED, "Ignore it", room);
            }
        }

        public async Task JoinRoom(string userToken, string roomName)
        {
            var user = _accountService.Getusername(userToken);
            if(_chatService.JoinRoom(roomName, user))
            {
                await Clients.AllExcept(GetExceptConsToNotify(roomName)).SendAsync(StringNamesHelper.SERVER_MEMBER_JOINED, "Ignore it", user);
                await Clients.Caller.SendAsync(StringNamesHelper.SERVER_CURRENT_ROOM_CHANGED, "Ignore it", _chatService.GetRoom(roomName));
            }
        }

        public async Task LeaveRoom(string userToken, string roomName)
        {
            var user = _accountService.Getusername(userToken);
            if(_chatService.LeaveRoom(roomName, user))
            {
                await Clients.Caller.SendAsync(StringNamesHelper.SERVER_CURRENT_ROOM_CHANGED, "Ignore it", new ChatRoom { Name = ""});
                await Clients.AllExcept(GetExceptConsToNotify(roomName)).SendAsync(StringNamesHelper.SERVER_MEMBER_LEFT, "Ignore it", user);
            }
        }

        public async Task GetLastMessagesList(string userToken, string roomName)
        {
            var user = _accountService.Getusername(userToken);
            var res = _chatService.GetLastMessagesList(roomName);
            await Clients.Caller.SendAsync(StringNamesHelper.SERVER_LAST_MESSAGES_LIST, "Ignore it", res);
        }

        public async Task GetMembersList(string userToken, string roomName)
        {
            var user = _accountService.Getusername(userToken);
            var res = _chatService.GetMembersList(roomName);
            await Clients.Caller.SendAsync(StringNamesHelper.SERVER_MEMBERS_LIST, "Ignore it", res);
        }

        public async Task PostMessage(string userToken, string text)
        {
            var user = _accountService.Getusername(userToken);
            var room = _chatService.GetRooms().Where(x => x.Members.Any(x => x == user)).FirstOrDefault();
            var msg = _chatService.AddMessage(room.Name, user, text);
            if (msg != null)
            {
                var neededConns = room.Members.Select(x => _accountService.GetConnId(x));
                await Clients.AllExcept(_accountService.GetConsExcept(neededConns)).SendAsync(StringNamesHelper.SERVER_MESSAGE_POSTED, "Ignore it", msg);
            }
        }

        private IEnumerable<string> GetExceptConsToNotify(string roomName)
        {
            var room = _chatService.GetRoom(roomName);
            var neededConns = room.Members.Select(x => _accountService.GetConnId(x));

            return _accountService.GetConsExcept(neededConns);
        }
    }
}
