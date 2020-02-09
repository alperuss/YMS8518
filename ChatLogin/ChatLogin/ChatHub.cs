using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatLogin
{
    public class ChatHub:Hub
    {
        public async Task SendMessage(string user, string message)
        {

            using (DataContext dataContext = new DataContext())
            {
                dataContext.Chats.Add(new Models.Chat()
                {
                    Date = DateTime.UtcNow,
                    Message = message,
                    Username = user
                });

                dataContext.SaveChanges();
            }
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
