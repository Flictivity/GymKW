using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymKW.Data
{
    public partial class User
    {
        public Subscription LastSubscription => this.Subscription.OrderByDescending(x => x.Id).FirstOrDefault();
    }
}
