using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;

namespace Store.Entities
{
    public abstract class BaseEntity : Notifiable<Notification>
    {
        #region Constructos

        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        #endregion

        #region Properties

        public Guid Id { get; private set; }

        #endregion
    }
}
