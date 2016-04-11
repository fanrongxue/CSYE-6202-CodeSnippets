using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration{
    public class User
    {
        private int total = 0;
        public String UserName { get; set; }
        public String PassWord { get; set; }
        public int Total { get; set; }

        public User(String userName, String passWord)
        {

            UserName = userName;
            PassWord = passWord;

        }

        public int addTotal()
        {

            total = total + 1;
            if (total > 3)
            {
                return 0;
            }
            else
            {
                return 1;
            }

        }

        public void resetTotal()
        {
            total = 0;
        }
    }
}
