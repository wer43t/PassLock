namespace Core.DataBase
{
    public partial class VediGroupEntities
    {
        private static VediGroupEntities context;
        public static VediGroupEntities GetContext()
        {
            if (context == null)
                context = new VediGroupEntities();
            return context;
        }
    }
}
