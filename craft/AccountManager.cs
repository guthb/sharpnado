namespace craft
{
    public class AccountManager
    {
        //Avoid regions
        #region UserManagment
        #endregion

        #region RoleManagmen
        #endregion

        #region DataAccess
        #endregion
    
    
        public bool Login(string userName, string password)
        {
            if (String.IsNullOrEmpty(userName))
            {
                return false;
            }

            // ...

            return true;
        }

        public void WriteFile(byte[] contents, bool flush)
        {
            //this is poor

        }

        //this is better
        public void WriteFile(byte[] contents)
        {
            WriteFile(contents, false);
        }

        public void WriteFileAndFlush(byte[] contents)
        {
            WriteFile(contents, true);
        }

        public void LoginUser(string userName, stringpassword, IPAddress ipAddress, bool persist)
        {
            // ... to many params
        }

        // do this instead
        public void LoginUser(UserLoginRequest  request)
        {
            // ...
        }

        if (account.Ballance > 0 && !account.IsVip && account.DueDate > CurrentDate)
        {
            //send off a warning
        }

        //better
        if (account.IsPastDue)
        {
            // ...
        }

        if (account.Ballance < 10000)
        {
            return false;
        }
        else if (account.IsPastDue)
        {
            return false;
        }
        else if (account.IsVip)
        {
            return false;
        }
       
        return true;

        //better
        var isValid = true;

        if (account.Ballance < 10000)
        {
            isValid = false;
        }
        else if (account.IsPastDue)
        {
            isValid = false;
        }
        else if (account.IsVip)
        {
            return isValid;
        }
       
        return true;
    }
}