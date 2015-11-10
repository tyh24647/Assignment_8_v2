using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.AmazonData {
    public class UserInfoDelegate {
        private string userID, userKey;
        public string UserID { get { return userID; } }
        public string UserKey { get { return userKey; } }

        public UserInfoDelegate() {
            setUserID();
            setUserKey();
        }

        private void setUserID() {
            if (userID == null) {
                userID = "AKIAI73IJ3QBHZZEL4UQ";
            }
        }

        private void setUserKey() {
            if (userKey == null) {
                userKey = "5AqwixdvRjVDS2KqqtusIbfNlHvES56OFyXtkCEh";
            }
        }
    }
}
