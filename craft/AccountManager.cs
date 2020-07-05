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


    
    
    
    }
}