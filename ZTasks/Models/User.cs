

using ZTasks.NotificationCenter;

namespace ZTasks.Models
{
    class User : NotifyPropertyChangedBase
    {
        private string ZUserId;
        private string ZUserName;
        public string UserId
        {
            get
            {
                return ZUserId;
            }

            set
            {
                this.SetProperty(ref ZUserId, value);
            }
        }
        public string UserName
        {
            get
            {
                return ZUserName;
            }

            set
            {
                this.SetProperty(ref ZUserName, value);
            }
        }
    }

}
