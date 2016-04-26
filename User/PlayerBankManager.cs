using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    public class PlayerBankManager
    {
        public List<Hub.PlayerBank> getPlayers()
        {
            using (var db = new Hub.StandingEntities())
            {
                var players = from o in db.PlayerBank orderby Guid.NewGuid() select o;
                return players.ToList();
            }
        }
    }
}
