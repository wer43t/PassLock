namespace Core.DataBase
{
    public partial class PassLockEntities
    {
        private static PassLockEntities context;
        public static PassLockEntities GetContext()
        {
            if (context == null)
                context = new PassLockEntities();
            return context;
        }
    }
}
