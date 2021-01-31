using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Task_Assignment.Hubs
{
    public class SessionHub : Hub
    {
        public override Task OnConnected()
        {
            var employeeID = Context.Request.Cookies["EmployeeID"].Value;

            Groups.Add(Context.ConnectionId, employeeID);
            Clients.OthersInGroup(employeeID).refresh();
            
            return base.OnConnected();
        }
    }
}